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
    }

    // Update is called once per frame
    void Update()
    {
        if(true)
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
            //이때 NPC한테 넘어가야함
            //drinkTag;
            ///////////////////
            Destroy(gameObject);

            
        }

    }


}
