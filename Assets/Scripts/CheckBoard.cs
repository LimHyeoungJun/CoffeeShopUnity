using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoard : MonoBehaviour
{
    

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetMouseButtonDown(0))
        {
            UIManager.instance.CheckMenuBoard.SetActive(true);
        }
    }
}
