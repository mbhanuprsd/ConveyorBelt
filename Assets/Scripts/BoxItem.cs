using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItem : MonoBehaviour
{
    public int boxId;
    public bool IsGood;

    void OnEnable()
    {
        MeshRenderer meshRenderer =  gameObject.GetComponent<MeshRenderer>();
        Material boxMaterial = meshRenderer.material;
        boxMaterial.color = new Color((IsGood ? 1 : 0), 1, 1, 1);
        meshRenderer.material = boxMaterial;
    }
}
