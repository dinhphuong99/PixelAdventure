using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    protected CollisionDetection collisionDetection;
    [SerializeField] protected Transform bulletSpawnPoint;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float bulletSpeed = 3f;
    [SerializeField] protected float fireTime = 0.8f;
    [SerializeField] protected Vector2 bulletDirection = -Vector2.right;
    protected float fireTimer = 0f;

    protected void Start()
    {
        collisionDetection = this.transform.GetChild(1).GetComponent<CollisionDetection>();
    }

    protected void Update()
    {
        if (collisionDetection.GetIsTouch())
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireTime)
            {
                fireTimer = 0f;
                BulletLaunch();
            }
        }
    }

    protected virtual void BulletLaunch()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletDirection.normalized * bulletSpeed, ForceMode2D.Impulse);
    }
}
