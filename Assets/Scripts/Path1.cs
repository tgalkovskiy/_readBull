using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path1 : MonoBehaviour
{
    [SerializeField] public List<GameObject> Point_path = new List<GameObject>();

    private void OnDrawGizmos()
    {
        for (int i = 0; i < Point_path.Count+1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Point_path[i].transform.position, Point_path[i+1].transform.position);
        }
    }
}
