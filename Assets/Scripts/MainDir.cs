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
    public GameObject back1;
    public GameObject back2;

    public static MainDir Instance;

    private Image Back1;

    private Image Back2;
    

    private void Awake()
    {
        Instance = this;
        Back1 = back1.GetComponent<Image>();
        Back2 = back2.GetComponent<Image>();
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

        if (Mathf.Abs(arrow.transform.rotation.z)>0.1f && Math.Abs(arrow.transform.rotation.z) < 0.3f)
        {
            Back1.color = Color.cyan;
            Back2.color = Color.cyan;
        }
        if(Math.Abs(arrow.transform.rotation.z) > 0.3f && Math.Abs(arrow.transform.rotation.z) < 0.5f)
        {
            Back1.color = Color.yellow;
            Back2.color = Color.yellow;
        }
        if (Math.Abs(arrow.transform.rotation.z) > 0.5f)
        {
            Back1.color = Color.red;
            Back2.color = Color.red;
        }
    }
}
