using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirnks : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider co;
    private string drinkTag;
    void Start()
    {
       
        co = GetComponent<Collider>();
        co.enabled = false;
        drinkTag = gameObject.tag;
        GameManager.instance.OnCupCollider = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.OnCupCollider)
        {
            co.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            /////////////////
            GameManager.instance.IsGiveDrink = true;
            //�̶� NPC���� �Ѿ����
            //drinkTag;

            GameManager.instance.IsCanCupSpawn = true;
            ///////////////////
            Destroy(gameObject);

            
        }

    }


}
