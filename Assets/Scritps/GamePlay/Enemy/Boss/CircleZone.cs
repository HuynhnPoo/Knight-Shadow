using System.Collections;
using UnityEngine;

public class CircleZone
{
    int radius;
    private Color color = new Color(1, 0, 0, 0.5f); // Màu đỏ trong suốt
    private Texture2D texture;
    private SpriteRenderer spriteRenderer;

    public CircleZone(SpriteRenderer spriteRenderer, int radius)
    {
        this.spriteRenderer = spriteRenderer;
        this.radius = radius;
    }

   public void DrawCircle()
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

  /*  void OnDestroy()
    {
        if (texture != null)
            Destroy(texture);
    }*/
}
    