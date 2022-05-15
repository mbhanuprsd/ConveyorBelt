using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;
    public int poolSize;
    public GameObject parcelPrefab;
    private Queue<GameObject> objectPool;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject box;
        BoxItem boxItem;
        objectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            box = Instantiate(parcelPrefab, spawnPoint.position, spawnPoint.rotation);
            boxItem = box.GetComponent<BoxItem>();
            boxItem.boxId = i;
            boxItem.IsGood = Random.value > 0.5f;
            box.SetActive(false);
            objectPool.Enqueue(box);
        }

        SpawnParcel();

        GameEvents.current.OnScanPass += ScannedParcel;
        GameEvents.current.OnReachingEnd += RemoveParcelFromBelt;
    }

    private void ScannedParcel(bool isGood)
    {
        SpawnParcel();
    }

    private void RemoveParcelFromBelt(GameObject parcel)
    {
        parcel.SetActive(false);
        parcel.GetComponent<Rigidbody>().Sleep();
        objectPool.Enqueue(parcel);
    }

    private void SpawnParcel()
    {
        GameObject objectToSpawn = objectPool.Dequeue();
        BoxItem boxItem = objectToSpawn.GetComponent<BoxItem>();
        boxItem.IsGood = Random.value > 0.5f;
        objectToSpawn.transform.position = spawnPoint.position;
        objectToSpawn.transform.rotation = Quaternion.Euler(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359));
        objectToSpawn.SetActive(true);
        objectToSpawn.GetComponent<Rigidbody>().WakeUp();
    }
}
