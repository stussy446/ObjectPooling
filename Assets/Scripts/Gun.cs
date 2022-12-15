using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private BulletObjectPool _bulletPool;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private BulletType _bulletType;

    [Header("Gun Settings")]
    [SerializeField] private int _clipSize = 10;
    [SerializeField] private float _fireSpeed = 10f;

    private void Awake()
    {
        _bulletPool.Setup(_clipSize);
    }
    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var bullet = _bulletPool.GetBullet(_bulletType);
            bullet.transform.position = _bulletSpawnPoint.position;

            Rigidbody bulletrb = bullet.GetComponent<Rigidbody>();
            bulletrb.AddForce(Vector3.forward * _fireSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

}
