using UnityEngine;

public class WeaponBoosterGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponBoosterPrefab;

    private void Start()
    {
        InvokeRepeating("GenerateWeaponBooster", 10f, 45f);
    }

    private void GenerateWeaponBooster()
    {
        int yPosition = Random.Range(-4, 4);

        weaponBoosterPrefab.transform.position = new Vector3(10, yPosition, 1);
        GameObject weaponBoosterClone = Instantiate(weaponBoosterPrefab);
        weaponBoosterClone.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 0.7f, ForceMode2D.Impulse);
    }
}
