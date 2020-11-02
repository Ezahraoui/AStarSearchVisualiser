using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Utils;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] twoDimArray;
    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        twoDimArray = new int[width, height];
        //Debug.Log(width + " " + height);

        for(int i=0; i< twoDimArray.GetLength(0); i++)
        {
            for(int j = 0; j < twoDimArray.GetLength(1); j++)
            {
                UtilsClass.CreateWorldText(twoDimArray[i,j].ToString(), null, GetWorldPosition(i,j), 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i+1, j), Color.white, 100f);
            }
        }
    }
    private Vector3 GetWorldPosition(int i, int j)
    {
        return new Vector3(i, j) * cellSize;
    }
}
