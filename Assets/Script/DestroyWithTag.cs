using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithTag : MonoBehaviour
{
    public string triggerTag;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == triggerTag)
        {
            Destroy(gameObject);
        }
    }
}
