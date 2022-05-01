using UnityEngine;

public class StarPulsating : MonoBehaviour
{
    private SpriteRenderer starSpriteRenderer;

    private void Start()
    {
        starSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float sinus = Mathf.Sin(Time.time * 5);
        float alphaValue = ((sinus + 1) * 50 + 100) / 255f;

        starSpriteRenderer.color = new Color(1, 1, 1, alphaValue);
    }
}
