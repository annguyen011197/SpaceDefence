using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomizer : MonoBehaviour
{
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, sprites.Length - 1);
        this.GetComponent<SpriteRenderer>().sprite = sprites[random];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
