
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using JetBrains.Annotations;

public class Drift_Zone : MonoBehaviour
{
    public int countnedpoint;
    public float Speed_drift;
    public AnimationCurve curve;
    private float time = 0;
    CinemachineDollyCart cinemachineDollyCart;
    private AudioSource audioSource;

    MainDir _mainDir;

    private int scornow = 0;
    private void Start()
    {
        _mainDir = MainDir.Instance;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        MainDir.isstrafe = false;
        cinemachineDollyCart = other.GetComponent<MainDir>().cinemachineDollyCart;
        DOTween.To(() => cinemachineDollyCart.m_Speed, x => cinemachineDollyCart.m_Speed = x,
            Speed_drift, 0.5f);
        TrailRender.Instance.ActivTrail();
        TrailRender.Instance.MoreSmoke();
        audioSource.PlayOneShot(audioSource.clip);
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(1);
        time += Time.deltaTime;
        Quaternion rotnowbody = Quaternion.Euler(0,curve.Evaluate(time),0);
        Quaternion rotnowarrow = Quaternion.Euler(0,0,curve.Evaluate(time)*8f);
        other.gameObject.transform.localRotation *= rotnowbody;
        if (_mainDir.arrow.transform.rotation.z < 0.7f && _mainDir.arrow.transform.rotation.z > -0.7f)
        {
            Debug.Log(2);
           _mainDir.arrow.transform.rotation *= rotnowarrow; 
        }
        if (Mathf.Abs(_mainDir.arrow.transform.rotation.z)>=0f &&  Mathf.Abs(_mainDir.arrow.transform.rotation.z)<0.3f)
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
        Debug.Log(scornow);
        if (MainDir.isShow)
        {
          IsShowDriver(other.GetComponent<MainDir>(), scornow);  
        }
        scornow = 0;
        TrailRender.Instance.HideSmoke();
        audioSource.Stop();
        MainDir.isstrafe = true;
        if(GetComponent<Finish>())
        {
            GetComponent<Finish>().enabled= true;
        }
        
    }

    public void IsShowDriver(MainDir mainDir, int scorenow)
    {
        Sprite[] sprites;
        if (mainDir.choisCar.nuberCar == 0)
        {
            sprites = mainDir.choisCar.faceRoma;
        }
        else
        {
            sprites = mainDir.choisCar.faceKate;
        }
        if (scorenow >= countnedpoint && scorenow <= countnedpoint * 1.2f)
        {
          mainDir.StartCoroutine(mainDir.ShowDriver(mainDir.choisCar.phrases[0], sprites[0]));  
        }
        if (scorenow >= countnedpoint*1.2 && scorenow <= countnedpoint * 1.3f)
        {
            mainDir.StartCoroutine(mainDir.ShowDriver(mainDir.choisCar.phrases[1], sprites[1]));  
        }
        if (scorenow >= countnedpoint*1.3)
        {
            mainDir.StartCoroutine(mainDir.ShowDriver(mainDir.choisCar.phrases[2], sprites[2]));  
        }
        if(scorenow< countnedpoint)
        {
            mainDir.StartCoroutine(mainDir.ShowDriver(mainDir.choisCar.phrases[3], sprites[3]));  
        }
    }
}

