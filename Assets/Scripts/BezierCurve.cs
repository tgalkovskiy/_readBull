using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public List<BezierNode> nodes;

    public Transform target;

    public float speed = 1f;

    private int nodeNumber;
    private float time;

    void Start()
    {
        nodeNumber = 0;
        time = 0f;
        target.position = nodes[0].transform.position;
    }

    void Update()
    {
        time += speed * Time.deltaTime;
        float k = nodes[nodeNumber].timing.Evaluate(time / nodes[nodeNumber].duration);

        Vector3 p0 = nodes[nodeNumber].transform.position + nodes[nodeNumber].transform.forward * nodes[nodeNumber].magnitude;
        Vector3 p1 = nodes[nodeNumber + 1].transform.position - nodes[nodeNumber + 1].transform.forward * nodes[nodeNumber + 1].magnitude;

        Vector3 q0 = Vector3.Lerp(nodes[nodeNumber].transform.position, p0, k);
        Vector3 q1 = Vector3.Lerp(p0, p1, k);
        Vector3 q2 = Vector3.Lerp(p1, nodes[nodeNumber + 1].transform.position, k);

        Vector3 r0 = Vector3.Lerp(q0, q1, k);
        Vector3 r1 = Vector3.Lerp(q1, q2, k);

        target.position = Vector3.Lerp(r0, r1, k);
        target.rotation = Quaternion.LookRotation(r1 - r0, Vector3.up);

        if (k >= 1f)
        {
           time = 0f;
           nodeNumber += 1;
           
        }
            
        
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < nodes.Count - 1; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(nodes[i].transform.position, nodes[i + 1].transform.position);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(nodes[i].transform.position, nodes[i].transform.forward * nodes[i].magnitude);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(
                nodes[i].transform.position + nodes[i].transform.forward * nodes[i].magnitude,
                nodes[i + 1].transform.position - nodes[i + 1].transform.forward * nodes[i + 1].magnitude);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(nodes[i + 1].transform.position, -nodes[i + 1].transform.forward * nodes[i + 1].magnitude);
        }
    }
}
