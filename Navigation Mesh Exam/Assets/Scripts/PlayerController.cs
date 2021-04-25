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
        // ���콺 ���� ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            // Camera.main : �±װ� Camera�� ������Ʈ, �� ���� ī�޶�
            // ī�޶�κ��� ���콺 ��ǥ ��ġ�� �����ϴ� ���� ����
            // ray.origin : ������ ���� ��ġ
            // ray.direction : ������ ���� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            // Physics.Raycast() : ������ �߻��ؼ� �ε�ġ�� ������Ʈ�� ����
            // �ε�ġ�� ��� true ��ȯ
            // ray.origin ��ġ�κ��� ray.direction �������� Mathf.Infinity�� ���� �߻�
            // ������ �ε�ġ�� ������Ʈ�� ������ hit�� ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // hit.transform.position : �ε�ģ ������Ʈ�� ��ġ
                // hit.point : ������ ������Ʈ�� �ε�ģ ���� ��ġ

                // hit.point�� ��ǥ ��ġ�� �̵�
                movement3D.MoveTo(hit.point);
            }
        }
    }
}
