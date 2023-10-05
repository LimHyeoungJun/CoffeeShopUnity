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


    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.E)) 
    //    {
    //        Debug.Log("Delete");
    //        foreach(var c in Cups) 
    //        {
    //            Destroy(c);
    //        }
    //        Cups.Clear();
            
    //    }
    //}

    public void click()
    {
        Debug.Log("Cup");
        
        if(Cups.Count < 1)
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

    public void SpawnCoffee(string coffee)
    {
        
        switch (coffee)
        {
            case "espresso":
                Debug.Log("espresso");
                /////////////TEST///////////////
                StringTable table = new StringTable();
                StringTable.Data data = table.GetString("espresso");
                if (data != null)
                {
                    string dayForEspresso = data.day;
                    Debug.Log(dayForEspresso);
                }
                //////////////////////////
                var es = Instantiate(espressoPre, CupPosition.position, Quaternion.identity);
                es.transform.SetParent(CupPosition.transform, true);
                es.transform.localPosition = Vector3.zero;
                es.transform.localRotation = Quaternion.identity;
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                break;
            case "ice_espresso":
                Debug.Log("ice_espresso");
                /////////////TEST///////////////
                StringTable table1 = new StringTable();
                StringTable.Data data1 = table1.GetString("ice_espresso");
                if (data1 != null)
                {
                    string dayForEspresso = data1.day;
                    Debug.Log(dayForEspresso);
                }
                //////////////////////////
                var icees = Instantiate(ice_espressoPre, CupPosition.position, Quaternion.identity);
                icees.transform.SetParent(CupPosition.transform, true);
                icees.transform.localPosition = Vector3.zero;
                icees.transform.localRotation = Quaternion.identity;
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                break;
            case "americano":
                Debug.Log("americano");
                /////////////TEST///////////////
                StringTable table2 = new StringTable();
                StringTable.Data data2 = table2.GetString("americano");
                if (data2 != null)
                {
                    string dayForEspresso = data2.day;
                    Debug.Log(dayForEspresso);
                }
                //////////////////////////
                var am = Instantiate(americanoPre, CupPosition.position, Quaternion.identity);
                am.transform.SetParent(CupPosition.transform, true);
                am.transform.localPosition = Vector3.zero;
                am.transform.localRotation = Quaternion.identity;
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                break;
            case "ice_americano":
                Debug.Log("ice_americano");
                /////////////TEST///////////////
                StringTable table3 = new StringTable();
                StringTable.Data data3 = table3.GetString("ice_americano");
                if (data3 != null)
                {
                    string dayForEspresso = data3.day;
                    Debug.Log(dayForEspresso);
                }
                //////////////////////////
                var iceam = Instantiate(ice_americanoPre, CupPosition.position, Quaternion.identity);
                iceam.transform.SetParent(CupPosition.transform, true);
                iceam.transform.localPosition = Vector3.zero;
                iceam.transform.localRotation = Quaternion.identity;
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                break;

            case "caffelatte":
                Debug.Log("caffelatte");
                /////////////TEST///////////////
                StringTable table4 = new StringTable();
                StringTable.Data data4 = table4.GetString("caffelatte");
                if (data4 != null)
                {
                    string dayForEspresso = data4.day;
                    Debug.Log(dayForEspresso);
                }
                //////////////////////////
                var late = Instantiate(latte, CupPosition.position, Quaternion.identity);
                late.transform.SetParent(CupPosition.transform, true);
                late.transform.localPosition = Vector3.zero;
                late.transform.localRotation = Quaternion.identity;
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                break;

            case "ice_caffelatte":
                Debug.Log("ice_caffelatte");
                /////////////TEST///////////////
                StringTable table5 = new StringTable();
                StringTable.Data data5 = table5.GetString("ice_caffelatte");
                if (data5 != null)
                {
                    string dayForEspresso = data5.day;
                    Debug.Log(dayForEspresso);
                }
                //////////////////////////
                var iclate = Instantiate(ice_latte, CupPosition.position, Quaternion.identity);
                iclate.transform.SetParent(CupPosition.transform, true);
                iclate.transform.localPosition = Vector3.zero;
                iclate.transform.localRotation = Quaternion.identity;
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                break;
            default:
                Debug.Log("false");
                foreach (var c in Cups)
                {
                    Destroy(c);
                }
                Cups.Clear();
                break;
            
        }
        
    }

}
