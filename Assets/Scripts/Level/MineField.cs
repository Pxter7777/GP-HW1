using System.Collections.Generic;
using System;
using UnityEngine;

public class MineField : MonoBehaviour
{
    private int width;
    private int height;
    private int bombCount;
    private int[,] field, hint;
    private System.Random random;
    private Texture2D[] mineTextures;
    public void Initialize(int width, int height, int bombCount, int seed)
    {
        this.width = width;
        this.height = height;
        this.field = new int[width, height];
        this.hint = new int[width, height];
        this.bombCount = bombCount;
        this.random = new System.Random(seed);
        preLoadPic();
        GenerateField();
        PrintField();
    }
    private void preLoadPic(){
        // 預加載圖片
        mineTextures = Resources.LoadAll<Texture2D>("Textures/Mines");

        // 使用其中一個紋理
        //GetComponent<Renderer>().material.mainTexture = mineTextures[index];
    }
    public GameObject minePrefab;
/*    public void GenerateAndPlace(int mapWidth, int mapHeight, int bombCount)
    {
        for (int i = 0; i < mapHeight; i++){
            for (int j = 0; j < mapWidth; j++)
            {
                Vector3 position = new Vector3(0.5f+j, 0, 0.5f+i);
                Instantiate(minePrefab, position, Quaternion.identity, transform);
            }
        }
    }
*/
    static int SafeGet(int[,] array, int i, int j, int defaultValue = 0)
    {
        if (i >= 0 && i < array.GetLength(0) && j >= 0 && j < array.GetLength(1))
        {
            return array[i, j];
        }
        return defaultValue;
    }
    private void GenerateField()
    {
        List<Tuple<int, int>> noBombPositions = new List<Tuple<int, int>>{
            Tuple.Create(0, 0),
            Tuple.Create(0, 1),
            Tuple.Create(1, 0),
            Tuple.Create(1, 1),
        };
        
        int placedBombs = 0;
        
        while (placedBombs < bombCount)
        {
            int x = random.Next(width);
            int y = random.Next(height);

            // 檢查這個位置是否已經有地雷或者不應該放置地雷
            if (field[x, y] == 0 && !noBombPositions.Contains(new Tuple<int, int>(x, y)))
            {
                field[x, y] = 1;
                placedBombs++;
            }
        }
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++){
                if(field[i, j] == 1)
                    hint[i,j] = 8;
                else{
                    hint[i,j]= SafeGet(field, i-1, j-1) +
                               SafeGet(field, i-1, j) +
                               SafeGet(field, i-1, j+1) +
                               SafeGet(field, i, j-1) +
                               SafeGet(field, i, j+1) +
                               SafeGet(field, i+1, j-1) +
                               SafeGet(field, i+1, j) +
                               SafeGet(field, i+1, j+1);
                }
                
            }
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++){
                Vector3 position = new Vector3(0.5f+i, 0, 0.5f+j);
                GameObject grid = Instantiate(minePrefab, position, Quaternion.identity, transform);
                //change style
                //grid.GetComponent<Renderer>().material.mainTexture = mineTextures[9];
                grid.GetComponent<MineGrid>().setStepOnTexture(mineTextures[hint[i,j]]);
            }
        
    }
    public void PrintField()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Console.Write(field[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
