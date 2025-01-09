using System;
using UnityEngine;
using UnityEngine.Tilemaps;


[System.Serializable]
public class TileRow
{
    public GameObject[] columns = new GameObject[3];
}
public class InfinixMap : MonoBehaviour
{

    [SerializeField]
    private TileRow[] rows = new TileRow[3];

    private GameObject[] tiles = new GameObject[3];
    public GameObject player;

    private Vector2 lastPlayerPos;

    public int tileSize = 20;
    int count = 0;

    private GameObject centerTile;

    private void Awake()
    {
        AddTiles();
    }

    void AddTiles()
    {
        tiles = new GameObject[transform.childCount];
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < rows.Length; j++)
            {
                rows[j].columns[i] = tiles[count];
                count++;
            }

        }

    }

    void Start()
    {
        // Lưu lại bounds của tilemap gốc
        // lastPlayerPosition = player.transform.position;
        lastPlayerPos = player.transform.position;
        ArrangeInitialTiles();
    }

    void Update()
    {
        CheckAndMoveTile();
    }

    void ArrangeInitialTiles()
    {


        // Sắp xếp 9 tile theo grid 3x3
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (rows[y].columns[x] != null)
                {
                    Vector3 newPos = CalculateTilePosition(x, y);
                    rows[y].columns[x].transform.position = newPos;
                }    

                  //  rows[y].columns[x].transform.position = new Vector3((x - 1) * (tileSize * 3), (y - 1) * tileSize, 0);
            }
        }

       
    }

    // Hàm mới để tính toán vị trí chính xác của tile
    Vector3 CalculateTilePosition(int x, int y)
    {
        float centerX = player.transform.position.x;
        float centerY = player.transform.position.y;

        return new Vector3(
            centerX + (x - 1) * (tileSize * 3),
            centerY + (y - 1) * tileSize,
            0
        );
    }

    void CheckAndMoveTile()
    {
        Vector2 currentPosition = player.transform.position;
        Vector2 movement = currentPosition - lastPlayerPos;

        if (movement.x > tileSize+20)
        {
            MoveTileHorizontally(1);
            lastPlayerPos = currentPosition;
        }
        else if (movement.x < -tileSize-20)
        {
            MoveTileHorizontally(-1);
            lastPlayerPos = currentPosition;
        }

        if (movement.y > tileSize+10)
        {
            MoveTileVertically(1);
            lastPlayerPos = currentPosition;
        }
        else if (movement.y < -tileSize-10)
        {
            MoveTileVertically(-1);
            lastPlayerPos = currentPosition;
        }

    }
    

    // ham di chuyen tile theo chieu ngang
    void MoveTileHorizontally(int direction)
    {

        for (int y = 0; y < 3; y++)
        {
            GameObject tempTile;
            if (direction > 0) // Di chuyển sang phải
            {
                // Lưu tile ở cột trái
                tempTile = rows[y].columns[0];

                // Di chuyển các tile sang trái
                for (int x = 0; x < 2; x++)
                {
                    rows[y].columns[x] = rows[y].columns[x + 1];
                }

                // Đặt tile đã lưu vào cột phải
                rows[y].columns[2] = tempTile;

                // Di chuyển vị trí của tile
                if (tempTile != null)
                {
                   // Đặt vị trí mới dựa trên vị trí của tile trung tâm
                    tempTile.transform.position = CalculateTilePosition(2, y);
                }
            }
            else // Di chuyển sang trái
            {
                // Lưu tile ở cột phải
                tempTile = rows[y].columns[2];

                // Di chuyển các tile sang phải
                for (int x = 2; x > 0; x--)
                {
                    rows[y].columns[x] = rows[y].columns[x - 1];
                }

                // Đặt tile đã lưu vào cột trái
                rows[y].columns[0] = tempTile;

                // Di chuyển vị trí của tile
                if (tempTile != null)
                {
                    // Đặt vị trí mới dựa trên vị trí của tile trung tâm
                    tempTile.transform.position = CalculateTilePosition(0, y);
                }
            }
        }
    }

    //ham di chuyentile theo chieu doc
    void MoveTileVertically(int direction)
    {
        for (int x = 0; x < 3; x++)
        {
            GameObject tempTile;

            if (direction > 0)
            {
                tempTile = rows[0].columns[x];

                for (int y = 0; y < 2; y++)
                {
                    rows[y].columns[x] = rows[y + 1].columns[x];
                }
                rows[2].columns[x] = tempTile;

                if (tempTile != null)
                {
                    // Đặt vị trí mới dựa trên vị trí của tile trung tâm
                    tempTile.transform.position = CalculateTilePosition(x, 2);
                }

            }

            else
            {
                tempTile = rows[2].columns[x];

                for (int y = 2; y > 0; y--)
                {
                    rows[y].columns[x] = rows[y - 1].columns[x];

                }

                rows[0].columns[x] = tempTile;
                if (tempTile != null)
                {
                    // Đặt vị trí mới dựa trên vị trí của tile trung tâm
                    tempTile.transform.position = CalculateTilePosition(x, 0);
                }
            }

        }
    }

}