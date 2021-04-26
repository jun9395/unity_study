using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OffMeshLinkClimb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int offMeshArea = 3;        // �����޽��� ���� climb
    [SerializeField]
    private float climbSpeed = 1.5f;    // ���������� �ӵ�

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            // IsOnClimb() �Լ��� ��ȯ ���� true�� ������ �ݺ� ȣ��
            yield return new WaitUntil(() => IsOnClimb());

            // �ö󰡰ų� �������� �ൿ
            yield return StartCoroutine(ClimbOrDescend());
        }
    }

    public bool IsOnClimb()
    {
        if (navMeshAgent.isOnOffMeshLink)
        {
            // ���� ��ġ�� �ִ� OffMeshLink�� ������
            OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;

            // ���� : navMeshAgent.currentOfMeshLinkData.offMeshLink��
            // true�� �������� ������ OffMeshLink
            // false�� �ڵ����� ������ OffMeshLink

            // ���� ��ġ�� �ִ� OffMeshLink�� �������� ������ OffMeshLink�̰�, ��� ������ 'Climb'��
            if (linkData.offMeshLink != null && linkData.offMeshLink.area == offMeshArea)
                return true;
        }

        return false;
    }


    private IEnumerator ClimbOrDescend()
    {
        // �׺���̼� �̵��� ����
        navMeshAgent.isStopped = true;

        // ���� ��ġ�� �ִ� OffMeshLink�� ����/���� ��ġ
        OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;
        Vector3 start = linkData.startPos, end = linkData.endPos;

        // ���������� �ð� ����
        float climbTime = Mathf.Abs(end.y - start.y) / climbSpeed;
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            // �ܼ��� deltaTime�� ���ϸ� ������ 1�� �Ŀ� percent�� 1�� �ǹǷ�
            // climbTime ������ �����ؼ� �ð��� ����
            currentTime += Time.deltaTime;
            percent = currentTime / climbTime;

            // �ð� ����� ���� ������Ʈ�� ��ġ ����
            transform.position = Vector3.Lerp(start, end, percent);

            yield return null;
        }

        // OffMeshLink�� �̿��� �̵� �Ϸ�
        navMeshAgent.CompleteOffMeshLink();

        // OffMeshLink �̵��� �Ϸ������ ���̰��̼� �̵��� ����Ѵ�
        navMeshAgent.isStopped = false;
    }
}
