using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class h_syrupBottle : MonoBehaviour
{
    public GameObject h_syrup;
    public GameObject MousePos;


    public void Click()
    {
        var Coffe = Instantiate(h_syrup, MousePos.transform.position, Quaternion.identity);
        Coffe.transform.SetParent(MousePos.transform, true);
        var pos = new Vector3(0, 1, 0);
        Coffe.transform.localPosition = pos;
        Coffe.transform.localRotation = Quaternion.identity;

    }
}
