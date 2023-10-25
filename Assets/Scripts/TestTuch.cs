using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestTuch : MonoBehaviour
{
    public TextMeshPro text;
    void Update()
    {
        var message = string.Empty;

        Debug.Log(Input.touchCount);
        foreach(var toch in Input.touches)
        {
            message += "Touch ID: " + toch.fingerId;
            message += "\tPhase" + toch.phase;
            message += "\tDelta pos: " + toch.position;
            message += "\tDeltaTime: " + toch.deltaPosition + "/n";

            Debug.Log(toch);
        }

        text.text = message;
    }
}
