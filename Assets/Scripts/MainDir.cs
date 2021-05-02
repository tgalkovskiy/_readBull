using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainDir : MonoBehaviour
{
    public float Speed_X = 7;
    public float Speed_Z = 5;
    public Camera _Camera;
    public Text _timer;
    public Text _score;
    [HideInInspector] public int Score =0;
    private float x_dir;
    private float z_dir = 1;
    private Rigidbody Player;
    private bool Rigth = false;
    private bool Left = false;
    private float Speed;
    private float _time;
    private void Awake()
    {
        Player = GetComponent<Rigidbody>();
        Speed = Speed_Z;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        x_dir = 0;
        if (Input.GetKey(KeyCode.D) || Rigth)
        {
            x_dir = 1;
        }
        else if (Input.GetKey(KeyCode.A) || Left)
        {
            x_dir = -1;
        }

        Vector3 Global_Dir = new Vector3(x_dir * Speed_X * Time.deltaTime, 0, z_dir * Speed_Z * Time.deltaTime);
        transform.Translate(Global_Dir, Space.Self);
        _timer.text = ((int)_time).ToString();
        _score.text = Score.ToString();
        //this.transform.localPosition += Global_Dir;
        /*Vector3 GlobalDir = Vector3.forward;
        GlobalDir += new Vector3()*/
        //Player.AddForce(Global_Dir*Speed_Z);
        /*if (Player.velocity.magnitude < 20)
        {
          Player.AddRelativeForce(Global_Dir*Speed_Z);  
        }*/
        /*if (Car.transform.localPosition.z > Hint)
        {
            New_Road();
        }*/
        //Player.AddRelativeForce(Vector3.up*3);

    }
    
    public void Forsage()
    {
        DOTween.To(() => Speed_Z, x => Speed_Z = x,
            Speed_Z *1.5f, 2);
        DOTween.To(() => _Camera.fieldOfView, x => _Camera.fieldOfView = x,
            85, 2);
    }
    public void end_Forsage()
    {
        DOTween.To(() => Speed_Z, x => Speed_Z = x,
            Speed, 2);
        DOTween.To(() => _Camera.fieldOfView, x => _Camera.fieldOfView = x,
            60, 2);
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
