using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunctionTest : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Start 함수가 실행됐습니다");
    }
    private void Awake()
    {
        Debug.Log("Awake 함수가 실행됐습니다");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable 함수가 실행됐습니다");
    }

    private void Update()
    {
        Debug.Log("Update 함수가 실행 중입니다");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate 함수가 실행 중입니다");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate 함수가 실행 중입니다");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy 함수가 실행됐습니다");
    }

    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit 함수가 실행됐습니다");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable 함수가 실행됐습니다");
    }
}
