using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("OrdinaryWall") || other.CompareTag("NormalMeteor"))
            Destroy(gameObject);
    }
}
