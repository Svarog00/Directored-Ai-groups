using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] private int _id;

    public int Id => _id;
}