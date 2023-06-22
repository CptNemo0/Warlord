using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    [SerializeField] public byte width;
    [SerializeField] public byte height;
    [SerializeField] public GameObject board;

    private void InitBoard()
    {
        board.GetComponent<Board>().InitBoard(width, height);
    }

    private void GenerateBoard()
    {
        board.GetComponent<CreateBoard>().GenerateBoard(width, height);
        board.GetComponent<CreateBoard>().PrepareFields(width, height);
        board.GetComponent<CreateBoard>().AssignNeighbours(width, height);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitBoard();
        GenerateBoard();
    }
}
