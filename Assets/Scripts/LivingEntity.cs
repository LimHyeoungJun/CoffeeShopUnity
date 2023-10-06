using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public bool isCompletOrder { get; set; }
    public event Action oderComplet;

    protected virtual void OnEnable()
    {
        isCompletOrder = false;
    }

    public virtual void OnComplet()
    {
        if (oderComplet != null)
        {
            oderComplet();
        }

        // 사망 상태를 참으로 변경
        isCompletOrder = true;
    }

}
