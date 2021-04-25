using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Movement3D movement3D;

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            // Camera.main : 태그가 Camera인 오브젝트, 즉 메인 카메라
            // 카메라로부터 마우스 좌표 위치를 관통하는 광선 생성
            // ray.origin : 광선의 시작 위치
            // ray.direction : 광선의 직선 방향
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            // Physics.Raycast() : 광선을 발사해서 부딪치는 오브젝트를 검출
            // 부딪치는 경우 true 반환
            // ray.origin 위치로부터 ray.direction 방향으로 Mathf.Infinity의 광선 발사
            // 광선에 부딪치는 오브젝트의 정보를 hit에 저장
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // hit.transform.position : 부딪친 오브젝트의 위치
                // hit.point : 광선과 오브젝트가 부딪친 세부 위치

                // hit.point를 목표 위치로 이동
                movement3D.MoveTo(hit.point);
            }
        }
    }
}
