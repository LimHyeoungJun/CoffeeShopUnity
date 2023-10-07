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


    private void Awake()
    {
        LoadCoffeeData();
        gameObject.SetActive(true);
        GameManager.instance.IsComplet = false;
        //TESTCODE
        price["water"] = 0;
        price["coffee"] = 300;
        price["ice"] = 350;
        //////////
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
            GameManager.instance.SpawnCup();
            GameManager.instance.IsComplet = false;
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
            GameManager.instance.PlayerMoney -= pr;
            UIManager.instance.MoneyUpdate(GameManager.instance.PlayerMoney);
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
