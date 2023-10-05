using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milkBottle : MonoBehaviour
{
    public GameObject milk;
    public GameObject MousePos;

    public void Click()
    {
        
        var Coffe = Instantiate(milk, MousePos.transform.position, Quaternion.identity);
        Coffe.transform.SetParent(MousePos.transform, true);
        var pos = new Vector3(0, 1, 0);
        Coffe.transform.localPosition = pos;
        Coffe.transform.localRotation = Quaternion.identity;

    }
}
