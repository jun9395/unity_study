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
        // ������Ʈ�� ������ NavMeshAgent ������Ʈ�� �����´�
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void MoveTo(Vector3 goalPosition)
    {
        // ���� �̵��ൿ�� �־��ٸ� �ڷ�ƾ ����
        StopCoroutine("OnMove");

        // �̵� �ӵ� ����
        navMeshAgent.speed = moveSpeed;

        // ��ǥ���� ���� (��ǥ������ ��� ��� �� �˾Ƽ� �����δ�)
        navMeshAgent.SetDestination(goalPosition);

        // �̵� �ൿ�� ���� �ڷ�ƾ ����
        StartCoroutine("OnMove");
    }

    IEnumerator OnMove()
    {
        while (true)
        {
            // ��ǥ ��ġ(navMeshAgent.destination)�� �� ��ġ(transform.position)�� ���� ��ġ�� ��
            if (Vector3.Distance(navMeshAgent.destination, transform.position) < 0.1f)
            {
                // �� ��ġ�� ��ǥ ��ġ�� ����
                transform.position = navMeshAgent.destination;

                // ������ ��θ� �ʱ�ȭ
                navMeshAgent.ResetPath();

                break;
            }

            yield return null;
        }
    }
}
