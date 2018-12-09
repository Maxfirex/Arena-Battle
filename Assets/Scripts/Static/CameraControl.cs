using UnityEngine;

public static class CameraControl {

    private static Vector2 mouseLook;
    private static Vector2 smoothV;

    private static Camera[] cameras = Object.FindObjectsOfType<Camera>();

    public static void Look(GameObject player, float sensitivity = 5f, float smoothing = 2f)
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        //rotates up and down
        player.GetComponentInChildren<Camera>().transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        //rotates left and right and facing character to look position
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
	}
    public static void Switch()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                if (cameras[i].enabled)
                {
                    if ((i + 1) < cameras.Length)
                    {
                        cameras[i + 1].enabled = cameras[i].enabled;
                        cameras[i].enabled = !cameras[i].enabled;
                        break;
                    }
                    else
                    {
                        cameras[0].enabled = cameras[i].enabled;
                        cameras[i].enabled = !cameras[i].enabled;
                    }

                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }
            cameras[0].enabled = true;
        }
    }
}
