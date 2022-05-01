using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private Bullet normalBulletPrefab;

    [SerializeField]
    private Bullet ironBulletPrefab;

    [SerializeField]
    private Bullet superBulletPrefab;

    [SerializeField]
    private Image hpBar;

    [SerializeField]
    private TextMeshProUGUI hpText;

    [SerializeField]
    private AudioSource normalAndSuperBulletAudioSource;

    [SerializeField]
    private AudioSource ironBulletAudioSource;

    [SerializeField]
    private AudioSource shipDamageAudioSource;

    private SpriteRenderer spriteRenderer;
    private float hp = 100f;
    private bool passing = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        MoveShip();
        Shoot();
        ChangeBoostedShipColor();
    }

    private void MoveShip()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= 4)
            transform.position += Vector3.up * Time.deltaTime * 10f;

        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= -4)
            transform.position += Vector3.down * Time.deltaTime * 10f;
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Bullet bulletClone = null;

            if (CompareTag("Player"))
                bulletClone = CreateBullet(normalBulletPrefab);
            else if (CompareTag("BoostedShip"))
                bulletClone = CreateBullet(superBulletPrefab);

            bulletClone.Move();
            normalAndSuperBulletAudioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Bullet bulletClone = CreateBullet(ironBulletPrefab);
            bulletClone.Move();
            ironBulletAudioSource.Play();

            StartCoroutine(DestroyIronBallAfterTime(bulletClone));
        }
    }

    private IEnumerator DestroyIronBallAfterTime(Bullet bulletClone)
    {
        yield return new WaitForSeconds(3f);

        if (bulletClone != null)
            Destroy(bulletClone.gameObject);
    }

    private Bullet CreateBullet(Bullet bullet)
    {
        return Instantiate(bullet, transform.position + Vector3.right, bullet.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NormalMeteor") || other.CompareTag("HardMeteor"))
        {
            AddDamage(25f);
            UpdateUI();
        }
        else if (other.CompareTag("WeaponBooster"))
        {
            Destroy(other.gameObject);
            tag = "BoostedShip";
        }
    }

    private void AddDamage(float damageValue)
    {
        hp -= damageValue;
        StartCoroutine(ChangeDamagedShipColor());

        shipDamageAudioSource.Play();

        if (hp <= 0)
            Destroy(gameObject);
    }

    private IEnumerator ChangeDamagedShipColor()
    {
        float previousR = spriteRenderer.color.r;
        float previousG = spriteRenderer.color.g;
        float previousB = spriteRenderer.color.b;
        float previousA = spriteRenderer.color.a;

        SetShipColor(1, 0, 0, 0.6f);

        yield return new WaitForSeconds(0.3f);

        SetShipColor(previousR, previousG, previousB, previousA);
    }

    private void UpdateUI()
    {
        hpBar.fillAmount = hp / 100f;
        hpText.text = $"{hp}%";
    }

    private void ChangeBoostedShipColor()
    {
        if (CompareTag("BoostedShip") && passing)
        {
            passing = false;
            InvokeRepeating("GoBackToNormalState", 10f, 0f);
            SetShipColor(0.48f, 0.87f, 0.87f, 1);
        }
    }

    private void GoBackToNormalState()
    {
        passing = true;
        tag = "Player";
        SetShipColor(1, 1, 1, 1);
    }

    private void SetShipColor(float r, float g, float b, float a)
    {
        spriteRenderer.color = new Color(r, g, b, a);
    }
}
