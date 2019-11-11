using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    public float changeTime = 0.5f; // 10second
    private float nextFire = 0.0f;

    private float initTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - initTime > changeTime)
        {
            animator.SetBool("Change", true);
        }
        transform.Translate(transform.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}

