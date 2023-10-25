using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiMouchManager : MonoBehaviour
{
    public bool IsTouching { get; private set; }
    public float ZoomNormal { get; private set; }

    private List<int> fingerIdList = new List<int>();

    public void Update()
    {
        foreach (var touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    fingerIdList.Add(touch.fingerId);
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    fingerIdList.Remove(touch.fingerId);
                    break;
            }
        }

        if(fingerIdList.Count >= 2) 
        {
            //[0] 1st Touch / [1] 2nd Touch
            Vector2[] prevFirstTouchPosition = new Vector2[2];
            Vector2[] currentTouchPosition = new Vector2[2];
            //PrecFrame Distance
            for(int i = 0; i < 2; ++i)
            {
                var touch = Array.Find(Input.touches,
                    x => x.fingerId == fingerIdList[i]);

                currentTouchPosition[i] = touch.position;
                prevFirstTouchPosition[i] = touch.position - touch.deltaPosition;
            }
            var prevFrameDist = Vector2.Distance(prevFirstTouchPosition[0], prevFirstTouchPosition[1]);
            var currFrameDist = Vector2.Distance(currentTouchPosition[0], currentTouchPosition[1]);

            //CurrFrame Distance

            Debug.Log(currFrameDist - prevFrameDist);
        }
    }
}
