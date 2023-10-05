using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBox : MonoBehaviour
{
    public GameObject icePrefab;
    public GameObject MousePos;

    public void Click()
    {
        var Ice = Instantiate(icePrefab, MousePos.transform.position, Quaternion.identity);
        Ice.transform.SetParent(MousePos.transform, true);
        var pos = new Vector3(0, 1, 0);
        Ice.transform.localPosition = pos;
        Ice.transform.localRotation = Quaternion.identity;
    }


}
