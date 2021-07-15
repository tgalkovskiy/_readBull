﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text time_text;
    public Text score;
    public Text scorenow;
    private float _Time;
    public static int Score=0;
    public static int Scorenow = 0;
    public void Exit()
    {
        Application.Quit();
    }

    private void Update()
    {
        _Time += Time.deltaTime;
        time_text.text = ((int) _Time).ToString();
        score.text = Score.ToString();
        scorenow.text = Scorenow.ToString();
    }
    
}
