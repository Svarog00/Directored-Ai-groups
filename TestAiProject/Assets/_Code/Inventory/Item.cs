using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Inventory/ItemInstance", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;

    public string Name => _name;
    public int Id => _id;
}
