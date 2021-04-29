using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Road : MonoBehaviour
{
    public Road _Road;
    public GameObject Car;
    protected float Speed_Z = 20;
    protected float Speed_X = 15;
    [SerializeField] protected float lengt = default;
    [SerializeField] protected float Hint = default;
    protected float x_dir = 0;
    protected float z_dir = 1;
    
    private void Start()
    {
        if (_Road != null)
        {
            _Road.enabled = false;
        }
        //Hint = GetComponent<MeshFilter>().sharedMesh.bounds.size.z;

    }

    public virtual void New_Road()
    {
        if (Car != null)
        {
            _Road.Car = Car;
            _Road.enabled = true;
            this.GetComponent<Road>().enabled = false;
            Car.transform.SetParent(_Road.transform);
            Car.transform.DORotateQuaternion(_Road.transform.rotation, 0.5f);
            
            Car = null;
        }
        
    }
    
}
