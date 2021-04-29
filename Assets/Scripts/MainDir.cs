using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDir : MonoBehaviour
{
   
    public float Speed_X = 7;
    public float Speed_Z = 5;
    
    private float x_dir;
    protected float z_dir = 1;

    private Rigidbody Player;
    private void Awake()
    {
        Player = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        {
            x_dir = 0;
            if (Input.GetKey(KeyCode.D))
            {
                x_dir = 1;

            }
            else if (Input.GetKey(KeyCode.A))
            {
                x_dir = -1;

            }
            Vector3 Global_Dir = new Vector3(x_dir * Speed_X * Time.deltaTime, 0, z_dir * Speed_Z * Time.deltaTime);
            //this.transform.localPosition += Global_Dir;
            transform.Translate(Global_Dir, Space.Self);
             
            /*Vector3 GlobalDir = Vector3.forward;
            GlobalDir += new Vector3()*/
            
            //Player.AddForce(Global_Dir*Speed_Z);
            /*if (Player.velocity.magnitude < 20)
            {
              Player.AddRelativeForce(Global_Dir*Speed_Z);  
            }*/
            
           
            /*if (Car.transform.localPosition.z > Hint)
            {
                New_Road();
            }*/
            //Player.AddRelativeForce(Vector3.up*3);
        }
    }
}
