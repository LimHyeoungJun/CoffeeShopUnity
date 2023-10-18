using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class CoffeBan : MonoBehaviour
{
    
    public GameObject CoffeeBean;
    public GameObject MousePos;

   
   
    public void Click()
    {
      
        
        var Coffe = Instantiate(CoffeeBean, MousePos.transform.position, Quaternion.identity);
        Coffe.transform.SetParent(MousePos.transform, true);
        var pos = new Vector3(0, 1, 0);
        Coffe.transform.localPosition = pos;
        Coffe.transform.localRotation = Quaternion.identity;

    }
}
