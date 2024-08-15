using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory.Items
{
    public class MedicKit : MonoBehaviour, IInteractable
    {
        [SerializeField] private int _healPoint;
        [SerializeField] private Player _player;
        private void Awake()
        {
            _player = FindAnyObjectByType<Player>();
        }
        public void Interact()
        {
            _player.ApplyHeal(_healPoint);
            Destroy(gameObject);
        }
    }
}
