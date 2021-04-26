using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OffMeshLinkClimb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int offMeshArea = 3;        // 오프메시의 구역 climb
    [SerializeField]
    private float climbSpeed = 1.5f;    // 오르내리는 속도

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            // IsOnClimb() 함수의 반환 값이 true일 때까지 반복 호출
            yield return new WaitUntil(() => IsOnClimb());

            // 올라가거나 내려오는 행동
            yield return StartCoroutine(ClimbOrDescend());
        }
    }

    public bool IsOnClimb()
    {
        if (navMeshAgent.isOnOffMeshLink)
        {
            // 현재 위치에 있는 OffMeshLink의 데이터
            OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;

            // 설명 : navMeshAgent.currentOfMeshLinkData.offMeshLink가
            // true면 수동으로 생성한 OffMeshLink
            // false면 자동으로 생성한 OffMeshLink

            // 현재 위치에 있는 OffMeshLink가 수동으로 생성한 OffMeshLink이고, 장소 정보가 'Climb'면
            if (linkData.offMeshLink != null && linkData.offMeshLink.area == offMeshArea)
                return true;
        }

        return false;
    }


    private IEnumerator ClimbOrDescend()
    {
        // 네비게이션 이동을 중지
        navMeshAgent.isStopped = true;

        // 현재 위치에 있는 OffMeshLink의 시작/종료 위치
        OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;
        Vector3 start = linkData.startPos, end = linkData.endPos;

        // 오르내리는 시간 설정
        float climbTime = Mathf.Abs(end.y - start.y) / climbSpeed;
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            // 단순히 deltaTime만 더하면 무조건 1초 후에 percent가 1이 되므로
            // climbTime 변수를 연산해서 시간을 조정
            currentTime += Time.deltaTime;
            percent = currentTime / climbTime;

            // 시간 경과에 따라 오브젝트의 위치 변경
            transform.position = Vector3.Lerp(start, end, percent);

            yield return null;
        }

        // OffMeshLink를 이용한 이동 완료
        navMeshAgent.CompleteOffMeshLink();

        // OffMeshLink 이동이 완료됐으니 네이게이션 이동을 계속한다
        navMeshAgent.isStopped = false;
    }
}
