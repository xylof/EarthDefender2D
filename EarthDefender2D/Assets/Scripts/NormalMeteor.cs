using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMeteor : Meteor
{
    private float hp = 100f;

    private void AddDamage(float damageValue)
    {
        hp -= damageValue;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EarthWall"))
            Destroy(gameObject);

        if (other.CompareTag("NormalBullet"))
            AddDamage(25f);
    }
}
