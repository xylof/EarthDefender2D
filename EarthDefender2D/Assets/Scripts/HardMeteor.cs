using UnityEngine;

public class HardMeteor : Meteor
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EarthWall"))
        {
            Destroy(gameObject);
            scoreSystem.UpdateScore(-20);
        }

        if (other.CompareTag("OrdinaryWall"))
        {
            Destroy(gameObject);
            scoreSystem.UpdateScore(10);
        }
    }
}
