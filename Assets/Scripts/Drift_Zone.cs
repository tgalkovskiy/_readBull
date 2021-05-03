using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drift_Zone : MonoBehaviour
{
    public Transform[] P;
    /*public Transform P2;
    public Transform P3;
    public Transform P4;*/
    //public float Angle_rot;
    //public AnimationCurve _Curve;
    public float Change_Speed =1;
    //public bool Rot_rigth;
    //public bool Rot_left;

    private float Timer =0;
    private void OnTriggerEnter(Collider other)
    {
        var A = other.GetComponent<MainDir>();
        for (int i = 0; i < A.Points.Length; i++)
        {
            A.Points[i] = P[i];
            A.timer = 0;
        }
        /*DOTween.To(() => other.GetComponent<MainDir>().Speed_Z, x => other.GetComponent<MainDir>().Speed_Z = x,
            other.GetComponent<MainDir>().Speed_Z / Change_Speed, 1);*/

        /*if (Rot_rigth && !Rot_left)
        {
            Angle_rot *= 1;
        }
        if (Rot_left && !Rot_rigth)
        {
            Angle_rot *= -1;
        }*/
        //other.transform.DOLocalRotateQuaternion(Quaternion.Euler(0,Angle_rot,0), 1f);

        //other.transform.DORotateQuaternion();
        //other.transform.DORotate(this.transform.eulerAngles, A, 1);
    }

    private void OnTriggerStay(Collider other)
    {
        //other.GetComponent<MainDir>().Score += 1;
        //Timer += Time.deltaTime;
        //other.transform.rotation *= Quaternion.Euler(0,_Curve.Evaluate(Timer), 0);
        /*Timer += Time.deltaTime / 2;
        other.transform.position = Bezier.GetPoint(P1.position, P2.position, P3.position, P4.position, Timer);
        other.transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(P1.position, P2.position, P3.position, P4.position, Timer));*/
    }

    /*private void OnTriggerExit(Collider other)
    {
        DOTween.To(() => other.GetComponent<MainDir>().Speed_Z, x => other.GetComponent<MainDir>().Speed_Z = x,
            other.GetComponent<MainDir>().Speed_Z * Change_Speed, 1);
    }*/
    
    private void OnDrawGizmos() {

        int sigmentsNumber = 20;
        Vector3 preveousePoint = P[0].position;

        for (int i = 0; i < sigmentsNumber + 1; i++) {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(P[0].position, P[1].position, P[2].position, P[3].position, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }

    }
}
