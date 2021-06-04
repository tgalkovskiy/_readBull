
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
    private void OnTriggerEnter(Collider other)
    {
        cinemachineDollyCart = other.GetComponent<MainDir>().cinemachineDollyCart;
        DOTween.To(() => cinemachineDollyCart.m_Speed, x => cinemachineDollyCart.m_Speed = x,
            Speed_drift, 0.5f);
        Camsingle.Instance._CinemachineMain.Priority = 5;
        Camsingle.Instance._CameraDrift.Priority = 10;
        TrailRender.Instance.ActivTrail();
        //other.GetComponent<MainDir>().trail.SetActive(true);
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
            70, 0.5f);
        other.transform.DOLocalRotate(Vector3.zero, 1);
        Camsingle.Instance._CinemachineMain.Priority = 10;
        Camsingle.Instance._CameraDrift.Priority = 5;
        TrailRender.Instance.DeactivTrail();
        //other.GetComponent<MainDir>().trail.SetActive(false);
    }
}

