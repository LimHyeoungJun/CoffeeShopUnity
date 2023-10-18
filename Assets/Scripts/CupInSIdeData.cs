using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupInSIdeData : MonoBehaviour
{
    void Update()
    {
        if(GameManager.instance.IsComplet)
        {
            UIManager.instance.DeleteCupInSideMaterial();
        }
    }
}
