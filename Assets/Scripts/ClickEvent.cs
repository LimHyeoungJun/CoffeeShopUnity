using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoffeeMachine"))
        {
            other.GetComponent<CoffeBan>().Click();
        }
        else if(other.CompareTag("CupSpawn"))
        {
            other.GetComponent<SpawnCup>().click();
        }
        else if(other.CompareTag("IceBox"))
        {
            other.GetComponent<IceBox>().Click();
        }
        else if(other.CompareTag("Bottle"))
        {
            other.GetComponent<Bottle>().Click();
        }
    }


}
