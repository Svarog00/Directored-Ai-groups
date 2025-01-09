using InteractableGroupsAi.Other;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Inventory/ItemInstance", order = 1)]
public class ItemSo : ScriptableObject
{
    [SerializeField] private Item _item;
}
