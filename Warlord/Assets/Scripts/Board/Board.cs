using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private GameObject[,] fields;

    public GameObject[,] Fields { get => fields; set => fields = value; }

    public void InitBoard(byte width, byte height)
    {
        Fields = new GameObject[width, height];
    }
}
