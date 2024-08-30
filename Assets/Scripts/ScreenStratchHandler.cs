using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool isAspectRatio;

    // Start is called before the first frame update
    void Start()
    {
        var topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        var worldSpaceWidth = topRightCorner.x * 2;
        var worldSpaceHeight = topRightCorner.y * 2;

        var spriteSize = GetComponent<SpriteRenderer>().bounds.size;

        var scaleFactorX = worldSpaceWidth / spriteSize.x;
        var scaleFactorY = worldSpaceHeight / spriteSize.y;

        if (isAspectRatio)
        {
            if (scaleFactorX > scaleFactorY)
            {
                scaleFactorY = scaleFactorX;
            }
            else
            {
                scaleFactorX = scaleFactorY;
            }
            transform.localScale = new Vector3(scaleFactorX, -scaleFactorY, 1);
        }

    }

}

//using System.Linq;
//using UnityEngine;

//public class AutoAdjust : MonoBehaviour
//{
//    // Reference to the main camera
//    public Camera mainCamera;

//    // Scale factor for the objects
//    public float objectScaleFactor = 1f;

//    void Start()
//    {
//        AdjustScreenAndObjects();
//    }

//    void AdjustScreenAndObjects()
//    {
//        // Adjust camera size based on screen resolution
//        float targetAspectRatio = 16f / 9f; // Target aspect ratio, e.g., 16:9
//        float windowAspect = (float)Screen.width / (float)Screen.height;
//        float scaleHeight = windowAspect / targetAspectRatio;

//        if (scaleHeight < 1.0f)
//        {
//            mainCamera.orthographicSize = mainCamera.orthographicSize / scaleHeight;
//        }

//        // Adjust object scale
//        foreach (GameObject obj in FindObjectsOfType(typeof(GameObject)).Cast<GameObject>())
//        {
//            if (obj.CompareTag("Resizable"))
//            {
//                float scaleFactor = objectScaleFactor / scaleHeight;
//                obj.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
//            }
//        }
//    }
//}
