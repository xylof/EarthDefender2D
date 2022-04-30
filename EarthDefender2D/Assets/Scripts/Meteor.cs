using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Meteor : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;

    [SerializeField]
    private float forceMultiplier;

    public void Move()
    {
        rb2D.AddForce(Vector2.left * forceMultiplier, ForceMode2D.Impulse);
    }   
}
