using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grape : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cup"))
        {
            Destroy(gameObject);
        }
    }
}
