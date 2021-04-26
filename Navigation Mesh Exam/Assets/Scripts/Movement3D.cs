using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement3D : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveSpeed = 5.0f;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        // 오브젝트에 부착된 NavMeshAgent 컴포넌트를 가져온다
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void MoveTo(Vector3 goalPosition)
    {
        // 기존 이동행동을 있었다면 코루틴 중지
        StopCoroutine("OnMove");

        // 이동 속도 설정
        navMeshAgent.speed = moveSpeed;

        // 목표지점 설정 (목표까지의 경로 계산 후 알아서 움직인다)
        navMeshAgent.SetDestination(goalPosition);

        // 이동 행동에 대한 코루틴 시작
        StartCoroutine("OnMove");
    }

    IEnumerator OnMove()
    {
        while (true)
        {
            // 목표 위치(navMeshAgent.destination)와 내 위치(transform.position)가 거의 일치할 때
            if (Vector3.Distance(navMeshAgent.destination, transform.position) < 0.1f)
            {
                // 내 위치를 목표 위치로 설정
                transform.position = navMeshAgent.destination;

                // 설정된 경로를 초기화
                navMeshAgent.ResetPath();

                break;
            }

            yield return null;
        }
    }
}
