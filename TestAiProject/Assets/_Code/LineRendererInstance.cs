using InteractableGroupsAi.Director.Groups;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererInstance : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    private IGroupState _start;
    private IGroupState _end;

    public void SetUpLine(Color color, IGroupState start, IGroupState end)
    {
        _start = start;
        _end = end;

        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
    }

    // Update is called once per frame
    void Update()
    {
        var startPosition = new Vector3(_start.CurrentPosition.X, _start.CurrentPosition.Y);
        var endPosition = new Vector3(_end.CurrentPosition.X, _end.CurrentPosition.Y);

        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, endPosition);
    }

    public void Clear()
    {
        _lineRenderer.enabled = false;
    }
}
