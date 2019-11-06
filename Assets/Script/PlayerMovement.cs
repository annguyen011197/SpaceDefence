using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigi;
    public float speed;
    public float xMax;
    public float xMin;
    void Awake()
    {
        rigi = this.GetComponent<Rigidbody>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rigi.velocity = movement * speed;

        rigi.position = new Vector3(
            Mathf.Clamp(rigi.position.x, xMin, xMax),
            rigi.position.y,
            0f
        );
    }
}
