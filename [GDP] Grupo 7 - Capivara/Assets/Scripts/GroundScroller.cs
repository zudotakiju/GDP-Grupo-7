using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    private float width;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector2.left * GameManager.instance.gameSpeed * Time.deltaTime);

        // reposiciona o chão (loop infinito)
        if (transform.position.x <= -width)
        {
            transform.position = new Vector3(transform.position.x + (width * 2f), transform.position.y, transform.position.z);
        }
    }
}

