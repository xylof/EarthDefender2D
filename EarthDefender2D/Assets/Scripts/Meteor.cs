using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Meteor : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;

    [SerializeField]
    private float forceMultiplier;

    protected ScoreSystem scoreSystem;

    private void Start()
    {
        GameObject scoreSystemGameObject = GameObject.Find("ScoreSystem");
        scoreSystem = scoreSystemGameObject.GetComponent<ScoreSystem>();
    }

    public void Move()
    {
        rb2D.AddForce(Vector2.left * forceMultiplier, ForceMode2D.Impulse);
    }   
}
