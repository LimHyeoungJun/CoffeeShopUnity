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
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("CupSpawn"))
        {
            other.GetComponent<SpawnCup>().click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("IceBox"))
        {
            other.GetComponent<IceBox>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("Bottle"))
        {
            other.GetComponent<Bottle>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if(other.CompareTag("milkbottle"))
        {
            other.GetComponent<milkBottle>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if(other.CompareTag("syrupBottle"))
        {
            other.GetComponent<syrupBottle>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if(other.CompareTag("h_syrupBottle"))
        {
            other.GetComponent<h_syrupBottle>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("v_syrupBottle"))
        {
            other.GetComponent<v_syrupBottle>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("choco"))
        {
            other.GetComponent<chocolatePack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("icecreampack"))
        {
            other.GetComponent<icecreamPack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("bananapack"))
        {
            other.GetComponent<bananaPack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("applepack"))
        {
            other.GetComponent<applePack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("honeypack"))
        {
            other.GetComponent<honeyPack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("sodacandoit"))
        {
            other.GetComponent<sodaPack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("lemonpack"))
        {
            other.GetComponent<lemonPack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("cherrypack"))
        {
            other.GetComponent<cherryPack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("strawberrypack"))
        {
            other.GetComponent<strawberryPack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("orangepack"))
        {
            other.GetComponent<orangePack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("pineapplepack"))
        {
            other.GetComponent<pineapplePack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        if (other.CompareTag("grapepack"))
        {
            other.GetComponent<grapePack>().Click();
            check = true;
            SoundManager.instance.PlayGetSound();
        }
        

    }


}
