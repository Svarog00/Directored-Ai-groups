using InteractableGroupsAi.Agents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    [SerializeField] private SightPerception _sensor;
    [SerializeField] private CharacterState _initialState;

    private AiController<IAgentState> _controller;
    private CharacterState _currentState;

    private Transform _transform;
    private Vector3 _targetPosition;
    private Vector3 _direction;
    private bool _canMove = false;

    public AiController<IAgentState> Controller => _controller;
    public CharacterState State => _currentState;

    private void Awake()
    {
        _transform = transform;
    }

    public void Init(GroupId groupId, int id)
    {
        _currentState = Instantiate(_initialState);

        _currentState.SetGroupId(groupId);
        _currentState.SetAgentId(id);

        _sensor.Init(groupId);

        _sensor.OnAgentDetected += x =>
        {
            _controller.OnAgentDetected(x);
        };
        _sensor.OnAgentMoved += x =>
        {
            _controller.OnTargetMoved(x);
        };
        _sensor.OnAgentLost += x => _controller.OnAgentLost(x);
    }

    void Start()
    {
        _controller.AddSensor(_sensor);
        _controller.Start();
    }

    void Update()
    {
        _controller.Update();
        ProccessMove();
    }

    public void SetController(AiController<IAgentState> controller)
    {
        _controller = controller;
        _controller.SetState(_currentState);
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

        _transform.Translate(_speed * Time.deltaTime * _direction);
        _currentState.SetPosition(transform.position);
    }
}
