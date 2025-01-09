using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;

public class AttackAction : AgentAction, IAgentStateable
{
    public CharacterState State => _state;

    private readonly CharacterState _state;
    private readonly CharacterState _target;
    private readonly CharacterController _controller;


    public AttackAction(CharacterState state, CharacterController characterController, ComppositeAgentCondition condition, CharacterState target) : base(condition)
    {
        _state = state;
        _target = target;
        _controller = characterController;
    }

    public override void ForceEnd()
    {

    }

    public float GetGoalChange(Goal goal)
    {
        
        return 1f;
    }

    public override IAgentState GetNewState() => null;

    public override void OnBegin()
    {

    }

    public override void OnEnd()
    {

    }

    public override void TryExecute()
    {

    }

    public override void Update()
    {

    }
}