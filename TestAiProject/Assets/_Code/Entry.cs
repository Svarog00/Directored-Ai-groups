using InteractableGroupsAi.Director;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    [SerializeField] private List<BucketScript> _buckets = new List<BucketScript>();

    private UtilityDirector _aiDirector;

    // Start is called before the first frame update
    void Start()
    {
        _aiDirector = new UtilityDirector();

        _buckets.ForEach(x => _aiDirector.AddBucket(x.Bucket));
    }

    // Update is called once per frame
    void Update()
    {
        _aiDirector.Update();   
    }
}
