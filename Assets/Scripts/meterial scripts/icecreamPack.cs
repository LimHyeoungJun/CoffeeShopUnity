using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icecreamPack : MonoBehaviour
{
    public GameObject icecream;
    public GameObject MousePos;


    public void Click()
    {
        var Coffe = Instantiate(icecream, MousePos.transform.position, Quaternion.identity);
        Coffe.transform.SetParent(MousePos.transform, true);
        var pos = new Vector3(0, 1, 0);
        Coffe.transform.localPosition = pos;
        Coffe.transform.localRotation = Quaternion.identity;

    }
}
