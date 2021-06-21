using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;


public class MainDir : MonoBehaviour
{
    public CinemachineDollyCart cinemachineDollyCart;
    public GameObject arrow;

    public static MainDir Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && arrow.transform.rotation.z< 0.7f)
        {
            arrow.transform.rotation *= Quaternion.Euler(0, 0, 0.5f);
        }
        if (Input.GetKey(KeyCode.D) && arrow.transform.rotation.z> -0.7f)
        {
            arrow.transform.rotation *= Quaternion.Euler(0, 0, -0.5f);
        }
    }
}
