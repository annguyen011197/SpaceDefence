using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnerOption
{
    public int[] healRange;
    public float angle;
    public int size;
    public int distance;
}
public class MeteorSpwaner : MonoBehaviour
{
    public SpawnerOption option;
    public MeteorController meteor;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < option.size; i++)
        {
            GameObject gameObject = Instantiate(meteor.gameObject);
            gameObject.transform.position = randomPostion();
            gameObject.GetComponent<MeteorController>().AddForceWithAngle(option.angle);
            yield return new WaitForSeconds(1);
        }
    }

    Vector3 randomPostion()
    {
        float randomX = Random.Range(transform.position.x - option.distance, transform.position.x + option.distance);
        float randomY = Random.Range(transform.position.y - option.distance, transform.position.y + option.distance);
        return new Vector3(randomX, randomY, transform.position.z);
    }
}
