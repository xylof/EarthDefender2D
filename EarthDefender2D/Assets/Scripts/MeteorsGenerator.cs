using UnityEngine;

public class MeteorsGenerator : MonoBehaviour
{
    [SerializeField]
    private Meteor normalMeteorPrefab;

    [SerializeField]
    private Meteor hardMeteorPrefab;

    private void Start()
    {
        InvokeRepeating("GenerateNormalMeteor", 1f, 1.5f);
        InvokeRepeating("GenerateHardMeteor", 6f, 4f);
    }

    private void GenerateNormalMeteor()
    {
        int yPosition = Random.Range(-4, 4);

        normalMeteorPrefab.transform.position = new Vector3(10, yPosition, 1);
        Meteor meteorClone = Instantiate(normalMeteorPrefab);
        meteorClone.Move();
    }

    private void GenerateHardMeteor()
    {
        int yPosition = Random.Range(-4, 4);

        hardMeteorPrefab.transform.position = new Vector3(10, yPosition, 1);
        Meteor meteorClone = Instantiate(hardMeteorPrefab);
        meteorClone.Move();
    }
}
