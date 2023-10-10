using System;
using System.Collections.Generic;

public abstract class MazeGenAlgo
{
    protected int h, w, H, W;
    protected int seed;
    protected System.Random rand;
    public MazeGenAlgo(int h, int w, int seed)
    {
        if (w < 3 || h < 3)
        {
            throw new ArgumentException("Mazes cannot be smaller than 3x3.");
        }

        this.h = h;
        this.w = w;
        this.H = (2 * h) + 1;
        this.W = (2 * w) + 1;
        this.seed = seed;
        this. rand = new System.Random(seed);
    }

    public abstract int[,] Generate();

    protected List<Tuple<int, int>> FindNeighbors(int r, int c, int[,] grid, bool isWall)
    {
        var ns = new List<Tuple<int, int>>();

        if (r > 1 && grid[r - 2, c] == (isWall ? 1 : 0)) ns.Add(Tuple.Create(r - 2, c));
        if (r < H - 2 && grid[r + 2, c] == (isWall ? 1 : 0)) ns.Add(Tuple.Create(r + 2, c));
        if (c > 1 && grid[r, c - 2] == (isWall ? 1 : 0)) ns.Add(Tuple.Create(r, c - 2));
        if (c < W - 2 && grid[r, c + 2] == (isWall ? 1 : 0)) ns.Add(Tuple.Create(r, c + 2));

        
        int n = ns.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            var value = ns[k];
            ns[k] = ns[n];
            ns[n] = value;
        }

        return ns;
    }
}
