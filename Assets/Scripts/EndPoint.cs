using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Box")
        {
            GameEvents.current.ReachedEnd(other.gameObject);
        }
    }
}
