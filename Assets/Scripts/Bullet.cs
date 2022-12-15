using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public virtual BulletType BulletType => BulletType.Normal;

    /// <summary>
    /// Returns the bullet to its appropriate pool
    /// </summary>
    /// <param name="pool"></param>
    public void ReturnToPool(BulletObjectPool pool)
    {
        pool.ReleaseBullet(this, this.BulletType);
    }
}
