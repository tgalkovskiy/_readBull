
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Drift_Zone : MonoBehaviour
{
    public float Speed_drift;
    public AnimationCurve curve;
    private float time = 0;
    CinemachineDollyCart cinemachineDollyCart;

    MainDir _mainDir;

    private int scornow = 0;
    private void Start()
    {
        _mainDir = MainDir.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        cinemachineDollyCart = other.GetComponent<MainDir>().cinemachineDollyCart;
        DOTween.To(() => cinemachineDollyCart.m_Speed, x => cinemachineDollyCart.m_Speed = x,
            Speed_drift, 0.5f);
        TrailRender.Instance.ActivTrail();
    }
    private void OnTriggerStay(Collider other)
    {
        Quaternion rotnowbody = Quaternion.Euler(0,curve.Evaluate(time),0);
        Quaternion rotnowarrow = Quaternion.Euler(0,0,curve.Evaluate(time)*4f);
        other.gameObject.transform.localRotation *= rotnowbody;
        if (_mainDir.arrow.transform.rotation.z < 0.7f && _mainDir.arrow.transform.rotation.z > -0.7f)
        {
           _mainDir.arrow.transform.rotation *= rotnowarrow; 
        }
        time += Time.deltaTime;
        if (Mathf.Abs(_mainDir.arrow.transform.rotation.z)>0.1f)
        {
            scornow += 3; 
        }
        else if (Mathf.Abs(_mainDir.arrow.transform.rotation.z)>0.3f)
        {
            scornow += 2;
        }
        else if (Mathf.Abs(_mainDir.arrow.transform.rotation.z)>0.5f)
        {
            scornow += 1;
        }

        Menu.Scorenow = scornow;

    }

    private void OnTriggerExit(Collider other)
    {
        DOTween.To(() => cinemachineDollyCart.m_Speed, x => cinemachineDollyCart.m_Speed = x,
            70, 0.5f);
        other.transform.DOLocalRotate(Vector3.zero, 1);
        TrailRender.Instance.DeactivTrail();
        Menu.Score += scornow;
         scornow = 0;
    }
}

