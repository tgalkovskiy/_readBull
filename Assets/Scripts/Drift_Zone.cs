
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drift_Zone : MonoBehaviour
{
    public AnimationCurve curve;
    private float time = 0;

    private void OnTriggerStay(Collider other)
    {
        Quaternion rotnow = Quaternion.Euler(0,curve.Evaluate(time),0);
        other.gameObject.transform.localRotation *= rotnow;
        time += Time.deltaTime;
        Menu.Score += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.DOLocalRotate(Vector3.zero, 1);
    }
}

