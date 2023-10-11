using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMoveButton : MonoBehaviour
{
    public Button Cooking;
    public Button Odering;
    public CameraMove mainCam;

    public void OnClickCook()
    {
        mainCam.CamMove2();
        
        UIManager.instance.button1On();
    }
    public void OnClickOder()
    {
        mainCam.CamMove1();
        UIManager.instance.button2On();
        GameManager.instance.OnCupCollider = true;
    }
    public void onClickComplit()
    {
        GameManager.instance.IsComplet = true;
    }
    public void onClickUperRight()
    {
        
    }
    public void onClickUperLeft()
    {

    }
    public void onClickUnderRight()
    {

    }
    public void onClickUnderLeft()
    {

    }
}
