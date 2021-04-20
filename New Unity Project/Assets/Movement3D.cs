using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;     // �̵��ӵ�

    [SerializeField]
    private float jumpForce = 3.0f;     // �ٴ� ��

    private Vector3 moveDirection;      // �̵�����
    private float gravity = -9.81f;     // �߷� ���

    [SerializeField]
    private Transform cameraTransform;
    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        // moveDirection = direction;
        ////
        // moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
        Vector3 movedis = cameraTransform.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z); // ī�޶� ���� ������ �������� �̵�
    }

    public void JumpTo()
    {
        if (characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}
