using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Inventory.Items
{
    public class MedicKit : Item
    {
        public MedicKit(int count, int maxCount)
        {
            Type = ItemType.MedicKit;
            Count = count;
            MaxCount = maxCount;
        }
    }
}
