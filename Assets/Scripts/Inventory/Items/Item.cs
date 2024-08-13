using Assets.Scripts.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Inventory.Items
{
    public abstract class Item : IItem
    {
        private ItemType _type;
        private int _count;
        private int _maxCount;

        public ItemType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public int MaxCount 
        {
            get { return _maxCount; }
            set { _maxCount = value; }
        }
    }
}
