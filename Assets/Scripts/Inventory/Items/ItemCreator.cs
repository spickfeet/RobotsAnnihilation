using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Inventory.Items
{
    public class ItemCreator
    {
        public Item CreateItem(ItemType type)
        {
            switch (type)
            {
                case ItemType.MedicKit:
                    return new MedicKit(1, 3);
                case ItemType.Motherboard:
                    return new Motherboard(1, 5);
                default:
                    throw new ArgumentException($"Неизвестный тип {type}");
            }
        }
    }
}
