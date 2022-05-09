using UnityEngine;

public class Scanner : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Box")
        {
            BoxItem boxItem =other.gameObject.GetComponent<BoxItem>();
            GameEvents.current.ScanPassed(boxItem.IsGood);
        }
    }
}
