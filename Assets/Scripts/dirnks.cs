using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirnks : MonoBehaviour
{
    //// Start is called before the first frame update
    //private Collider co;
    //private string drinkTag;
    //void Start()
    //{

    //    co = GetComponent<Collider>();
    //    co.enabled = false;
    //    drinkTag = gameObject.tag;
    //    GameManager.instance.OnCupCollider = false;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if(GameManager.instance.OnCupCollider)
    //    {
    //        co.enabled = true;
    //    }
    //    else if(GameManager.instance.IsDelete)
    //    {
    //        Destroy(gameObject);
    //        GameManager.instance.IsDelete = false;
    //        GameManager.instance.IsComplet = false;
    //        GameManager.instance.IsCanCupSpawn = true;
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if(Input.GetMouseButtonDown(0)) 
    //    {
    //        /////////////////
    //        GameManager.instance.IsGiveDrink = true;
    //        //이때 NPC한테 넘어가야함
    //        //drinkTag;

    //        GameManager.instance.IsCanCupSpawn = true;
    //        ///////////////////
    //        Destroy(gameObject);


    //    }

    //}
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

        if (isMouseOver && Input.GetMouseButtonDown(0))
        {
            GameManager.instance.IsGiveDrink = true;
            GameManager.instance.IsCanCupSpawn = true;
            Destroy(gameObject);
        }

    }

    //private void OnTriggerStay(Collider other)
    //{
    //    // GameManager.instance.OnCupCollider가 참일 때만 로직을 실행
    //    if (GameManager.instance.OnCupCollider && Input.GetMouseButtonDown(0))
    //    {
    //        GameManager.instance.IsGiveDrink = true;
    //        GameManager.instance.IsCanCupSpawn = true;
    //        Destroy(gameObject);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        isMouseOver = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isMouseOver = false;
    }

}
