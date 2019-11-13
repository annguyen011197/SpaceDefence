using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Resolution
{
    public int height;
    public int width;
}
public class OptionMenu : MonoBehaviour
{
    public Toggle fullscreenTgl;
    public Resolution[] resolutions;
    public Text resLabel;

    private int currentResIndex = 0;

    private void Start()
    {
        for (var i = 0; i < resolutions.Length; i++)
        {
            var res1 = new Resolution();
            res1.width = resolutions[i].width;
            res1.height = res1.width / 9 * 16;
            resolutions[i] = res1;
        }
        updateLabel();
    }
    public void ResLeft()
    {
        currentResIndex--;
        if (currentResIndex < 0)
        {
            currentResIndex = resolutions.Length - 1;
        }
        updateLabel();
    }

    public void ResRight()
    {
        currentResIndex++;
        if (currentResIndex >= resolutions.Length)
        {
            currentResIndex = 0;
        }
        updateLabel();
    }

    private void updateLabel()
    {
        resLabel.text = string.Format("{0}x{1}", resolutions[currentResIndex].width, resolutions[currentResIndex].height);
    }

    public void ApplyGraphics()
    {
        Screen.fullScreen = fullscreenTgl.isOn;

        Screen.SetResolution(resolutions[currentResIndex].width, resolutions[currentResIndex].height,
        fullscreenTgl.isOn);
        this.gameObject.SetActive(false);
    }
}
