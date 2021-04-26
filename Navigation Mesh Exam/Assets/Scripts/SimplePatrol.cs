using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatrol : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform[] paths;
    private int currentPath = 0;
    private float moveSpeed = 3.0f;

    // Update is called once per frame
    private void Update()
    {
        // 이동 방향 설정 : (목표위치 - 내위치).정규화
        Vector3 direction = (paths[currentPath].position - transform.position).normalized;

        // 오브젝트 이동
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 목표 위치에 도달했을 때
        // Vector3.Distance 보다 연산 빠름
        if ((paths[currentPath].position - transform.position).sqrMagnitude < 0.1f)
        {
            // 목표 위치 변경 (순찰 경로 순환)
            if (currentPath < paths.Length - 1) currentPath++;
            else currentPath = 0;
        }
    }
}
