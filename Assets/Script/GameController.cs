using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Spawner
{
    public string name;
    public MeteorSpwaner spwaner;
}
public class GameController : MonoBehaviour
{
    public PlayerMovement player;
    public Text textScoreUI;
    public GameOver gameOver;
    private float time = 0f;

    public Spawner[] spawners;
    public int delayTime;
    private int currIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActiveSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isDie)
        {
            time += Time.deltaTime;
            textScoreUI.text = $"<color=orange><b>Time:</b></color> <i>{time.ToString("0.##")}s</i>";
        }
        else
        {
            gameOver.gameObject.SetActive(true);
            gameOver.setScore(time);
        }
    }

    void PassGame()
    {
        player.isDie = true;
    }

    private IEnumerator ActiveSpawn()
    {
        foreach (var item in spawners)
        {
            item.spwaner.gameObject.SetActive(true);
            yield return new WaitForSeconds(delayTime);
        }
        PassGame();
    }

    public void DestroyPlayer()
    {
        player.Die();
    }
}
