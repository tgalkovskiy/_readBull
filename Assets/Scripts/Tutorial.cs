using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private float delaystartfirsttutor = default;
    [SerializeField] private float delaystartfirstdrift = default;
    [SerializeField] private Transform posstart = default;
    [SerializeField] private Transform posfin =default;
    [SerializeField] private GameObject panelTutor1 = default;
    [SerializeField] private GameObject panelTutor2 = default;

    public bool keytap = false;
    public bool isTap = false;
    private void Start()
    {
        StartCoroutine(starttutor());
    }

    IEnumerator starttutor()
    {
        yield return new WaitForSeconds(delaystartfirsttutor);
        panelTutor1.transform.DOMove(posfin.position, 0.6f).OnComplete(() =>
        {
            Time.timeScale = 0;
            isTap = true;
        });
        
        yield return new WaitUntil(() => keytap);
        isTap = false;
        keytap = false;
        Time.timeScale = 1;
        panelTutor1.transform.DOMove(posstart.position, 0.6f);
        
        yield return new WaitForSeconds(delaystartfirstdrift);
        panelTutor2.transform.DOMove(posfin.position, 0.6f).OnComplete(() =>
        {
            Time.timeScale = 0;
            isTap = true;
        });

        yield return new WaitUntil(() => keytap);
        Time.timeScale = 1;
        isTap = false;
        keytap = false;
        panelTutor2.transform.DOMove(posstart.position, 0.6f);
    }

    private void OnGUI()
    {
        if(!isTap) return;
        if (Event.current.Equals(Event.KeyboardEvent("A")) || Event.current.Equals(Event.KeyboardEvent("D")))
        {
            keytap = true;
        }
    }
}
