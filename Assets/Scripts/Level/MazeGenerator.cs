using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wallPrefab, borderPrefab, goalPrefab;
    //public int mazeWidth = 33;
    //public int mazeHeight = 33;
    //public float spacing = 1.1f;
    public void GenerateAndPlace(int mazeWidth, int mazeHeight, int seed)
    {
        Vector3 position;
        BacktrackingGenerator generator = new BacktrackingGenerator(mazeWidth, mazeHeight, seed);
        int[,] maze = generator.Generate();
        // Build X direction walls
        for (int i = 0; i < maze.GetLength(0); i=i+2){
            for (int j = 1; j < maze.GetLength(1); j=j+2)
            {
                //if(i==maze.GetLength(0)-1&&j==maze.GetLength(1)-2)
                //    continue;
                if (maze[i, j] == 1)
                {
                    position = new Vector3(j, 1, i);
                    if(i==0||i==maze.GetLength(0)-1)// is border
                        Instantiate(borderPrefab, position, Quaternion.identity, transform);
                    else
                        Instantiate(wallPrefab, position, Quaternion.identity, transform);
                }
            }
        }
        //transform.localRotation = Quaternion.Euler(0, 90, 0);
        for (int j = 0; j < maze.GetLength(1); j=j+2){
            for (int i = 1; i < maze.GetLength(0); i=i+2)
            {
                if(i==maze.GetLength(0)-2&&j==maze.GetLength(1)-1)
                    continue;
                if (maze[i, j] == 1)
                {
                    position = new Vector3(j, 1, i);
                    if(j==0||j==maze.GetLength(1)-1)// is border
                        Instantiate(borderPrefab, position, Quaternion.Euler(0, 90, 0), transform);
                    else
                        Instantiate(wallPrefab, position, Quaternion.Euler(0, 90, 0), transform);
                }
            }
        }
        position = new Vector3(maze.GetLength(1), -0.5f,maze.GetLength(0)-2);
        Instantiate(goalPrefab, position, Quaternion.identity, transform);
        
    }
}
