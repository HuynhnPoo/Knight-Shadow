using System;
using UnityEngine;

[System.Serializable]
public class TileRow
{
    public GameObject[] columns = new GameObject[3];
}

public class InfinixMap : MonoBehaviour
{
    [SerializeField]
    private TileRow[] rows = new TileRow[3];

    public GameObject player;
    private int tileSize = 10;

    // Khoảng cách để kích hoạt việc di chuyển tile
    private int horizontalTriggerDistance = 15;
    private int verticalTriggerDistance = 5;

    // Mảng lưu trữ các ngưỡng kích hoạt theo cả hai hướng
    private int[] horizontalThresholds = new int[2]; // [0] là ngưỡng âm, [1] là ngưỡng dương
    private int[] verticalThresholds = new int[2];   // [0] là ngưỡng âm, [1] là ngưỡng dương



    private void Awake()
    {
        InitializeTiles();

    }

    private void OnEnable()
    {

    }

    void InitializeTiles()
    {
        int count = 0;
        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < rows[i].columns.Length; j++)
            {
                if (count < transform.childCount)
                {
                    rows[i].columns[j] = transform.GetChild(count).gameObject;
                    count++;
                }
            }
        }
    }

    void Start()
    {
        if (player == null) player = GameManager.Instance.PlayerCrtl.transform.gameObject;

        ArrangeInitialTiles();

        // Khởi tạo các ngưỡng kích hoạt ban đầu cho cả hai hướng
        horizontalThresholds[0] = -horizontalTriggerDistance;  // Ngưỡng âm bên trái
        horizontalThresholds[1] = horizontalTriggerDistance;   // Ngưỡng dương bên phải
        verticalThresholds[0] = -verticalTriggerDistance;      // Ngưỡng âm bên dưới
        verticalThresholds[1] = verticalTriggerDistance;       // Ngưỡng dương been trên
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
            }
        }
    }

    // Hàm tính toán vị trí chính xác của tile
    Vector3 CalculateTilePosition(int x, int y)
    {
        float worldX = (x - 1) * tileSize * 3;
        float worldY = (y - 1) * tileSize;
        return new Vector3(worldX, worldY, 0);
    }

    void CheckAndMoveTile()
    {
        Vector2 currentPosition = player.transform.position;

        // Kiểm tra và di chuyển tile theo chiều ngang
        if (currentPosition.x > horizontalThresholds[1])
        {
            MoveTileHorizontally(1);
            horizontalThresholds[1] += horizontalTriggerDistance;
            horizontalThresholds[0] += horizontalTriggerDistance;
        }
        else if (currentPosition.x < horizontalThresholds[0])
        {
            MoveTileHorizontally(-1);
            horizontalThresholds[0] -= horizontalTriggerDistance;
            horizontalThresholds[1] -= horizontalTriggerDistance;
        }

        // Kiểm tra và di chuyển tile theo chiều dọc
        if (currentPosition.y > verticalThresholds[1])
        {
            MoveTileVertically(1);
            verticalThresholds[1] += verticalTriggerDistance;
            verticalThresholds[0] += verticalTriggerDistance;
        }
        else if (currentPosition.y < verticalThresholds[0])
        {
            MoveTileVertically(-1);
            verticalThresholds[0] -= verticalTriggerDistance;
            verticalThresholds[1] -= verticalTriggerDistance;
        }
    }

    // Hàm di chuyển tile theo chiều ngang
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
                    tempTile.transform.position = new Vector3(tempTile.transform.position.x + 9 * tileSize/2 , tempTile.transform.position.y, 0);
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
                    tempTile.transform.position = new Vector3(tempTile.transform.position.x - 9 * tileSize/2 , tempTile.transform.position.y, 0);
                }
            }
        }

    }

    // Hàm di chuyển tile theo chiều dọc
    void MoveTileVertically(int direction)
    {
        for (int x = 0; x < 3; x++)
        {
            GameObject tempTile;

            if (direction > 0) // Di chuyển lên trên
            {
                // Lưu tile ở hàng dưới
                tempTile = rows[0].columns[x];

                // Di chuyển các tile xuống dưới
                for (int y = 0; y < 2; y++)
                {
                    rows[y].columns[x] = rows[y + 1].columns[x];
                }

                // Đặt tile đã lưu vào hàng trên
                rows[2].columns[x] = tempTile;

                if (tempTile != null)
                {
                    tempTile.transform.position = new Vector3(tempTile.transform.position.x, tempTile.transform.position.y + 3 * tileSize / 2, 0);
                }
            }
            else // Di chuyển xuống dưới
            {
                // Lưu tile ở hàng trên
                tempTile = rows[2].columns[x];

                // Di chuyển các tile lên trên
                for (int y = 2; y > 0; y--)
                {
                    rows[y].columns[x] = rows[y - 1].columns[x];
                }

                // Đặt tile đã lưu vào hàng dưới
                rows[0].columns[x] = tempTile;

                if (tempTile != null)
                {
                    tempTile.transform.position = new Vector3(tempTile.transform.position.x, tempTile.transform.position.y - 3 * tileSize / 2, 0);
                }
            }
        }
    }
}