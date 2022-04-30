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
            scoreSystem.UpdateScore(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EarthWall"))
        {
            Destroy(gameObject);
            scoreSystem.UpdateScore(-20);
        }

        if (other.CompareTag("NormalBullet"))
            AddDamage(25f);

        if (other.CompareTag("SuperBullet"))
            AddDamage(50f);
    }
}
