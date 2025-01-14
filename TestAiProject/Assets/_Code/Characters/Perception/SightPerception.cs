using InteractableGroupsAi.Agents;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SightPerception : MonoBehaviour, IPerceptionSensor
{
    [SerializeField] private float _sightRadius = 2f;
    [SerializeField] private Collider2D _sightCollider;
    [SerializeField] private LayerMask _layerMask;

    private List<AgentController> _detectedCharacters = new();
    private GroupId _ownerGroup;
    private Transform _source;

    public Action<IAgentState> OnAgentDetected { get; set; }
    public Action<IAgentState> OnAgentLost { get; set;  }
    public Action<IAgentState> OnAgentMoved { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _source = transform;
    }

    public void Update()
    {
        foreach (var character in _detectedCharacters)
        {
            var hit = Physics2D.Raycast(_source.position, (character.transform.position - _source.position).normalized);

            OnAgentMoved?.Invoke(character.State);
            if (hit.collider.gameObject != character)
            {
                _detectedCharacters.Remove(character);
                OnAgentLost?.Invoke(character.State);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessNewDetection(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ProcessLostDetection(collision);
    }

    public void Init(GroupId ownerGroup)
    {
        _ownerGroup = ownerGroup;
    }

    private void ProcessNewDetection(Collider2D enemy)
    {
        if (enemy.TryGetComponent<AgentController>(out var controller))
        {
            var hit = Physics2D.Raycast(_source.position, (enemy.transform.position - _source.position).normalized);
            if (hit.collider != enemy) return;

            OnAgentDetected?.Invoke(controller.State);
            _detectedCharacters.Add(controller);
        }
    }

    private void ProcessLostDetection(Collider2D enemy)
    {
        if (enemy.TryGetComponent<AgentController>(out var controller))
        {
            OnAgentLost?.Invoke(controller.State);
            _detectedCharacters.Add(controller);
        }
    }
}
