using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    private Rigidbody rgbody;
    // Start is called before the first frame update
    void Start()
    {
        rgbody = this.GetComponent<Rigidbody>();
        if (rgbody != null)
        {
            rgbody.angularVelocity = Random.insideUnitSphere * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rgbody == null)
        {
            transform.Rotate(0, 0, speed);
        }

    }
}
