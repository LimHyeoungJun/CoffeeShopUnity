using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCup : MonoBehaviour
{
    public GameObject CupPrefab;
    public Transform CupPosition;
    private List<GameObject> Cups = new List<GameObject>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            Debug.Log("Delete");
            foreach(var c in Cups) 
            {
                Destroy(c);
            }
            Cups.Clear();
            
        }
    }

    public void click()
    {
        
        if(Cups.Count < 1)
        {
            var Cup = Instantiate(CupPrefab, CupPosition.position, Quaternion.identity);
            Cup.transform.SetParent(CupPosition.transform, true);
            Cup.transform.localPosition = Vector3.zero;
            Cup.transform.localRotation = Quaternion.identity;

            Cups.Add(Cup);
        }

        
       
    }

}
