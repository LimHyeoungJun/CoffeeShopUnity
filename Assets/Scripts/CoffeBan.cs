using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class CoffeBan : MonoBehaviour
{
    private Animator animation;
    public GameObject CoffeeBean;
    public GameObject MousePos;

    private void Start()
    {
        animation = GetComponent<Animator>();
    }

   
    public void Click()
    {
       // Debug.Log("ClickCoffe");
        
        animation.SetTrigger("Click");
        var Coffe = Instantiate(CoffeeBean, MousePos.transform.position, Quaternion.identity);
        Coffe.transform.SetParent(MousePos.transform, true);
        var pos = new Vector3(0, 1, 0);
        Coffe.transform.localPosition = pos;
        Coffe.transform.localRotation = Quaternion.identity;

    }
}
