using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Sprite _roma;
    [SerializeField] private Sprite _kate;
    [SerializeField] private Image _tutor1;
    [SerializeField] private Text _tutor1Text;
    [SerializeField] private Image _tutor2;
    [SerializeField] private Text _tutor2Text;
    [SerializeField] private float delaystartfirsttutor = default;
    [SerializeField] private float delaystartfirstdrift = default;
    [SerializeField] private Transform posstart = default;
    [SerializeField] private Transform posfin =default;
    [SerializeField] private GameObject panelTutor1 = default;
    [SerializeField] private GameObject panelTutor2 = default;
    [SerializeField] private ChoisCar _choisCar;
    
    public bool keytap = false;
    public bool isTap = false;
    private void Start()
    {
        StartCoroutine(starttutor());
        if (_choisCar.nuberCar == 0)
        {
            _tutor1.sprite = _roma;
            _tutor1Text.text = "Рома";
            _tutor2.sprite = _roma;
            _tutor2Text.text = "Рома";
        }
        else
        {
            _tutor1.sprite = _kate;
            _tutor1Text.text = "Катя";
            _tutor2.sprite = _kate;
            _tutor2Text.text = "Катя";
        }
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
