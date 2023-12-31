using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirnks : MonoBehaviour
{
  
    private Collider co;
    private string drinkTag;
    private bool isMouseOver = false;

    void Start()
    {
        co = GetComponent<Collider>();
        co.enabled = false;
        drinkTag = gameObject.tag;
        GameManager.instance.OnCupCollider = false;
    }

    void Update()
    {
        if (GameManager.instance.OnCupCollider)
        {
            co.enabled = true;
        }
        else if (GameManager.instance.IsDelete)
        {
            Destroy(gameObject);
            GameManager.instance.IsDelete = false;
            GameManager.instance.IsComplet = false;
            GameManager.instance.IsCanCupSpawn = true;
        }
        //Debug.Log(GameManager.instance.OnCupCollider);
        if(!GameManager.instance.OnCupCollider) 
        {
            co.enabled= false;
        }


    }

   
    private void OnTriggerStay(Collider other)
    {
        GameManager.instance.IsGiveDrink = true;
        GameManager.instance.IsCanCupSpawn = true;
        Destroy(gameObject);
    }

}
