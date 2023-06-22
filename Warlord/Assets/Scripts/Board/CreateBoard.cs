using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateBoard : MonoBehaviour
{
    [SerializeField] public GameObject LightFieldPrefab;
    [SerializeField] public GameObject DarkFieldPrefab;

    public void GenerateBoard(byte width, byte height)
    {


        float xOffset = 0.357f;
        float darkFieldOffset = 0.186f;
        float zHorizontalOffsetDarkField = -0.4f;
        float zHorizontalOffsetLightField = -0.772f;

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
                    gameObject.GetComponent<Board>().Fields[i, j] = field;
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
                    gameObject.GetComponent<Board>().Fields[i, j] = field;
                }
            }
            previousZ = 0.0f;
        }
    }

    public void PrepareFields(byte width, byte height)
    {
        for(byte i = 0; i < width; i++) 
        {
            for(byte j = 0; j < height; j++)
            {
                gameObject.GetComponent<Board>().Fields[i, j].GetComponent<Field>().X = i;
                gameObject.GetComponent<Board>().Fields[i, j].GetComponent<Field>().Y = j;
                gameObject.GetComponent<Board>().Fields[i, j].GetComponent<Field>().IsOccupied = false;

                if(i % 2 == j % 2) 
                {
                    gameObject.GetComponent<Board>().Fields[i, j].GetComponent<Field>().Direction = true;
                }
                else
                {
                    gameObject.GetComponent<Board>().Fields[i, j].GetComponent<Field>().Direction = false;
                }
            }
        }
    }

    public void AssignNeighbours(byte width, byte height)
    {
        for(byte i = 0; i < width; i++)
        {
            for(byte j = 0; j < height; j++)
            {
                if (i > 0)
                {
                    gameObject.GetComponent<Board>().Fields[i, j].GetComponent<Field>().Neighbours.Add(gameObject.GetComponent<Board>().Fields[i - 1, j]);
                }

                if (i < width - 1)
                {
                    gameObject.GetComponent<Board>().Fields[i, j].GetComponent<Field>().Neighbours.Add(gameObject.GetComponent<Board>().Fields[i + 1, j]);
                }

                if (gameObject.GetComponent<Board>().Fields[i, j].GetComponent<Field>().Direction)
                {
                    
                    if(j < height - 1)
                    {
                        gameObject.GetComponent<Board>().Fields[i, j].GetComponent<Field>().Neighbours.Add(gameObject.GetComponent<Board>().Fields[i, j + 1]);
                    }
                }
                else
                {
                    if (j > 0)
                    {
                        gameObject.GetComponent<Board>().Fields[i, j].GetComponent<Field>().Neighbours.Add(gameObject.GetComponent<Board>().Fields[i, j - 1]);
                    }
                }
            }
        }
    }
}
