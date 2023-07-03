using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionPixel : MonoBehaviour
{
    public GameObject go;
    Camera cam;


    void Start()
    {
        cam = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            //GameObject CenterEyeAnchor = GameObject.Find("CenterEyeAnchor");
            //HiResScreenShots hiResScreenShots = CenterEyeAnchor.GetComponent<HiResScreenShots>();
            //int xx = hiResScreenShots.xi;
            //int yy = hiResScreenShots.yi;
            //float x = (float)xx;
            //float y = (float)yy;
            //x = ConvertToUnits(x);
            //y = ConvertToUnits(y);
            //Debug.Log("Xgo=" + xx);
            //Debug.Log("Ygo=" + yy);

            //go.transform.position = new Vector3(x, y);
        }
    }

    float ConvertToUnits(float p)
    {
        float ortho = cam.orthographicSize;
        float pixelH = cam.pixelHeight;
        return (p*ortho * 2/ pixelH);
    }
}

