using Assets.Scripts.Inventory.Items;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class Inventory
    {
        private IList<IItem> _items;
        private ItemCreator _creator = new();

        public Inventory(IList<IItem> items)
        {
            _items = items;
        }
        public bool TryAdd(ItemType item) 
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if(_items[i].Type == item)
                {
                    if (_items[i].Count >= _items[i].MaxCount) return false;
                    _items[i].Count += 1;
                    return true;
                }
            }
            _items.Add(_creator.CreateItem(item));
            return true;
        }

        public bool TryRemove(ItemType type)
        {
            foreach (var item in _items)
            {
                if(item.Type == type)
                {
                    if(item.Count == 1)
                    {
                        _items.Remove(item);
                        return true;
                    }
                    item.Count -= 1;
                    return true;
                }
            }
            return false;
        }
    }
}
