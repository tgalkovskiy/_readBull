using System;
using System.Collections.Generic;
using UnityEngine;

  [ExecuteAlways]
  public class RootBarrier : MonoBehaviour
  {
    [Header("Setting rotate barrier")] [SerializeField][Range(1,10)] private float angleRot = default;
    [SerializeField][Range(1,50)] private float speedRot = default;
    [SerializeField] private List<GameObject> rotateBarrier;
    [Header("Enabling obstacle movement in the editor")]
    [SerializeField] private bool isPlayRotBarrier = false;

    /*private void Start()
    {
      int rotobj = transform.childCount;
      for (int i = 0; i < rotobj; i++)
      {
        rotateBarrier.Add(transform.GetChild(i).gameObject);
      }
    }*/

    private void Update()
    {
      if (isPlayRotBarrier)
      {
        for(int i = 0; i < rotateBarrier.Count; i++)
        {
          rotateBarrier[i].transform.rotation *= Quaternion.Euler(0,0,angleRot* Time.deltaTime * speedRot);
        }
      }
    }
  }
