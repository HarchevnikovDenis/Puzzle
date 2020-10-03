using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCell : Cell
{
    public void MoveCell(Transform point_B)
    {
        transform.position = point_B.position;
    }
}
