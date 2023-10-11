using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class v_syrupBottle : MonoBehaviour
{
    public GameObject v_syrup;
    public GameObject MousePos;


    public void Click()
    {
        var Coffe = Instantiate(v_syrup, MousePos.transform.position, Quaternion.identity);
        Coffe.transform.SetParent(MousePos.transform, true);
        var pos = new Vector3(0, 1, 0);
        Coffe.transform.localPosition = pos;
        Coffe.transform.localRotation = Quaternion.identity;

    }
}
