using UnityEngine;

public class NormalMeteor : Meteor
{
    [SerializeField]
    private Animator animator;

    private float hp = 100f;

    private void AddDamage(float damageValue)
    {
        hp -= damageValue;

        if (hp <= 0)
        {
            LaunchMeteorDestructionAnimation();
            InvokeRepeating("DestroyMeteor", 0.5f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EarthWall"))
        {
            Destroy(gameObject);
            scoreSystem.UpdateScore(-50);
        }

        if (other.CompareTag("NormalBullet"))
            AddDamage(25f);

        if (other.CompareTag("SuperBullet"))
            AddDamage(50f);
    }

    private void LaunchMeteorDestructionAnimation()
    {
        animator.SetTrigger("MeteorDestruction");
    }

    private void DestroyMeteor()
    {
        Destroy(gameObject);
        scoreSystem.UpdateScore(10);
    }
}
