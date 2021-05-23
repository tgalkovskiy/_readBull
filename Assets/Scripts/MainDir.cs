using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using DG.Tweening;
using PathCreation;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

public class MainDir : MonoBehaviour
{
    public CinemachineDollyCart cinemachineDollyCart;
    public float speedX;
    public Camera _Camera;
    private float x_dir = 0;
    private Rigidbody Player;
    private bool Rigth = false;
    private bool Left = false;
    private void Awake()
    {
        Player = this.GetComponent<Rigidbody>();
    }

    private bool MovLeft = true;
    private bool Moverigth = true;
    private void Update()
    {
        x_dir = 0;
        if (Input.GetKey(KeyCode.D) || Rigth)
        {
            x_dir = 1;
        }
        else if (Input.GetKey(KeyCode.A) || Left)
        {
            x_dir = -1;
        }
        Vector3 Global_Dir = new Vector3(x_dir * speedX * Time.deltaTime, 0, 0);
        transform.Translate(Global_Dir, Space.Self);
        

    }
    
    public void Forsage()
    {
        DOTween.To(() => cinemachineDollyCart.m_Speed, x => cinemachineDollyCart.m_Speed = x,
            cinemachineDollyCart.m_Speed *2f, 0.5f);
        DOTween.To(() => _Camera.fieldOfView, x => _Camera.fieldOfView = x,85, 1);
    }
    public void end_Forsage()
    {
        DOTween.To(() => cinemachineDollyCart.m_Speed, x => cinemachineDollyCart.m_Speed = x,
            30, 0.5f);
        DOTween.To(() => _Camera.fieldOfView, x => _Camera.fieldOfView = x,60, 1);
    }
    public void Rigth_touch()
    {
         Rigth = true;
    }
    public void Up_Rigth_touch()
    {
         Rigth = false;
    }
    public void Left_touch()
    {
         Left = true;
    }
    public void Up_Left_touch()
    {
         Left = false;
    }
    
    
}
