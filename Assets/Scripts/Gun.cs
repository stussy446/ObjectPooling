using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private BulletObjectPool _bulletPool;
    [SerializeField] private int _clipSize = 10;

    private void Awake()
    {
        _bulletPool.Setup(_clipSize);
    }

}
