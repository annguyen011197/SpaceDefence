using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private const int init = -1;
    public GameObject meteor;
    public MeteorTrigger initTrigger;
    public float distance;
    public int health;
    private Dictionary<int, MeteorTrigger> cached = new Dictionary<int, MeteorTrigger>();
    public TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        initTrigger.SetController(this, init);
        cached.Add(init, initTrigger);
        int range = 0;

        GameObject initGO = initTrigger.gameObject;
        for (int i = 0; i < health / 10; i++)
        {
            GameObject meteorObj = Instantiate(meteor);
            meteorObj.transform.SetParent(transform);
            meteorObj.transform.position = new Vector3(
                getX(range), getY(range),
                initGO.transform.position.z);

            Debug.Log(meteorObj.transform);
            MeteorTrigger trigger = meteorObj.GetComponent<MeteorTrigger>();
            if (trigger != null)
            {
                trigger.SetController(this, i);
                trigger.health = 10;
                cached.Add(i, trigger);
            }
            range++;
        }
        health++;
        AddForceWithAngle(0);
    }

    private float getX(int range)
    {
        Vector3 initGO = initTrigger.gameObject.transform.position;
        int index = range % 4;
        if (index == 0)
        {
            return initGO.x - distance * (range + 1);
        }
        else if (index == 2)
        {
            return initGO.x + distance * (range + 1);
        }
        return initGO.x;
    }

    private float getY(int range)
    {
        Vector3 initGO = initTrigger.gameObject.transform.position;
        int index = range % 4;
        if (index == 3)
        {
            return initGO.y - distance * (range + 1);
        }
        else if (index == 1)
        {
            return initGO.y + distance * (range + 1);
        }
        return initGO.y;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = this.health.ToString();
        Vector3 textPos = text.transform.position;
        textPos.z = 0;
        text.transform.position = textPos;
    }

    public void AddForceWithAngle(float angle)
    {
        Debug.Log("Called");
        angle = (angle % 180);
        if (angle > 90) angle = angle - 90;
        if (angle < -90) angle = angle + 90;
        Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.down;
        this.GetComponent<Rigidbody>().AddForce(dir * 5);
    }

    public void OnHitted(MeteorTrigger trigger, int id)
    {
        if (id != init)
        {
            this.health--;
        }

        text.text = this.health.ToString();
    }

    public void OnPartDestroyed(MeteorTrigger trigger, int id)
    {
        if (id != init)
        {
            if (cached.ContainsKey(id))
            {
                cached[id].Die();
                cached.Remove(id);
            }
        }
        else if (cached.Count == 1)
        {
            cached.Clear();
            Destroy(gameObject);
        }

    }
}
