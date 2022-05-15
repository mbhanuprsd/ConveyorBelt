using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Text))]
public class ScoreManager : MonoBehaviour
{
    int numberOfParcelsScanned;
    int numberOfGoodParcels;
    // Start is called before the first frame update
    void Start()
    {
        numberOfParcelsScanned = 0;
        numberOfGoodParcels = 0;

        GameEvents.current.OnScanPass += ScannedParcel;
    }

    private void ScannedParcel(bool isGood)
    {
        numberOfParcelsScanned++;
        if (isGood)
        {
            numberOfGoodParcels++;
        }
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Good : "+numberOfGoodParcels
        + "\nBad : " +(numberOfParcelsScanned-numberOfGoodParcels)
        + "\nTotal : " + numberOfParcelsScanned;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
