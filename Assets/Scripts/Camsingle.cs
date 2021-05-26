using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Camsingle : MonoBehaviour
{
    public  CinemachineVirtualCamera _CinemachineMain;
    public CinemachineVirtualCamera _CameraDrift;

    public static Camsingle Instance;
    private void Awake()
    {
        Instance = this.GetComponent<Camsingle>();
    }
}
