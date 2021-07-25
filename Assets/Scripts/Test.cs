using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using  DG.Tweening;

public class Test : MonoBehaviour
{
    
    private LineRenderer Line;
    private void Awake()
    {
        Line = GetComponent<LineRenderer>();
        Vector3[] points = new Vector3[0];
        Line.positionCount = points.Length;
    }

    private void Update()
    {
        ShowLineItem(Vector3.zero, new Vector3(15,0,0));
    }

    public void ShowLineItem(Vector3 OriginPos, Vector3 speed)
    {
        Vector3[] points = new Vector3[50];
        Line.positionCount = points.Length;
        for(int i=0; i<points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = OriginPos + speed * time+Physics.gravity*time*time/2;
            if (points[i].y < 0)
            {
                Line.positionCount = i+1;
                break;
            }
        }
        Line.SetPositions(points);
    }
    public void ShowLineBow(Vector3 OriginPos, Vector3 speed)
    {
        Vector3[] points = new Vector3[12];
        Line.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = OriginPos + speed * time;
            if (points[i].y < 0)
            {
                Line.positionCount = i + 1;
                break;
            }
        }
        Line.SetPositions(points);
    }
}


