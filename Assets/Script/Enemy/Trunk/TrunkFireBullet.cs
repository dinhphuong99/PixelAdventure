using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkFireBullet : FireBullet
{
    protected override void BulletLaunch()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.transform.localScale = new Vector3(this.transform.localScale.x,
            bullet.transform.localScale.y, bullet.transform.localScale.z);
        Debug.Log("this.transform.localScale.x " + this.transform.localScale.x);

        if (this.transform.localScale.x == -1)
        {
            bulletDirection = Vector2.right;
        }

        if (this.transform.localScale.x == 1)
        {
            bulletDirection = -Vector2.right;
        }

        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletDirection.normalized * bulletSpeed, ForceMode2D.Impulse);
    }
}
