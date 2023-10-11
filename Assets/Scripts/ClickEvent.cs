using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    private bool check = false;

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            check = false;
        }
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (check || !Input.GetMouseButton(0))
            return;
        
        if (other.CompareTag("CoffeeMachine"))
        {
            other.GetComponent<CoffeBan>().Click();
            check = true;
        }
        if (other.CompareTag("CupSpawn"))
        {
            other.GetComponent<SpawnCup>().click();
            check = true;
        }
        if (other.CompareTag("IceBox"))
        {
            other.GetComponent<IceBox>().Click();
            check = true;
        }
        if (other.CompareTag("Bottle"))
        {
            other.GetComponent<Bottle>().Click();
            check = true;
        }
        if(other.CompareTag("milkbottle"))
        {
            other.GetComponent<milkBottle>().Click();
            check = true;
        }
        if(other.CompareTag("syrupBottle"))
        {
            other.GetComponent<syrupBottle>().Click();
            check = true;
        }
        
       
    }


}
