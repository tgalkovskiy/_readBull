using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drift_Zone : MonoBehaviour
{
    public float Angle_rot;
    public float Change_Speed =1;
    public bool Rot_rigth;
    public bool Rot_left;

    private void OnTriggerEnter(Collider other)
    {
        DOTween.To(() => other.GetComponent<MainDir>().Speed_Z, x => other.GetComponent<MainDir>().Speed_Z = x,
            other.GetComponent<MainDir>().Speed_Z / Change_Speed, 1);
        
        if (Rot_rigth && !Rot_left)
        {
            Angle_rot *= 1;
        }
        if (Rot_left && !Rot_rigth)
        {
            Angle_rot *= -1;
        }
        other.transform.DOLocalRotateQuaternion(Quaternion.Euler(0,Angle_rot,0), 1f);
        
        //other.transform.DORotateQuaternion();
        //other.transform.DORotate(this.transform.eulerAngles, A, 1);
    }

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<MainDir>().Score += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        DOTween.To(() => other.GetComponent<MainDir>().Speed_Z, x => other.GetComponent<MainDir>().Speed_Z = x,
            other.GetComponent<MainDir>().Speed_Z * Change_Speed, 1);
    }
}
