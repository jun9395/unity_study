using UnityEngine;

public class Movement2D : MonoBehaviour
{
    /*private void Update()
    {
        // 새로운 위치 = 현재 위치 + (방향 * 속도)
        // transform.position = transform.position + new Vector3(1, 0, 0) * 1;

        transform.position += Vector3.right * 1 * Time.deltaTime;
    }*/

    // 방향키를 눌렀을 때 이동
    private float moveSpeed = 5.0f;                 // 이동 속도
    private Vector3 moveDirection = Vector3.zero;   // 이동 방향

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");   // 좌우 이동
        float y = Input.GetAxisRaw("Vertical");     // 상하 이동

        // 이동 방향 설정
        moveDirection = new Vector3(x, y, 0);

        // 새로운 위치
        // transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // velocity는 방향과 속력을 나타내는 속도 변수
        // 속도를 설정하면 RigidBody 내부에 있는 이동 함수를 해당 속도로 실행
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
    }

    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }
}
