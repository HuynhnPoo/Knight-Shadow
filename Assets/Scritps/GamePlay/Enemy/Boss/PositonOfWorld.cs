using UnityEngine;

public class PositonOfWorld
{
   public Vector3 TakePositonOfWorld()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {


            // Góc trên bên phải của viewport (tọa độ thế giới)
            Vector3 topRightWorld = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));


            Vector3 vector3a = Vector3.zero;

            vector3a = new Vector3(topRightWorld.x / 10, topRightWorld.y - 3, 0);
            return vector3a;
        }
        else
        {
            Debug.LogError("Không tìm thấy Main Camera trong scene.");
           return Vector3.zero;
        }
    }
}
