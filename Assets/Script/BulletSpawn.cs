using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(InitBullet), 1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitBullet()
    {
        List<Vector3> spawns = shotSpawns();
        foreach (Vector3 item in spawns)
        {
            GameObject gameObj = Instantiate(shot);
            gameObj.transform.position = item;
        }
    }

    private List<Vector3> shotSpawns()
    {
        List<Vector3> res = new List<Vector3>();

        if (level >= 1 && level <= 4)
        {
            int butlletSize = level + 1;
            float distance = 0.15f;
            for (int i = 0; i < butlletSize / 2; i++)
            {
                res.Add(new Vector3(shotSpawn.position.x - distance * (butlletSize / 2 - i), shotSpawn.position.y, shotSpawn.position.z));
            }
            if (butlletSize % 2 != 0)
            {
                res.Add(new Vector3(shotSpawn.position.x, shotSpawn.position.y, shotSpawn.position.z));
            }
            for (int i = 0; i < butlletSize / 2; i++)
            {
                res.Add(new Vector3(shotSpawn.position.x + distance * (i + 1), shotSpawn.position.y, shotSpawn.position.z));
            }
        }
        else
        {
            res.Add(shotSpawn.position);
        }
        return res;
    }


}
