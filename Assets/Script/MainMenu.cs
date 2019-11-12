using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject level;
    public void PlayButtonClicked()
    {
        mainMenu.SetActive(false);
        level.SetActive(true);

    }
}
