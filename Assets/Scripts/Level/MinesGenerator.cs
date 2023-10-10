using System.Collections.Generic;
using UnityEngine;

public class MinesGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject minePrefab;
    public void GenerateAndPlace(int mapWidth, int mapHeight)
    {
        for (int i = 0; i < mapHeight; i++){
            for (int j = 0; j < mapWidth; j++)
            {
                Vector3 position = new Vector3(0.5f+j, 0, 0.5f+i);
                Instantiate(minePrefab, position, Quaternion.identity, transform);
            }
        }
    }
}
