using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class MainDir : MonoBehaviour
{
    [SerializeField] private GameObject[] model =default;
    public ChoisCar choisCar;
    [SerializeField] private Text messagedriver = default;
    [SerializeField] private Text nameDriver = default;
    [SerializeField] private Image faceDriver = default;
    
    
    public float speed;
    public CinemachineDollyCart cinemachineDollyCart;
    
    public GameObject arrow;
    public GameObject back1;
    public GameObject back2;
    public GameObject back3;
    public GameObject back4;
    
    public GameObject roman;
    public Transform start;
    public Transform finish;
    
    private Image Back1;
    private Image Back2;
    private Image Back3;
    private Image Back4;
    
   
    private int nedScore = 600;
    public static bool isstrafe = true;
    public static bool isShow = true;
    public static MainDir Instance;

    private void Awake()
    {
        Instance = this;
        Back1 = back1.GetComponent<Image>();
        Back2 = back2.GetComponent<Image>();
        Back3 = back3.GetComponent<Image>();
        Back4 = back4.GetComponent<Image>();
        model[choisCar.nuberCar].SetActive(true);
        //Back3 = back3.GetComponent<Image>();
    }

    private void Start()
    {
        DOTween.To(() => cinemachineDollyCart.m_Speed, x => cinemachineDollyCart.m_Speed =x, 40, 1.5f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.localPosition.x > -3.5f && isstrafe)
            {
               transform.Translate(Vector3.left*Time.deltaTime*speed, Space.Self); 
            }
            if (arrow.transform.rotation.z < 0.7f)
            {
                 arrow.transform.rotation *= Quaternion.Euler(0, 0, 0.5f);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.localPosition.x < 4f && isstrafe)
            {
                transform.Translate(Vector3.right*Time.deltaTime*speed, Space.Self); 
            }
            if (arrow.transform.rotation.z > -0.7f)
            {
                arrow.transform.rotation *= Quaternion.Euler(0, 0, -0.5f);
            }
        }
        if (Mathf.Abs(arrow.transform.rotation.z)>0.1f && Math.Abs(arrow.transform.rotation.z) < 0.3f)
        {
            Back1.color = Color.cyan;
            Back2.color = Color.cyan;
            Back3.color = Color.cyan;
            Back4.color = Color.cyan;
        }
        if(Math.Abs(arrow.transform.rotation.z) > 0.3f && Math.Abs(arrow.transform.rotation.z) < 0.5f)
        {
            Back1.color = Color.yellow;
            Back2.color = Color.yellow;
            Back3.color = Color.yellow;
            Back4.color = Color.yellow;
        }
        if (Math.Abs(arrow.transform.rotation.z) > 0.5f)
        {
            Back1.color = Color.red;
            Back2.color = Color.red;
            Back3.color = Color.red;
            Back4.color = Color.red;
        }
        /*if (Menu.Score > nedScore)
        {
            isShow = true;
            StartCoroutine(ShowDriver(roman, start, finish, choisCar.phrasesRoman[3], "РОМАН", choisCar.faceRoma[3]));
            nedScore += 600;
        }*/
    }

    public IEnumerator ShowDriver(string message, Sprite face)
    {
            isShow = false;
            if (choisCar.nuberCar == 0)
            {
               nameDriver.text = "РОМАН"; 
            }
            else
            {
                nameDriver.text = "КАТЯ"; 
            }
            messagedriver.text = message;
            faceDriver.sprite = face;
            roman.transform.DOMoveX(start.position.x, 0.5f);
            yield return new WaitForSeconds(3.5f);
            roman.transform.DOMoveX(finish.position.x, 0.5f);
            isShow = true;
        }
        
    }
