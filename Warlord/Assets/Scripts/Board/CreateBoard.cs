using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoard : MonoBehaviour
{
    [SerializeField] public GameObject LightFieldPrefab;
    [SerializeField] public GameObject DarkFieldPrefab;

    private float xOffset = 0.357f;
    private float darkFieldOffset = 0.186f;

    private float zHorizontalOffsetDarkField = -0.4f;
    private float zHorizontalOffsetLightField = -0.772f;
 
    public void GenerateBoard(byte width, byte height)
    {
        float previousZ = 0.0f;
        for (byte i = 0; i < width; i++) 
        {
            if (i % 2 == 1)
            {
                previousZ -= darkFieldOffset;
            }
            for(byte j = 0; j < height; j++)
            {
                if(i % 2 == j % 2)
                {
                    GameObject field = Instantiate(LightFieldPrefab);
                    float newZ = previousZ;
                    newZ += zHorizontalOffsetLightField;
                    previousZ = newZ;
                    Vector3 newPostion = field.transform.position;
                    newPostion.z = newZ;
                    newPostion.x = xOffset * i;
                    field.transform.position = newPostion;
                    field.transform.parent = gameObject.transform;
                }
                else
                {
                    GameObject field = Instantiate(DarkFieldPrefab);
                    float newZ = previousZ;
                    newZ += zHorizontalOffsetDarkField;
                    previousZ = newZ;
                    Vector3 newPostion = field.transform.position;
                    newPostion.z = newZ;
                    newPostion.x = xOffset * i;
                    field.transform.position = newPostion;
                    field.transform.parent = gameObject.transform;
                }
            }
            previousZ = 0.0f;
        }
    }
}
