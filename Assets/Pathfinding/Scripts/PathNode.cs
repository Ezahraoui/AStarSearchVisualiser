using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    private Grid<PathNode> grid;
    int i;
    int j;

    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode cameFromNode;
    public PathNode(Grid<PathNode> grid, int i, int j)
    {
        this.grid = grid;
        this.i = i;
        this.j = j;
    }

    public override string ToString()
    {
        return i + "," + j;
    }
}
