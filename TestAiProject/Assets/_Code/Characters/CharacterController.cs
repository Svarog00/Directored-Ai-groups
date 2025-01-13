using InteractableGroupsAi.Agents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    [SerializeField] private List<Sensor> _sensors = new List<Sensor>();
    [SerializeField] private CharacterState _initialState;

    private AiController<CharacterState> _controller;
    private CharacterState _currentState;

    private Transform _transform;
    private Vector3 _targetPosition;
    private Vector3 _direction;
    private bool _canMove = false;

    public CharacterState State => _currentState;

    private void Awake()
    {
        _transform = transform;
        _currentState = Instantiate(_initialState);
    }

    // Start is called before the first frame update
    void Start()
    {
        _sensors.ForEach(x => _controller.AddSensor(x));
    }

    // Update is called once per frame
    void Update()
    {
        //_controller.Update();

        ProccessMove();
    }

    public void SetController(AiController<CharacterState> controller)
    {
        _controller = controller;
    }

    public void MoveTo(Vector3 position)
    {
        _canMove = true;
        _targetPosition = position;
        _direction = (_targetPosition - _transform.position).normalized;
    }

    public void StopMove() => _canMove = false;

    private void ProccessMove()
    {
        if (_canMove == false) return;

        _transform.Translate(_transform.position + _speed * _direction * Time.deltaTime);
        _currentState.SetPosition(transform.position);
    }
}
