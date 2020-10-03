using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MusicToggle : MonoBehaviour
{
    [SerializeField] private Toggle musicToggle;

    private void Start()
    {
        musicToggle.isOn = AudioSourceController.audio.music > 0;
    }

    public void TapToggle(bool isActive)
    {
        if(isActive)
        {
            AudioSourceController.audio.music = 1;
        }
        else
        {
            AudioSourceController.audio.music = 0;
        }
    }
}
