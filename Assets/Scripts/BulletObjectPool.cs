using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BulletObjectPool
{
    [SerializeField] private List<Bullet> _bulletPrefabs;

    private Dictionary<BulletType, List<Bullet>> _pools;

    public void Setup(int prewarmCount)
    {
        _pools = new Dictionary<BulletType, List<Bullet>>();

        foreach (Bullet bulletPrefab in _bulletPrefabs)
        {
            var newPool = new List<Bullet>(prewarmCount);

            for (int i = 0; i < prewarmCount; i++)
            {
                newPool.Add(Instantiate(bulletPrefab));
            }

            _pools[bulletPrefab.BulletType] = newPool;
        }
    }

    private Bullet Instantiate(Bullet bulletPrefab)
    {
        Bullet newBullet = UnityEngine.Object.Instantiate(bulletPrefab);
        newBullet.gameObject.SetActive(false);

        return newBullet;
    }
}
