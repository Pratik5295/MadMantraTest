using MMTest.Data;
using System.Collections.Generic;
using UnityEngine;

namespace MMTest.Managers
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance { get; private set; }

        private Dictionary<PickupItemSO, int> _inventoryItems; 

        private void Awake()
        {
            if(Instance != null && Instance == this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _inventoryItems = new Dictionary<PickupItemSO, int>();
        }

        public void ItemPickedUp(PickupItemSO item)
        {
            if (_inventoryItems.ContainsKey(item))
            {
                _inventoryItems[item] += 1;
            }
            else
            {
                _inventoryItems.Add(item, 1);
            }
        }

        public void ItemUsed(PickupItemSO item)
        {
            if (_inventoryItems.ContainsKey(item))
            {
                _inventoryItems[item] -= 1;

                if (_inventoryItems[item] <= 0)
                {
                    _inventoryItems.Remove(item);
                }
            }
            
        }
    }
}