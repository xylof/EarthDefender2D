using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private Bullet normalBulletPrefab;

    [SerializeField]
    private Bullet ironBulletPrefab;

    public void Update()
    {
        MoveShip();
        Shoot();
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
            Bullet bulletClone = CreateBullet(normalBulletPrefab);
            bulletClone.Move();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Bullet bulletClone = CreateBullet(ironBulletPrefab);
            bulletClone.Move();
        }
    }

    private Bullet CreateBullet(Bullet bullet)
    {
        return Instantiate(bullet, transform.position + Vector3.right, bullet.transform.rotation);
    }
}
