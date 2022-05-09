using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;
    public int poolSize;
    public GameObject parcelPrefab;
    public UnityEngine.UI.Text scoreText;
    private Queue<GameObject> objectPool;

    int numberOfParcelsScanned;
    int numberOfGoodParcels;

    // Start is called before the first frame update
    void Start()
    {
        numberOfParcelsScanned = 0;
        numberOfGoodParcels = 0;

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
        numberOfParcelsScanned++;
        if (isGood)
        {
            numberOfGoodParcels++;
        }
        scoreText.text = "Good : "+numberOfGoodParcels
        + "\nBad : " +(numberOfParcelsScanned-numberOfGoodParcels)
        + "\nTotal : " + numberOfParcelsScanned;
    }

    private void RemoveParcelFromBelt(GameObject parcel)
    {
        parcel.SetActive(false);
        BoxItem boxItem = parcel.GetComponent<BoxItem>();
        boxItem.IsGood = Random.value > 0.5f;
        parcel.transform.position = spawnPoint.position;
        parcel.GetComponent<Rigidbody>().Sleep();
        objectPool.Enqueue(parcel);
    }

    private void SpawnParcel()
    {
        GameObject objectToSpawn = objectPool.Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.GetComponent<Rigidbody>().WakeUp();
    }
}
