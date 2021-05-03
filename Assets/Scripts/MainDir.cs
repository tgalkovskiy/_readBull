using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainDir : MonoBehaviour
{
    public Transform[] Points;
    
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
    public float timer;
    private void Awake()
    {
        Player = GetComponent<Rigidbody>();
        Speed = Speed_Z;
        //Debug.Log(Points.Count);
    }

    private void Update()
    {
        timer += Time.deltaTime / 3;
        transform.position = Bezier.GetPoint(Points[0].position, Points[1].position, Points[2].position, Points[3].position, timer);
        transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(Points[0].position, Points[1].position, Points[2].position, Points[3].position, timer));
        
        /*if (this.transform.position.z >= Points[3].position.z)
        {
            for (int i = 0; i < 3; i++)
            {
               Points.RemoveAt(0); 
            }
            timer = 0;
        }*/
        /*_time += Time.deltaTime;
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
        transform.Translate(Global_Dir, Space.Self);*/
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
    
    /*private void OnDrawGizmos() {

        int sigmentsNumber = 20;
        Vector3 preveousePoint = Points[0].position;

        for (int i = 0; i < sigmentsNumber + 1; i++) {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(Points[0].position, Points[1].position, Points[2].position, Points[3].position, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }

    }*/
    
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
