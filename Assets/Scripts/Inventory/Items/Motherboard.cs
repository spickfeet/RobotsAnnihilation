using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Inventory.Items
{
    public class Motherboard : Item
    {
        public Motherboard(int count, int maxCount)
        {
            Type = ItemType.MedicKit; 
            Count = count;
            MaxCount = maxCount;
        }
    }
}
