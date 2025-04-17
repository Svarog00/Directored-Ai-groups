using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class MoveToNearestLocationGoal : Goal
{
    public MoveToNearestLocationGoal(CompositeGroupCondition condition, IGroupContext group) : base(condition)
    {
        SetGroupContext(group);
    }

    public override void Accept()
    {
        var targetVector = PointsHolder.GetNearestPoint(Group.GetState().CurrentPosition);
        Debug.Log($"Accept {nameof(MoveToNearestLocationGoal)}");
        Group.GetState().SetTargetPosition(targetVector);
        var state = Group.GetState() as GroupState;
        foreach (var agent in state.Agents)
        {
            agent.SetTargetPosition(targetVector);
        }
    }
}
