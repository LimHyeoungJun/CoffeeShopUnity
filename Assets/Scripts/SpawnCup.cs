using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnCup : MonoBehaviour
{
    public GameObject CupPrefab;
    public Transform CupPosition;
    private List<GameObject> Cups = new List<GameObject>();

    public GameObject espressoPre;
    public GameObject ice_espressoPre;
    public GameObject americanoPre;
    public GameObject ice_americanoPre;
    public GameObject latte;
    public GameObject ice_latte;

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
    }

    public void SpawnCoffee(string coffee)
    {
        
        switch (coffee)
        {
            case "espresso":
                PreFabInstantiate(espressoPre);
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                GameManager.instance.IsCanCupSpawn = false;
                break;
            case "ice_espresso":
                PreFabInstantiate(ice_espressoPre);
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                GameManager.instance.IsCanCupSpawn = false;
                break;
            case "americano":
                PreFabInstantiate(americanoPre);
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                GameManager.instance.IsCanCupSpawn = false;
                break;
            case "ice_americano":
                PreFabInstantiate(ice_americanoPre);
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                GameManager.instance.IsCanCupSpawn = false;
                break;

            case "caffelatte":
                PreFabInstantiate(latte);
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                GameManager.instance.IsCanCupSpawn = false;
                break;

            case "ice_caffelatte":
                PreFabInstantiate(ice_latte);
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                GameManager.instance.IsCanCupSpawn = false;
                break;
            default:
                Debug.Log("false");
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                GameManager.instance.IsCanCupSpawn = false;
                break;
            
        }
        
    }

}
