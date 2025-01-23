using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using UnityEngine;

public class DestroyGroupGoal : Goal
{
    public IGroupState TargetGroup => _target;

    private IGroupState _target;

    public DestroyGroupGoal(CompositeGroupCondition condition, IGroupContext state) : base(condition)
    {
        SetGroupContext(state);
    }

    public override void Accept()
    {
        _target = Group.GetState().CurrentTarget.GetState();
        Debug.Log($"Accept {nameof(DestroyGroupGoal)}");
    }
}