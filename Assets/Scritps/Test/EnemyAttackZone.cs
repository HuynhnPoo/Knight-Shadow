using UnityEngine;
using System.Collections;


public class EnemyAttackZone : MonoBehaviour
{
    [SerializeField] private int radius = 64;              // Bán kính vòng tròn
    [SerializeField] private Color color = new Color(1, 0, 0, 0.5f); // Màu đỏ trong suốt

    private SpriteRenderer spriteRenderer;
    private Texture2D texture;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        DrawCircle();
    }

    void DrawCircle()
    {
        int size = radius * 2;
        texture = new Texture2D(size, size);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Bilinear;

        Vector2 center = new Vector2(radius, radius);
        float radiusSqr = radius * radius;

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float distSqr = (x - center.x) * (x - center.x) + (y - center.y) * (y - center.y);
                if (distSqr <= radiusSqr)
                    texture.SetPixel(x, y, color);
                else
                    texture.SetPixel(x, y, Color.clear);
            }
        }

        texture.Apply();

        Sprite circleSprite = Sprite.Create(texture, new Rect(0, 0, size, size), new Vector2(0.5f, 0.5f), 100f);
        spriteRenderer.sprite = circleSprite;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Hide();
        }
    }



    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        if (texture != null)
            Destroy(texture);
    }
}
  
