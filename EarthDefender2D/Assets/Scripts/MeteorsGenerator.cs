using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsGenerator : MonoBehaviour
{
    [SerializeField]
    private Meteor normalMeteorPrefab;

    private void Start()
    {
        InvokeRepeating("GenerateMeteor", 1f, 2f);
    }

    private void GenerateMeteor()
    {
        int yPosition = Random.Range(-4, 5);

        normalMeteorPrefab.transform.position = new Vector3(10, yPosition, 1);
        Meteor meteorClone = Instantiate(normalMeteorPrefab);
        meteorClone.Move();
    }
}
