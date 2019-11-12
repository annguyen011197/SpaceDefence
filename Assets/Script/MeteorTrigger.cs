using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTrigger : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    private MeteorController meteorController;
    private int id;
    private bool isDestroyed = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetController(MeteorController controller, int id)
    {
        this.meteorController = controller;
        this.id = id;
    }

    public void Die()
    {
        isDestroyed = true;
        Animator anim = this.GetComponent<Animator>();
        anim.enabled = true;
        Destroy(gameObject, anim.GetCurrentAnimatorClipInfo(0).Length);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isDestroyed) return;
        Debug.Log("On hitted " + id);
        if (other.gameObject.tag == "bullet")
        {
            health--;
            this.meteorController.OnHitted(this, this.id);
            if (health <= 0)
            {
                this.meteorController.OnPartDestroyed(this, id);
            }
        }
        if (other.gameObject.tag == "player")
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("gameController");
            if (objects.Length > 0)
            {
                GameObject obj = objects[0];
                if (obj.GetComponent<GameController>() != null)
                {
                    obj.GetComponent<GameController>().DestroyPlayer();
                }
            }

        }

    }


}

