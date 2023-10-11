using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[Serializable]
public class DrinkData
{
    public GameObject drink;
    public string menu;
}

public class SpawnCup : MonoBehaviour
{
    public GameObject CupPrefab;
    public Transform CupPosition;
    private List<GameObject> Cups = new List<GameObject>();

    public List<DrinkData> drinks = new List<DrinkData>();


    public void click()
    {
        if(Cups.Count < 1 && GameManager.instance.IsCanCupSpawn)
        {
            Debug.Log("Cup");
            var Cup = Instantiate(CupPrefab, CupPosition.position, Quaternion.identity);
            Cup.transform.SetParent(CupPosition.transform, true);
            Cup.transform.localPosition = Vector3.zero;
            Cup.transform.localRotation = Quaternion.identity;
            Cup.gameObject.SetActive(true);
            Cups.Add(Cup);
        }
    }

    public void PreFabInstantiate(GameObject frefab)
    {
        var es = Instantiate(frefab, CupPosition.position, Quaternion.identity);
        es.transform.SetParent(CupPosition.transform, true);
        es.transform.localPosition = Vector3.zero;
        es.transform.localRotation = Quaternion.identity;
        foreach (var c in Cups)
        {
            Destroy(c);
        }
        Cups.Clear();
        GameManager.instance.IsCanCupSpawn = false;
    }

    public void SpawnCoffee(string coffee)
    {

        foreach(var pair in drinks)
        {
            if(pair.menu.Equals(coffee))
            {
                PreFabInstantiate(pair.drink);
                break;
            }
        }
       
    }
}

