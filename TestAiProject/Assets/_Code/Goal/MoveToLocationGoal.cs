using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MoveToLocationGoal : Goal
{
    public MoveToLocationGoal(CompositeGroupCondition condition) : base(condition)
    {

    }

    public override void Accept()
    {
        Debug.Log($"Accept {nameof(MoveToLocationGoal)}");
    }
}
