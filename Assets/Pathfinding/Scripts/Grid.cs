using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Utils;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPos;
    private int[,] twoDimArray;
    private TextMesh[,] debugTextArray;
    public Grid(int width, int height, float cellSize, Vector3 originPos)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPos = originPos;
        twoDimArray = new int[width, height];
        //Debug.Log(width + " " + height);
        debugTextArray = new TextMesh[width, height];

        for (int i=0; i< twoDimArray.GetLength(0); i++)
        {
            for(int j = 0; j < twoDimArray.GetLength(1); j++)
            {
                debugTextArray[i,j] = UtilsClass.CreateWorldText(twoDimArray[i,j].ToString(), null, GetWorldPosition(i,j) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i+1, j), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

        setValue(2, 1, 56);
    }
    private Vector3 GetWorldPosition(int i, int j)
    {
        return new Vector3(i, j) * cellSize + originPos;
    }
    public void setValue(int i, int j, int value)
    {
        if(i >=0 && i>=0 && i <width && j < height)
        {
            twoDimArray[i, j] = value;
            debugTextArray[i, j].text = twoDimArray[i, j].ToString();
        }
    }

    private Vector3 getWorldPos(int i , int j)
    {
        return new Vector3(i, j) * cellSize;
    }

    private void getCoordinates(Vector3 worldPos, out int i, out int j)
    {
        i = Mathf.FloorToInt((worldPos - originPos).x / cellSize);
        j = Mathf.FloorToInt((worldPos - originPos).y / cellSize);
    }

      public void setValue(Vector3 worldPos, int value)
    {
        int i, j;
        getCoordinates(worldPos, out i, out j);
        setValue(i, j, value);
    }
        public int getValue(int i, int j)
        {
            if(i>=0 && j>=0 && i<width && j < height)
        {
            return twoDimArray[i, j];
        } else
        {
            return 0;
        }
        }

    public int getValue(Vector3 worldPos)
    {
        int i, j;
        getCoordinates(worldPos, out i, out j);
        return getValue(i, j);
    }
}
