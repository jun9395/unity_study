using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunctionTest : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Start �Լ��� ����ƽ��ϴ�");
    }
    private void Awake()
    {
        Debug.Log("Awake �Լ��� ����ƽ��ϴ�");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable �Լ��� ����ƽ��ϴ�");
    }

    private void Update()
    {
        Debug.Log("Update �Լ��� ���� ���Դϴ�");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate �Լ��� ���� ���Դϴ�");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate �Լ��� ���� ���Դϴ�");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy �Լ��� ����ƽ��ϴ�");
    }

    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit �Լ��� ����ƽ��ϴ�");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable �Լ��� ����ƽ��ϴ�");
    }
}
