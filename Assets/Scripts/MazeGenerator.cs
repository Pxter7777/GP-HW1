using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public int mazeWidth = 33;
    public int mazeHeight = 33;
    public float spacing = 1.1f;

    void Start()
    {
        BacktrackingGenerator generator = new BacktrackingGenerator(mazeWidth, mazeHeight);
        int[,] maze = generator.Generate();

        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                if (maze[i, j] == 1)
                {
                    Vector3 position = new Vector3(j * spacing, 0, i * spacing);
                    Instantiate(wallPrefab, position, Quaternion.identity, transform);
                }
            }
        }
    }
}
