using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private int x;
    private int y;
    private bool isOccupied;
    private bool direction;
    private List<GameObject> neighbours = new List<GameObject>();

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    public bool IsOccupied { get => isOccupied; set => isOccupied = value; }
    public bool Direction { get => direction; set => direction = value; }
    public List<GameObject> Neighbours { get => neighbours; set => neighbours = value; }

    public void OnMouseDown()
    {
        Debug.Log(X.ToString() + ", " + Y.ToString());
    }
}
