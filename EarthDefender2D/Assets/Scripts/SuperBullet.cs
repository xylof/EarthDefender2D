using UnityEngine;

public class SuperBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("OrdinaryWall") || other.CompareTag("NormalMeteor"))
            Destroy(gameObject);
    }
}
