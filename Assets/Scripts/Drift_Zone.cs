
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Drift_Zone : MonoBehaviour
{
    public AnimationCurve curve;
    private float time = 0;
    CinemachineDollyCart cinemachineDollyCart;
    private void OnTriggerEnter(Collider other)
    {
        cinemachineDollyCart = other.GetComponent<MainDir>().cinemachineDollyCart;
        DOTween.To(() => cinemachineDollyCart.m_Speed, x => cinemachineDollyCart.m_Speed = x,
            35, 0.5f);
    }
    private void OnTriggerStay(Collider other)
    {
        Quaternion rotnow = Quaternion.Euler(0,curve.Evaluate(time),0);
        other.gameObject.transform.localRotation *= rotnow;
        time += Time.deltaTime;
        Menu.Score += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        DOTween.To(() => cinemachineDollyCart.m_Speed, x => cinemachineDollyCart.m_Speed = x,
            50, 0.5f);
        other.transform.DOLocalRotate(Vector3.zero, 1);
    }
}

