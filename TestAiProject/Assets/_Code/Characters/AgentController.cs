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
    private CharacterState _currentState = new();

    private Transform _transform;
    private Vector3 _targetPosition;
    private Vector3 _currentPosition;
    private Vector3 _direction;
    private bool _canMove = false;

    public float Speed => _speed;
    public AiController<IAgentState> Controller => _controller;
    public CharacterState State => _currentState;

    private void Awake()
    {
        _transform = transform;
        _currentState.SetPosition(transform.position);
    }

    public void Init(GroupId groupId, int id)
    {
        _currentState = _initialState;

        _currentState.SetGroupId(groupId);
        _currentState.SetAgentId(id);
        _currentState.SetPosition(transform.position);

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
        _currentPosition = new Vector3(_currentState.CurrentPosition.X, _currentState.CurrentPosition.Y, _currentState.CurrentPosition.Z);

        if (_currentState.CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
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

    public void StopMove()
    {
        _canMove = false;
    }

    private void ProccessMove()
    {
        if (_canMove == false) return;

        _transform.Translate(_speed * Time.deltaTime * _direction);
        _currentState.SetPosition(transform.position);
    }

    public void SetHealth(float health) => _currentState.SetHealth(health);
    public void SetRest(float rest) => _currentState.SetRest(rest);
}
