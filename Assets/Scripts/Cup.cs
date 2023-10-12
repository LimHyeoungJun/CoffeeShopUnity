using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cup : MonoBehaviour
{
   
    Dictionary<string, List<string>> coffees = new Dictionary<string, List<string>>();
    List<string> key = new List<string>();

    Dictionary<string, int> price = new Dictionary<string, int>();
    public GameObject CupInDrink;
    private int cupCount = 0;

    private void Awake()
    {
        LoadCoffeeData();
        LoadCostprice();

        gameObject.SetActive(true);
        GameManager.instance.IsComplet = false;
        ////TESTCODE
        //price["water"] = 0;
        //price["coffee"] = 300;
        //price["ice"] = 350;
        ////////////
        CupInDrink.SetActive(false);
    }
    private void LoadCostprice()
    {
        MaterialCostTable costTable = new MaterialCostTable();
        foreach (var pair in costTable.dic)
        {
            price[pair.Key] = pair.Value.cash;
        }
    }
    private void LoadCoffeeData()
    {
        StringTable stringTable = new StringTable();
        foreach (var pair in stringTable.dic)
        {
            List<string> ingredients = new List<string>();
            if (!string.IsNullOrEmpty(pair.Value.ingredientlist1)) ingredients.Add(pair.Value.ingredientlist1);
            if (!string.IsNullOrEmpty(pair.Value.ingredientlist2)) ingredients.Add(pair.Value.ingredientlist2);
            if (!string.IsNullOrEmpty(pair.Value.ingredientlist3)) ingredients.Add(pair.Value.ingredientlist3);
            if (!string.IsNullOrEmpty(pair.Value.ingredientlist4)) ingredients.Add(pair.Value.ingredientlist4);

            ingredients.Sort();
            coffees[pair.Value.name] = ingredients;
        }
    }

    private void Update()
    {
        if (GameManager.instance.IsComplet)
        {
            key.Sort();
            GameManager.instance.Coffee = FindRecipes(coffees, key);
            Debug.Log(GameManager.instance.Coffee);
            GameManager.instance.SpawnCup();
            GameManager.instance.IsComplet = false;
        }
        else if(GameManager.instance.IsDelete) 
        {
            GameManager.instance.DeleteCup();
        }
        switch(cupCount)
        {
            case 1:
                CupInDrink.SetActive(true);
                break;
            case 2:
                CupInDrink.transform.localScale = new Vector3 ( 0.7f, 0.5f, 0.7f );
                break;
            case 3:
                CupInDrink.transform.localScale = new Vector3(0.9f, 0.7f, 0.9f);
                break;
            case 4:
                CupInDrink.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            default: break;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mouse"))
            return;
           
        string objectTag = other.gameObject.tag.ToString();
        if (!key.Contains(objectTag))
        {
            key.Add(objectTag);
            Debug.Log(objectTag);
            int pr = FindPrice(price, objectTag);
            Debug.Log(pr);
            GameManager.instance.PlayerMoney -= pr;
            UIManager.instance.MoneyUpdate(GameManager.instance.PlayerMoney);
            ++cupCount;
        }
    }

    static int FindPrice(Dictionary<string, int> price , string menu)
    {
       int keys = new int();

        foreach (var pair in price)
        {
            if (pair.Key.SequenceEqual(menu))
            {
                keys = pair.Value;
            }
        }

        return keys;
    }
    static string FindRecipes(Dictionary<string, List<string>> dictionary, List<string> value)
    {
        string key = null;

        foreach (var pair in dictionary)
        {
            if (pair.Value.SequenceEqual(value))
            {
               key = pair.Key;
            }
        }

        return key;
    }

    

    
}
