using UnityEngine;

public class IronBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("OrdinaryWall") || other.CompareTag("EarthWall"))
            Destroy(gameObject);
    }
}
