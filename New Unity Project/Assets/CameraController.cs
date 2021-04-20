using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotateSpeedX = 3;
    private float rotateSpeedY = 5;
    private float limitMinX = -80;
    private float limitMaxX = 50;
    private float eulerAngleX;
    private float eulerAngleY;


    public void RotateTo(float mouseX, float mouseY)
    {
        // ���콺�� �¿�� �����̴� mouseX ���� y�࿡ �����ϴ� ������
        // ���콺�� �¿�� ������ �� ī�޶� �¿츦 ������
        // ī�޶� ������Ʈ�� y���� ȸ���ؾ� �ϱ� ����
        eulerAngleY += mouseX * rotateSpeedX;

        eulerAngleX -= mouseY * rotateSpeedY;   // ���콺�� �Ʒ��� ���°� -, ī�޶�� +


        // x�� ȸ������ ��� �Ʒ����� �� �� �ִ� ���� ������ �ִ�
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    // Update is called once per frame
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        else if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
