using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public int mazeWidth = 33;
    public int mazeHeight = 33;
    
    void Start()
    {
        MazeGenerator maze = transform.Find("Maze").GetComponent<MazeGenerator>();
        maze.GenerateAndPlace(mazeWidth, mazeHeight, 31337);
        //mines
        Transform minesTransform = transform.Find("Mines");
        MineField mines = minesTransform.GetComponent<MineField>();
        mines.Initialize(mazeWidth*2, mazeHeight*2, 30, 31337);
        //
        //transform.Find("birdView").position = new Vector3(mazeWidth, 20, mazeHeight);
    }

}
