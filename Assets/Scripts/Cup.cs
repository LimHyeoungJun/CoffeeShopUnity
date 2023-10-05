using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cup : MonoBehaviour
{
    //Dictionary<List<string>, string> Coffee;
    Dictionary<string, List<string>> coffees = new Dictionary<string, List<string>>();
    List<string> key = new List<string>();
    private void Start()
    {
        coffees["espresso"] = new List<string> { "coffee" };
        coffees["ice_espresso"] = new List<string> { "coffee", "ice" };
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            FindRecipe(coffees, key);
            var foundRecipes = FindRecipe(coffees, key);
            foreach (var recipe in foundRecipes)
            {
                Debug.Log("Found Recipe: " + recipe);
            }
            //foreach (var k in key)
            //{
            //    Debug.Log(k);
            //}
            //Debug.Log(key.Count);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //key.Add(other.gameObject.tag.ToString());
        if (other.CompareTag("mouse"))
            return;
           
        string objectTag = other.gameObject.tag.ToString();
        if (!key.Contains(objectTag))
        {
            key.Add(objectTag);
        }
    }

    static List<string> FindRecipe(Dictionary<string, List<string>> dictionary, List<string> value)
    {
        List<string> keys = new List<string>();

        foreach (var pair in dictionary)
        {
            if (pair.Value.SequenceEqual(value))
            {
                keys.Add(pair.Key);
            }
        }

        return keys;
    }

}
