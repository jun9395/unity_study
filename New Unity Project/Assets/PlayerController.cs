using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;

    [SerializeField]
    private CameraController cameraController;

    private Movement3D move3D;

    void Awake()
    {
        move3D = GetComponent<Movement3D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");   // 방향키 좌우
        float z = Input.GetAxisRaw("Vertical");     // 방향키 위아래

        move3D.MoveTo(new Vector3(x, 0, z));

        if (Input.GetKeyDown(jumpKeyCode))
        {
            move3D.JumpTo();
        }


        float mouseX = Input.GetAxis("Mouse X");    // 마우스 좌우 움직임
                                                    // 왼쪽으로 이동 -1, 오른쪽으로 이동 1 
        float mouseY = Input.GetAxis("Mouse Y");    // 마우스 상하 움직임
                                                    // 아래로 이동 -1, 위로 이동 1
        cameraController.RotateTo(mouseX, mouseY);
    }
}
