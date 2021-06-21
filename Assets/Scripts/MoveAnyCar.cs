using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveAnyCar : MonoBehaviour
{
    public Transform target;

    public Vector3 speed = Vector3.forward;
    public Vector3 amplitude = Vector3.forward;

    public bool randomPhase = true;

    public bool timeScaleIndependent = false;

    private Vector3 position;
    private float time;

    void Start () 
    {
        if (randomPhase) time = Random.Range(0f, 360f);
        else time = 0f;
        position = target.localPosition;
    }

    void Update () 
    {
        if (timeScaleIndependent)
            time += Time.unscaledDeltaTime;
        else
            time += Time.deltaTime;


        target.localPosition = new Vector3(
            position.x + (amplitude.x * Mathf.Sin(speed.x * time)),
            position.y + (amplitude.y * Mathf.Sin(speed.y * time)),
            position.z + (amplitude.z * Mathf.Sin(speed.z * time)));
    }
}
