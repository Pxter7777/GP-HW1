using System;
using System.Collections.Generic;

public class BacktrackingGenerator : MazeGenAlgo
{
    public BacktrackingGenerator(int w, int h) : base(h, w) { }

    public override int[,] Generate()
    {
        var grid = new int[H, W];
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                grid[i, j] = 1;
            }
        }

        var rand = new Random();
        int crow = rand.Next(0, H/2)* 2 + 1;
        int ccol = rand.Next(0, W/2)* 2 + 1;
        var track = new List<Tuple<int, int>> { Tuple.Create(crow, ccol) };
        grid[crow, ccol] = 0;

        while (track.Count > 0)
        {
            var pos = track[track.Count - 1];
            crow = pos.Item1;
            ccol = pos.Item2;

            var neighbors = FindNeighbors(crow, ccol, grid, true);

            if (neighbors.Count == 0)
            {
                track.RemoveAt(track.Count - 1);
            }
            else
            {
                var next = neighbors[0];
                int nrow = next.Item1;
                int ncol = next.Item2;
                grid[nrow, ncol] = 0;
                grid[(nrow + crow) / 2, (ncol + ccol) / 2] = 0;

                track.Add(next);
            }
        }

        return grid;
    }
}
