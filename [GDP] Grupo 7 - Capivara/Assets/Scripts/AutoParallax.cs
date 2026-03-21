using UnityEngine;

public class AutoParallax : MonoBehaviour
{
    public float speed = 2f;
    private float width;
    public float overlapPixels;

    private float pixelsPerUnit;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
        pixelsPerUnit = sr.sprite.pixelsPerUnit;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= -width)
        {
            float overlapUnits = overlapPixels / pixelsPerUnit;

            transform.position += new Vector3((width * 2f) - overlapUnits, 0, 0);
        }
    }
}