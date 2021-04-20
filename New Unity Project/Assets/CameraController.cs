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
        // 마우스를 좌우로 움직이는 mouseX 값을 y축에 대입하는 이유는
        // 마우스를 좌우로 움직일 때 카메라도 좌우를 보려면
        // 카메라 오브젝트의 y축이 회전해야 하기 때문
        eulerAngleY += mouseX * rotateSpeedX;

        eulerAngleX -= mouseY * rotateSpeedY;   // 마우스는 아래로 가는게 -, 카메라는 +


        // x축 회전값의 경우 아래위를 볼 수 있는 제한 각도가 있다
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
