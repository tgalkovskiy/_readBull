using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class Finish : MonoBehaviour
{
    [SerializeField] private TableScore _tableScore;
    [SerializeField] private GameObject _finishPanel = default;
    [SerializeField] private Transform _finishtransform = default;
    private void Start()
    {
        _tableScore.ShowCsore(Menu.Score);
        _finishPanel.transform.DOMove(_finishtransform.position, 1f).OnComplete(() => Time.timeScale = 0);
        //_finishPanel.SetActive(true);
    }
}
