using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TrailRender : MonoBehaviour
{
    public TrailRenderer[] TrailRenders;

    public static TrailRender Instance;

    private void Awake()
    {
        Instance = this;
    }


    public void ActivTrail()
    {
        foreach (var I in TrailRenders)
        {
            DOTween.To(() => I.startWidth, x => I.startWidth = x,
                0.4f, 0.5f);
        }
    }
    public void DeactivTrail()
    {
        foreach (var I in TrailRenders)
        {
            DOTween.To(() => I.startWidth, x => I.startWidth = x,
                0.2f, 0.5f);
        }
    }
}
