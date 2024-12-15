using System;
using UnityEngine;

public class Draw : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private float minDistance = 0.1f;

    private LineRenderer currentLineRenderer;
    private Vector3 previousPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartNewLine();
        }

        if (Input.GetMouseButton(0) && currentLineRenderer != null)
        {
            DrawLine();
        }
    }

    private void StartNewLine()
    {
        GameObject newLine = Instantiate(linePrefab, transform);
        currentLineRenderer = newLine.GetComponent<LineRenderer>();

        previousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        previousPosition.z = 0.0f;
    }

    private void DrawLine()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 0.0f;

        if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
        {
            currentLineRenderer.positionCount++;
            currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, currentPosition);
            previousPosition = currentPosition;
        }
    }
}
