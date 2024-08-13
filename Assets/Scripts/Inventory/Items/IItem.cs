using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Inventory.Items
{
    public interface IItem
    {
        public ItemType Type {  get; set; }
        public int Count { get; set; }
        public int MaxCount { get; set; }
    }
}
