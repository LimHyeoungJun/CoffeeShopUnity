using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoard : MonoBehaviour
{

    //private bool isMouseOver = false;

    //private void Update()
    //{
    //    if (isMouseOver && Input.GetMouseButtonDown(0))
    //    {
    //        UIManager.instance.CheckMenuBoard.SetActive(true);
    //        SoundManager.instance.PlayClickButtonSound();
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    isMouseOver = true;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    isMouseOver = false;
    //}
    private void OnTriggerStay(Collider other)
    {
        UIManager.instance.CheckMenuBoard.SetActive(true);
        SoundManager.instance.PlayClickButtonSound();
    }
}
