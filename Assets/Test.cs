using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Utils;

public class Test : MonoBehaviour
{
    private Grid grid;
    void Start()
    {
        Grid grid = new Grid(4, 2, 10f);

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.setValue(UtilsClass.GetMouseWorldPosition(),56);
        }
    }
}
