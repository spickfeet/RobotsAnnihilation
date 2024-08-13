using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    public class ShootRotation
    {
        private Transform _target;

        public ShootRotation(Transform target)
        {
            _target = target;
        }
        public Quaternion ChangeRotation(Vector3 weaponPos, float offset)
        {
            Vector3 difference = _target.position - weaponPos;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Quaternion weaponRot = Quaternion.Euler(0f, 0f, rotZ + offset);

            return weaponRot;
        }
    }
}
