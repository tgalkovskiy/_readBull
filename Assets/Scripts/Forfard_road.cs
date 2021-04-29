using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Forfard_road : Road
{
    private void Update()
    {
        if(Car !=null)
        {
            x_dir = 0;
           if(Input.GetKey(KeyCode.D))
           {
               if (Car.transform.localPosition.x < lengt)
               {
                   x_dir = 1; 
               }
           }
           else if (Input.GetKey(KeyCode.A))
           {
               if (Car.transform.localPosition.x > -lengt)
               {
                   x_dir = -1;  
               }
            }
            Vector3 Global_Dir = new Vector3(x_dir*Speed_X*Time.deltaTime,0,z_dir*Speed_Z*Time.deltaTime);
            //Car.transform.Translate(Global_Dir, Space.Self);
            Car.transform.localPosition += Global_Dir;
            if (Car.transform.localPosition.z > Hint)
            {
                New_Road();
            }
        }
    }
}
