using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using System.Linq;
using UnityEngine;

public class DestroyGroupGoal : Goal
{
    public IGroupState TargetGroup => _target;

    private IGroupState _target;

    private const float DangerousDistance = 5f;

    public DestroyGroupGoal(CompositeGroupCondition condition, IGroupContext state) : base(condition)
    {
        SetGroupContext(state);
    }

    public override void Accept()
    {
        var group = GroupsHolder.GetClosestEnemyGroup(Group);

        _target = group.GetState();
        Group.GetState().SetTarget(_target);

        GroupsHolder.DrawLine(Color.red, Group.GetState(), _target);
    }

    public override string ToString() => nameof(DestroyGroupGoal);
}