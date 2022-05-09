using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    // Start is called before the first frame update
    void Awake()
    {
        current = this;
    }

    public event Action<bool> OnScanPass;
    public void ScanPassed(bool IsGood)
    {
        OnScanPass?.Invoke(IsGood);
    }

    public event Action<GameObject> OnReachingEnd;
    public void ReachedEnd(GameObject parcel)
    {
        OnReachingEnd?.Invoke(parcel);
    }
}
