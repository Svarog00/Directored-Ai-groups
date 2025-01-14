using InteractableGroupsAi.Agents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    [SerializeField] private List<IPerceptionSensor> _sensors = new List<IPerceptionSensor>();
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
        _currentState = Instantiate(_initialState);

        foreach(var sensor in _sensors)
        {
            sensor.OnAgentDetected += _controller.OnAgentDetected;
            sensor.OnAgentLost += _controller.OnAgentLost;
        }
    }

    void Start()
    {
        _sensors.ForEach(x => _controller.AddSensor(x));
    }

    void Update()
    {
        //_controller.Update();

        ProccessMove();
    }

    public void SetController(AiController<IAgentState> controller)
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

        _transform.Translate(_speed * Time.deltaTime * _direction);
        _currentState.SetPosition(transform.position);
    }
}
