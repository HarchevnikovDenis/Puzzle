using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField] private GameSceneUIController sceneUIController;
    [SerializeField] private List<StaticCell> staticCells;
    [SerializeField] private List<MovingCell> movingCells;

    private void Start()
    {
        for(int i = 0; i < staticCells.Count - 2; i++)
        {
            movingCells[i].transform.position = staticCells[i].transform.position;
            staticCells[i].isUsed = true;
            staticCells[i].MovingCell = movingCells[i];
        }

        movingCells[7].transform.position = staticCells[8].transform.position;
        staticCells[8].isUsed = true;
        staticCells[8].MovingCell = movingCells[7];

        //RandomlyArrangeCells();
    }

    /*private void RandomlyArrangeCells()
    {
        int cellsCount = movingCells.Count - 1;
        while(cellsCount >= 0)
        {
            int randomStaticCellIndex = Random.Range(0, staticCells.Count - 1);
            if(staticCells[randomStaticCellIndex].isUsed == false)
            {
                movingCells[cellsCount].transform.position = staticCells[randomStaticCellIndex].transform.position;
                staticCells[randomStaticCellIndex].isUsed = true;
                staticCells[randomStaticCellIndex].MovingCell = movingCells[cellsCount];
                cellsCount--;
            }
        }
    }*/

    public bool CatchPlayerInput(int horizontal, int vertical)
    {
        StaticCell emptyCell = GetEmptyStaticCell();
        if(emptyCell == null) return false;   // ERROR

        if(horizontal == 1 && emptyCell.LeftCell)
        {
            MoveCell(emptyCell.LeftCell, emptyCell);
            return true;
        }

        if(horizontal == -1 && emptyCell.RightCell)
        {
            MoveCell(emptyCell.RightCell, emptyCell);
            return true;
        }

        if(vertical == 1 && emptyCell.DownCell)
        {
            MoveCell(emptyCell.DownCell, emptyCell);
            return true;
        }

        if(vertical == -1 && emptyCell.UpCell)
        {
            MoveCell(emptyCell.UpCell, emptyCell);
            return true;
        }

        return false;
    }

    private StaticCell GetEmptyStaticCell()
    {
        foreach(StaticCell cell in staticCells)
        {
            if(cell.isUsed == false)
            {
                return cell;
            }
        }

        throw new System.Exception("The system did not find an empty cell");
        return null;
    }

    private void MoveCell(StaticCell startCell, StaticCell endCell)
    {
        startCell.MovingCell.MoveCell(endCell.transform);

        startCell.isUsed = false;
        endCell.isUsed = true;
        endCell.MovingCell = startCell.MovingCell;
        startCell.MovingCell = null;

        if(endCell.MovingCell.ID == endCell.ID)
        {
            if(CheckLevelCompleted())
            {
                // Player WON
                sceneUIController.ShowLevelCompletePanel();
            }
        }
    }

    private bool CheckLevelCompleted()
    {
        if(staticCells[staticCells.Count - 1].MovingCell != null)
        {
            return false;
        }

        for(int i = 0; i < staticCells.Count - 1; i++)
        {
            if(staticCells[i].ID != staticCells[i].MovingCell?.ID)
            {
                return false;
            }
        }

        return true;
    }
}
