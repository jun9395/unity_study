using UnityEngine;

public class Movement2D : MonoBehaviour
{
    /*private void Update()
    {
        // ���ο� ��ġ = ���� ��ġ + (���� * �ӵ�)
        // transform.position = transform.position + new Vector3(1, 0, 0) * 1;

        transform.position += Vector3.right * 1 * Time.deltaTime;
    }*/

    // ����Ű�� ������ �� �̵�
    private float moveSpeed = 5.0f;                 // �̵� �ӵ�
    private Vector3 moveDirection = Vector3.zero;   // �̵� ����

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");   // �¿� �̵�
        float y = Input.GetAxisRaw("Vertical");     // ���� �̵�

        // �̵� ���� ����
        moveDirection = new Vector3(x, y, 0);

        // ���ο� ��ġ
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
