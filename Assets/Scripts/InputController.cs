using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler
{
    [SerializeField] private CellManager cellManager;

    // DEBUG
    private float Timer = 0.5f;
    private float currentTime;
    private void Update()
    {
        if(currentTime < Timer)
        {
            currentTime += Time.deltaTime;
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0)
        {
            if(cellManager.CatchPlayerInput((int)horizontal, 0))
            {
                currentTime = 0.0f;
                return;
            }
        }

        if(vertical != 0)
        {
            if(cellManager.CatchPlayerInput(0, (int)vertical))
            {
                currentTime = 0.0f;
                return;
            }
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if(data.delta.x > data.delta.y)
        {
            // Horizontal
            if(data.delta.x > 0)
            {
                // Right
                cellManager.CatchPlayerInput(1, 0);
            }
            else
            {
                // Left
                cellManager.CatchPlayerInput(-1, 0);
            }
        }
        else
        {
            // Vertical
            if(data.delta.y > 0)
            {
                // Up
                cellManager.CatchPlayerInput(0, 1);
            }
            else
            {
                // Down
                cellManager.CatchPlayerInput(0, -1);
            }
        }
    }
}