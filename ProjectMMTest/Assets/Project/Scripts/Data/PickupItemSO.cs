using UnityEngine;

namespace MMTest.Data
{
    [CreateAssetMenu(fileName = "PickupItemSO", menuName = "Project/Data/Items/Create a pick up Item")]
    public class PickupItemSO : ScriptableObject
    {
        [SerializeField]
        private string _itemName;

        public string ItemName => _itemName;
    }
}