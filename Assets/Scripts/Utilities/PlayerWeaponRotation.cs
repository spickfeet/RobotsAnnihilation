using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponRotation
{
    public (Quaternion, bool) ChangeRotation(Vector3 weaponPos, float offset)
    {
        bool flipY = false;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - weaponPos;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion weaponRot = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (rotZ > 90 && rotZ < 180 || rotZ < -90 && rotZ > -180)
        {
            flipY = true;
        }
        if (rotZ > -90 && rotZ < 90)
        {
            flipY = false;
        }
        return (weaponRot, flipY);
    }
}
