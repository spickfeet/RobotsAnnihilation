using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private float _lifetime = 0.5f;
    private void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
    }
    private void Update()
    {
        _lifetime -= Time.fixedDeltaTime;
        if (_lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
