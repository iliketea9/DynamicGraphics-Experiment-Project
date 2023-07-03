using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script has to be attached to an Sprite object with the same dimension as the movie screen ("GlowObject" object)

public class GetSize : MonoBehaviour
{
    public static float Width;
    public static float Height;
    public static float Depth;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 boxSize = GetComponent<SpriteRenderer>().bounds.size; //Note that size is given in world size. A Bound surrounding a tall human might have size.y approximately 2.0f, meaning a 2 meter height body.
        Width = boxSize.x;
        Height = boxSize.y;
        Depth = boxSize.z;

        //print(Width);
        //print(Height);
        //print(Depth);

        //Debug.Log("Width2 : " + Width);  //Display in the console the movie screen dimensions
        //Debug.Log("Height2 : " + Height);
        //Debug.Log("Depth2 : " + Depth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
