using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject moveObject;
    [SerializeField]
    private Vector3 moveDirection;
    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = 5.0f;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        moveObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        moveObject.transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveObject.GetComponent<SpriteRenderer>().color = Color.white;

        moveObject.transform.position = new Vector3(0, 3, 0);
    }
}
