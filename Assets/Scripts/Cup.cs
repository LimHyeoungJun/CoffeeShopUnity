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
    private bool iscom = false;

    public GameObject espressoPre;
    public GameObject ice_espressoPre;
    public GameObject americanoPre;
    public GameObject ice_americanoPre;


    private void Awake()
    {
        //testcode
        List<string> list = new List<string>{ "coffee" };
        list.Sort();
        coffees["espresso"] = list;

        list = new List<string> { "coffee","ice" };
        list.Sort();
        coffees["ice_espresso"] = list;

        list = new List<string> { "coffee", "water" };
        list.Sort();
        coffees["americano"] = list;

        list = new List<string> { "coffee", "water", "ice" };
        list.Sort();
        coffees["ice_americano"] = list;
        //
        iscom = false;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F) && !iscom)
        //{
        //    key.Sort();
        //    //var foundRecipes = FindRecipe(coffees, key);
        //    //foreach (var recipe in foundRecipes)
        //    //{
        //    //    Debug.Log("Found Recipe: " + recipe);
        //    //}

        //    //var foundRecipe = FindRecipes(coffees, key);
        //    //Debug.Log("Found Recipe: " + foundRecipe);
        //    iscom = true;
        //}
        //if (iscom)
        //{
           
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
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

    public void ComplitRecipe()
    {
        key.Sort();
        switch (FindRecipes(coffees, key))
        {
            case "espresso":
                Debug.Log("espresso");
                var es = Instantiate(espressoPre, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                iscom = false;
                break;
            case "ice_espresso":
                Debug.Log("ice_espresso");
                var icees = Instantiate(ice_espressoPre, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                iscom = false;
                break;
            case "americano":
                Debug.Log("americano");
                var am = Instantiate(americanoPre, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                iscom = false;
                break;
            case "ice_americano":
                Debug.Log("ice_americano");
                var iceam = Instantiate(ice_americanoPre, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                iscom = false;
                break;
            default:
                Debug.Log("false");
                gameObject.SetActive(false);
                iscom = false;
                break;
        }
    }

}
