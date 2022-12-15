using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BulletObjectPool
{
    [SerializeField] private List<Bullet> _bulletPrefabs;

    private Dictionary<BulletType, List<Bullet>> _pools;

    /// <summary>
    /// Sets up the pool with each pool having the ability to contain prewarmCount amounts of bullets each
    /// </summary>
    /// <param name="prewarmCount">int, bullets to put in each pool</param>
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
    
    /// <summary>
    /// Creates a new bullet object of the bulletPrefab passed in. Sets the new bullet as not active and returns the new bullet
    /// </summary>
    /// <param name="bulletPrefab">Bullet bullet prefab to be instantiated</param>
    /// <returns>Bullet the newly created bullet</returns>
    private Bullet Instantiate(Bullet bulletPrefab)
    {
        Bullet newBullet = UnityEngine.Object.Instantiate(bulletPrefab);
        newBullet.gameObject.SetActive(false);

        return newBullet;
    }

    /// <summary>
    /// Retrieves a bullet of the matching bulletType from the _pools dictionary. Sets the bullet as active nd removes the bullet from its bulletpool
    /// </summary>
    /// <param name="bulletType">BulletType type of bullet requested</param>
    /// <returns>Bullet bullet returned</returns>
    public Bullet GetBullet(BulletType bulletType)
    {
        var bulletPool = _pools[bulletType];
        Bullet bullet;

        if (bulletPool.Count == 0)
        {
            bullet = Instantiate(_bulletPrefabs.Find(_bulletPrefabs => _bulletPrefabs.BulletType == bulletType));
        }
        else
        {
            bullet = bulletPool[0];
            bulletPool.RemoveAt(0);
        }

        bullet.gameObject.SetActive(true);
        return bullet;
    }

    /// <summary>
    /// Releases the provided bullet back into its appropriate pool and sets the bullet back to inactive 
    /// </summary>
    /// <param name="releasedBullet">Bullet bullet to be released back into its pool</param>
    /// <param name="bulletType">BulletType type of bullet to be released back into its pool</param>
    public void ReleaseBullet(Bullet releasedBullet, BulletType bulletType)
    {
        // do stuff
    }
}
