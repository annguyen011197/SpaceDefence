using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text score;
    public Button playAgain;
    // Start is called before the first frame update
    public void setScore(float time)
    {
        score.text = $"{time.ToString("0.##")}s";
    }
}
