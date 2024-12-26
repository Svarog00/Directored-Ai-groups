using InteractableGroupsAi.Director.Buckets;
using InteractableGroupsAi.Director.Goals;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BucketScript", menuName = "ScriptableObjects/BucketScript", order = 1)]
public class BucketScript : ScriptableObject
{
    public Bucket Bucket { get; private set; }

    [SerializeField] private List<Goal> _goals;
}
