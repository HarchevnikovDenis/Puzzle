using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField] private List<StaticCell> staticCells;
    [SerializeField] private List<MovingCell> movingCells;

    private void Start()
    {
        RandomlyArrangeCells();
    }

    private void RandomlyArrangeCells()
    {
        int cellsCount = movingCells.Count - 1;
        while(cellsCount >= 0)
        {
            int randomStaticCellIndex = Random.Range(0, staticCells.Count - 1);
            if(staticCells[randomStaticCellIndex].isUsed == false)
            {
                movingCells[cellsCount].transform.position = staticCells[randomStaticCellIndex].transform.position;
                staticCells[randomStaticCellIndex].isUsed = true;
                cellsCount--;
            }
        }
    }
}
