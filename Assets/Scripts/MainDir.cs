using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using PathCreation;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

public class MainDir : MonoBehaviour
{
    public float speed;
    [SerializeField] private Path1 _line;
    List<Vector3> path = new List<Vector3>();
    private List<Quaternion> Rot = new List<Quaternion>();
    private int a = 0;
    /*public float speed;
    float dstTravelled;
    private float _time;
    public float timer;
    public PathCreator pathCreator;
    public EndOfPathInstruction end;*/
    private void Awake()
    {
        //Debug.Log(_line.positionCount);
        for (int i = 0; i < _line.Point_path.Count; i++)
        {
            path.Add(_line.Point_path[i].transform.position);
            Rot.Add(_line.Point_path[i].transform.rotation);
        }
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, path[a], Time.deltaTime*speed);
        if (Math.Abs(transform.position.x-path[a].x)<0.1f || Math.Abs(transform.position.z-path[a].z)<0.1f)
        {
            transform.DORotateQuaternion(_line.Point_path[a].transform.rotation, 1f);
            a++;
        }
        //timer += Time.deltaTime / 3;
        //transform.position = Bezier.GetPoint(Points[0].position, Points[1].position, Points[2].position, Points[3].position, timer);
        //transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(Points[0].position, Points[1].position, Points[2].position, Points[3].position, timer));

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
        //_timer.text = ((int)_time).ToString();
        //_score.text = Score.ToString();
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
    
    /*public void Forsage()
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
    }*/
    
    
}
