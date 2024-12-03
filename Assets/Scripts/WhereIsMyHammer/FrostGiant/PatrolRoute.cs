using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    public List<Transform> points;
    [SerializeField] private Color _patrolRouteColor = Color.green;

    private void OnDrawGizmos()
    {
        #if UNITY_EDITOR
            Handles.Label(transform.position, gameObject.name);
        #endif
        
        Gizmos.color = _patrolRouteColor;

        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }
        Gizmos.DrawLine(points[points.Count - 1].position, points[0].position);
    }
}
