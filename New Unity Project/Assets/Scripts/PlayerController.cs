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
        float x = Input.GetAxisRaw("Horizontal");   // ����Ű �¿�
        float z = Input.GetAxisRaw("Vertical");     // ����Ű ���Ʒ�

        move3D.MoveTo(new Vector3(x, 0, z));

        if (Input.GetKeyDown(jumpKeyCode))
        {
            move3D.JumpTo();
        }


        float mouseX = Input.GetAxis("Mouse X");    // ���콺 �¿� ������
                                                    // �������� �̵� -1, ���������� �̵� 1 
        float mouseY = Input.GetAxis("Mouse Y");    // ���콺 ���� ������
                                                    // �Ʒ��� �̵� -1, ���� �̵� 1
        cameraController.RotateTo(mouseX, mouseY);
    }
}
