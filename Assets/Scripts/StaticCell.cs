using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCell : MonoBehaviour
{
    [SerializeField] private StaticCell leftCell, rightCell, upCell, downCell;
    public StaticCell LeftCell => leftCell;
    public StaticCell RightCell => rightCell;
    public StaticCell UpCell => upCell;
    public StaticCell DownCell => downCell;
    public bool isUsed { get; set;}
    public MovingCell MovingCell { get; set;}
}
