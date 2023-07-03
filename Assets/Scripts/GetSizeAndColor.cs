using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// This script has to be attached to the transparent plane around the screen containing a texture ("Plane" object)

public class GetSizeAndColor : MonoBehaviour
{
    //private float ScreenWidth;
    //private float ScreenHeight;
    //private float ScreenDepth;
    private int RendTextWidth = 0;
    private int RendTextHeight = 0;
    private Texture2D texCopy;

    private float time = 0.0f;
    public float period = 5f; //Get pixel color every 5 seconds
    public int step = 10; //Jump to next pixel with a step of 10
    private float nextActionTime = 0.0f;
    private double x = 0;
    private double y = 0;
    public RenderTexture renderTexture;
    private Texture2D texture2D;
    private Color ColorX;
    private Color ColorY;

    // Start is called before the first frame update
    void Start()
    {
        Texture2D texture2D = new Texture2D(0, 0, TextureFormat.RGB24, false);

        // Get the dimensions of the movie screen. More exactly, of the Glow Object
        //GameObject gameObject = GameObject.Find("GlowObject"); //Find the Game Object containing the GetSize script called GlowObject

        //WidthCopy = gameObject.GetComponent<GetSize>().Width; //Get the variables in GetSize script (Width, Height, Depth)
        //HeightCopy = gameObject.GetComponent<GetSize>().Height;
        //DepthCopy = gameObject.GetComponent<GetSize>().Depth;

        //GetSize.Width = WidthCopy; //Get the variables in GetSize script (Width, Height, Depth)
        //GetSize.Height = HeightCopy;
        //GetSize.Depth = DepthCopy;

        double ScreenWidth = 10;
        double ScreenHeight = 5.625;
        double ScreenDepth = 0.2;

        //Debug.Log("Width : " + ScreenWidth);  //Display in the console the Glow Object dimensions that has the same dimensions as the movie screen.
        //Debug.Log("Height : " + ScreenHeight);
        //Debug.Log("Depth : " + ScreenDepth);

        x = ScreenWidth / 2;    //The screen is at the coordinates (0,0), so we start measuring the pixel color from the border of the screen (Width or Height / 2)
        y = ScreenHeight / 2;

        Color ColorX = new Color(0.3f, 0.4f, 0.6f, 0.3f);
        Color ColorY = new Color(0.3f, 0.4f, 0.6f, 0.3f);
    }

    WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();

    public IEnumerator TakeSnapshot(int width, int height)
    {
        //renderTexture = RenderTexture.active;   //Get the texture dimensions of the plane around the screen, where to measure the color.
        //RenderTexture.active = renderTexture;

        RendTextWidth = renderTexture.width;
        RendTextHeight = renderTexture.height;

        yield return frameEnd;

        texture2D = new Texture2D(RendTextWidth, RendTextHeight, TextureFormat.RGB24, true); //Create a new texture with the width and height of the plane

        texture2D.ReadPixels(new Rect(0, 0, RendTextWidth, RendTextHeight), 0, 0);
        texture2D.LoadRawTextureData(texture2D.GetRawTextureData());
        texture2D.Apply();  //Convert the render texture into a 2D texture


    }
    

    // Update is called once per frame
    void Update()
    {
        if (texture2D is Texture2D)
            Debug.Log("Texture2D Is a Texture2D");
        else
            Debug.Log("Texture2D Is Not a Texture2D");

        //string path = "Assets/Materials/DefaultTexture.renderTexture";
        //var textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
        //if (textureImporter.isReadable == false)
        //{
        //    textureImporter.isReadable = true;
        //    AssetDatabase.ImportAsset(path);
        //}



        if (Time.time > nextActionTime)  //Every period (5 seconds) the program get and display the color of a new pixel on the Plane texture, with a step of 10
        {
            float nextActionTime = Time.time + period;

            //string path = AssetDatabase.GetAssetPath(texture2D);
            //TextureImporter A = (TextureImporter)AssetImporter.GetAtPath(path);
            //A.isReadable = true;
            //AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

            //texCopy = new Texture2D(texture2D.width, texture2D.height, texture2D.format, texture2D.mipmapCount > 1);
            //texCopy.LoadRawTextureData(texture2D.GetRawTextureData());
            //texCopy.Apply();

            // This is the code for measuring on X axis
            int xi = (int)x;    //Convert float into integer
            xi = xi + step;
            ColorX = texture2D.GetPixel(xi,0);
            //Debug.Log("X : " + (xi)) ;
            Debug.Log("ColorX: " + ColorX);

            // This is the code for measuring on Y axis
            int yi = (int)y;    //Convert float into integer
            yi = yi + step;
            //ColorY = texture2D.GetPixel(0, yi);
            //Debug.Log("Y: " + (yi));
            //Debug.Log("ColorY: " + ColorY);
        }
    }
}
