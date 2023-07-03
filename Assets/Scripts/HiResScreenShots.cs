using UnityEngine; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HiResScreenShots : MonoBehaviour
{
    public Text t;
    public RenderTexture renderTexture;
    public int step = 100; //Jump to next pixel with a step of 1 unit
    private int resWidth = 0;
    private int resHeight = 0;
    private float x0 = 0;
    private float y0 = 0;
    private int xi; //i for integer
    private int yi;
    private Color ColorX = new Color(0.3f, 0.4f, 0.6f, 0.3f);
    private Color ColorY = new Color(0.3f, 0.4f, 0.6f, 0.3f);
    private int s = 0; // Cumulative step

    private float xf = 0; //f for float
    private float yf = 0;

    private float Hx, Sx, Vx;
    private float Hy, Sy, Vy;

    Camera cam;
    public GameObject go; // Enter Cube in the Inspector.


    void Start()
    {
        float VideoWidth = (float)10;
        float VideoHeight = (float)5.625;
        float VideoDepth = (float)0.2;

        x0 = 0;    //The screen is at the coordinates (0,0), so we start measuring the pixel color from the border of the screen (Width or Height / 2)
        y0 = VideoHeight/2;   // x and y are floats in units, not in pixels

        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Code from https://forum.unity.com/threads/submitting-featured-content.3880/ website
        if (Input.GetKeyDown("k"))
        {
            resWidth = renderTexture.width;
            resHeight = renderTexture.height;
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            GetComponent<Camera>().targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            GetComponent<Camera>().Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            GetComponent<Camera>().targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors 
            Destroy(rt);

            s = s + step; //cumulative step

            // This is the code for measuring on X axis
            xf = x0 + s; //coordinates of the point where the pixels are checked
            ColorX = screenShot.GetPixel((int)xf, (int)y0);
            Color.RGBToHSV(ColorX, out Hx, out Sx, out Vx);
            Debug.Log("X =" + xf);
            Debug.Log("ColorX =" + ColorX);

            // This is the code for measuring on Y axis
            yf = y0 + s; //coordinates of the point where the pixels are checked
            ColorY = screenShot.GetPixel((int)x0, (int)yf);
            Color.RGBToHSV(ColorY, out Hy, out Sy, out Vy);
            Debug.Log("Y =" + yf);
            Debug.Log("ColorY =" + ColorY);

            Debug.Log("Cumulative step in Pixel" + ConvertToPixels(s));

            Debug.Log("/////////////////////////");

            // Change the position of the cube to check the coordinates of the checked pixels
            go.transform.position = new Vector3((int)xf, (int)y0);

            // Display coordinates of the measured pixel and the color
            t.text = "For (" + (int)xf + " ; " + (int)y0 + ") HSV on x = " + Hx + "," + Sx + "," + Vx + "\n" + "For (" + (int)x0 + " ; " + (int)yf + ") HSV on y = " + Hy + "," + Sy + "," + Vy;
        }
    }

    float ConvertToPixels(float u)
    {
        float ortho = cam.orthographicSize;
        float pixelH = cam.pixelHeight;
        return (u * pixelH / (ortho * 2));
    }

    float ConvertToUnits(float p)
    {
        float ortho = cam.orthographicSize;
        float pixelH = cam.pixelHeight;
        return (p * ortho * 2 / pixelH);
    }
}