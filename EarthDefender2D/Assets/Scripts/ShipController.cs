using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private Bullet normalBulletPrefab;

    public void Update()
    {
        MoveShip();
        Shoot(normalBulletPrefab);
    }

    private void MoveShip()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= 4)
            transform.position += Vector3.up * Time.deltaTime * 10f;

        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= -4)
            transform.position += Vector3.down * Time.deltaTime * 10f;
    }

    private void Shoot(Bullet bullet)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Bullet bulletClone = CreateBullet(bullet);
            bulletClone.Move();
        }
    }

    private Bullet CreateBullet(Bullet bullet)
    {
        return Instantiate(bullet, transform.position + Vector3.right, bullet.transform.rotation);
    }
}
