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
        if (MaterialController.instance.UperCount >= 4)
        {
            MaterialController.instance.UperCount = 1;
        }
        else
        {
            MaterialController.instance.UperCount += 1;
        }
    }

    public void onClickUperLeft()
    {
        if (MaterialController.instance.UperCount <= 1)
        {
            MaterialController.instance.UperCount = 4;
        }
        else
        {
            MaterialController.instance.UperCount -= 1;
        }
    }

    public void onClickUnderRight()
    {
        if (MaterialController.instance.UnderCount >= 3)
        {
            MaterialController.instance.UnderCount = 1;
        }
        else
        {
            MaterialController.instance.UnderCount += 1;
        }
    }

    public void onClickUnderLeft()
    {
        if (MaterialController.instance.UnderCount <= 1)
        {
            MaterialController.instance.UnderCount = 3;
        }
        else
        {
            MaterialController.instance.UnderCount -= 1;
        }
    }
}
