using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Color color;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.color = color;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + " : OnCollisionStay2D()");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        spriteRenderer.color = Color.white;
    }
}
