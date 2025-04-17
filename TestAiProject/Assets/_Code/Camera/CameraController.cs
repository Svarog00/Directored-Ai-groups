using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const string VeritcalAxisName = "Vertical";
    private const string HorizontalAxisName = "Horizontal";

    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxOrthoSize = 15;

    private Vector3 _direction;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        ProcessInput();
    }

    void FixedUpdate()
    {
        ProcessMove();
        ProcessSize();
    }

    private void ProcessInput()
    {
        _direction = new Vector3(Input.GetAxis(HorizontalAxisName), Input.GetAxis(VeritcalAxisName));

        if (Input.GetKeyDown(KeyCode.E))
        {
            _camera.orthographicSize += 1;
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, 1, _maxOrthoSize);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            _camera.orthographicSize -= 1;
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, 1, _maxOrthoSize);
        }
    }

    private void ProcessMove()
    {
        _transform.Translate(_speed * Time.deltaTime * _direction);
    }

    private void ProcessSize()
    {

    }
}
