using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);

        Renderer renderer = this.GetComponent<Renderer>();
        renderer.material.mainTextureOffset = offset;
    }
}
