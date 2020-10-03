using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler
{
    [SerializeField] private CellManager cellManager;

    private float Timer = 0.5f;
    private float currentTime;
    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    public void OnDrag(PointerEventData data)
    {
        if(currentTime < Timer) return;

        bool result;
        if(Mathf.Abs(data.delta.x) > Mathf.Abs(data.delta.y))
        {
            // Horizontal
            if(data.delta.x > 0)
            {
                // Right
                result = cellManager.CatchPlayerInput(1, 0);
            }
            else
            {
                // Left
                result = cellManager.CatchPlayerInput(-1, 0);
            }
        }
        else
        {
            // Vertical
            if(data.delta.y > 0)
            {
                // Up
                result = cellManager.CatchPlayerInput(0, 1);
            }
            else
            {
                // Down
                result = cellManager.CatchPlayerInput(0, -1);
            }
        }

        if(result) currentTime = 0.0f;
    }
}