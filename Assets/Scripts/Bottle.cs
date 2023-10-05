using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public GameObject waterPrefab;
    public GameObject MousePosition;


    public void Click()
    {
        var water = Instantiate(waterPrefab, MousePosition.transform.position, Quaternion.identity);
        water.transform.SetParent(MousePosition.transform, true);
        var pos = new Vector3(0,1,0);
        water.transform.localPosition = pos;
        water.transform.localRotation = Quaternion.identity;
    }
}
