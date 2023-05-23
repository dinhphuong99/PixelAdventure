using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPieces : MonoBehaviour
{
    [SerializeField] protected float pieceSpeed = 0.035f;
    [SerializeField] protected Vector2 pieceDirection = Vector2.right;
    protected Rigidbody2D rb;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected void Update()
    {
        PieceLaunch();
    }

    protected virtual void PieceLaunch()
    {
        rb.AddForce(pieceDirection.normalized * pieceSpeed, ForceMode2D.Impulse);
    }
}
