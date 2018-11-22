using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawLine : MonoBehaviour {
    public GameObject Object1;
    public GameObject Object2;

    private void OnDrawGizmosSelected()
    {
        Vector3 fromPoint = Object1.transform.position;
        Vector3 toPoint = Object2.transform.position;

        // Draw Line
        Gizmos.color = Color.yellow;    // color select
        Gizmos.DrawLine(fromPoint, toPoint);

        // Draw Wire Sphere
        float radius = 3.0f;
        Gizmos.color = Color.green;    // color select
        Gizmos.DrawWireSphere(fromPoint, radius);

        // Draw Sphere
        Gizmos.color = Color.red;    // color select
        Gizmos.DrawSphere((fromPoint+toPoint)/2, 0.5f);
    }
}
