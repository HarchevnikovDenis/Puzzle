using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUIController : UIController
{
    [SerializeField] private GameObject levelCompletePanel;

    public void ShowLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);
    }
}
