using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chocolatePack : MonoBehaviour
{
    public GameObject chocolate;
    public GameObject MousePos;


    public void Click()
    {
        var Coffe = Instantiate(chocolate, MousePos.transform.position, Quaternion.identity);
        Coffe.transform.SetParent(MousePos.transform, true);
        var pos = new Vector3(0, 1, 0);
        Coffe.transform.localPosition = pos;
        Coffe.transform.localRotation = Quaternion.identity;

    }
}
