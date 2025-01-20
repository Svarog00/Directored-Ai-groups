using InteractableGroupsAi.Agents;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SightPerception : MonoBehaviour, IPerceptionSensor
{
    [SerializeField] private Collider2D _sightCollider;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private string _colliderTag = "Perception";

    private Dictionary<AgentController, Vector3> _detectedCharacters = new();
    private GroupId _ownerGroup;
    private Transform _source;

    public Action<IAgentState> OnAgentDetected { get; set; }
    public Action<IAgentState> OnAgentLost { get; set; }
    public Action<IAgentState> OnAgentMoved { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _source = transform;
    }

    public void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessNewDetection(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ProcessLostDetection(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ProccessTargetMove(collision);
    }

    private void ProccessTargetMove(Collider2D collision)
    {
        if (collision.CompareTag(_colliderTag)) return;
        if (collision.gameObject == gameObject) return;

        if (collision.TryGetComponent<AgentController>(out var character) == false)
            return;

        if (character.State.GroupId.Equals(_ownerGroup)) return;

        var hits =
            Physics2D.RaycastAll(_source.position, (collision.transform.position - _source.position).normalized,
                    Vector3.Distance(collision.transform.position, _source.position));

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject == gameObject) continue;
            if (hit.collider.gameObject != character.gameObject)
            {
                print(hit.collider.gameObject);
                ProcessLostDetection(collision);
                return;
            }

            if (_detectedCharacters[character] != collision.transform.position)
                OnAgentMoved?.Invoke(character.State);
        }
    }

    public void Init(GroupId ownerGroup)
    {
        _ownerGroup = ownerGroup;
    }

    private void ProcessNewDetection(Collider2D collision)
    {
        if (collision.TryGetComponent<AgentController>(out var controller))
        {
            if (controller.State.GroupId.Equals(_ownerGroup)) return;

            var hits = Physics2D.RaycastAll(_source.position, (collision.transform.position - _source.position).normalized,
                    Vector3.Distance(collision.transform.position, _source.position));
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject == gameObject) continue;
                if (hit.collider.gameObject != collision.gameObject) return;

                OnAgentDetected?.Invoke(controller.State);
                _detectedCharacters.Add(controller, collision.transform.position);
            }
        }
    }

    private void ProcessLostDetection(Collider2D enemy)
    {
        if (enemy.TryGetComponent<AgentController>(out var controller))
        {
            if (controller.State.GroupId.Equals(_ownerGroup)) return;

            OnAgentLost?.Invoke(controller.State);
            _detectedCharacters.Remove(controller);
        }
    }
}
