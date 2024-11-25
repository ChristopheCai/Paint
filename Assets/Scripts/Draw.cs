using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 previousPosition;
    
    [SerializeField] private float minDistance = 0.1f;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Camera.main is not null)
        {
            var currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0.0f;

            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {
                
                if (previousPosition == transform.position)
                {
                    lineRenderer.SetPosition(0, currentPosition);
                }
                else
                {
                    lineRenderer.positionCount++;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
                }
                previousPosition = currentPosition;
            }
        }
    }
}
