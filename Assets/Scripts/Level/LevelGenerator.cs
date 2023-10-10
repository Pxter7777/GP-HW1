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
        maze.GenerateAndPlace(mazeWidth, mazeHeight);
        MinesGenerator mines = transform.Find("Mines").GetComponent<MinesGenerator>();
        mines.GenerateAndPlace(mazeWidth*2, mazeHeight*2);
        transform.Find("birdView").position = new Vector3(mazeWidth, 20, mazeHeight);
    }

}
