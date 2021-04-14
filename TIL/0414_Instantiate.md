## 게임 오브젝트 생성 함수 Instantiate

- 게임 내에서 등장하는 게임오브젝트는 원본 오브젝트의 복사본



### 1. Prefab 생성

1. 원하는 형태로 게임오브젝트를 꾸며준다

2. Hierarchy View의 게임오브젝트를 Project View로 드래그&드랍

3. Hierarchy View에 있는 게임 오브젝트를 삭제



### 2. Spawner Script

- Instantiate(GameObject original);
    - original 게임 오브젝트(프리팹)를 복제해서 생성

- Instantiate(GameObject original, Vector3 position, Quaternion rotation);
    - original 게임오브젝트를 복제하여 rotation만큼 회전한 뒤 position 위치에 생성

    - 오일러 : 1x3 크기의 행렬

        - 장점 : 0~360의 각도 표현 가능

        - 단점 : 연산속도가 느리고, 짐벌락 현상 발생 가능

            - 짐벌락 : 회전 연산 도중 축이 하나 사라져 3차원의 오브젝트가 일그러지는 현상


    - 쿼터니온 : 사원수로 3개의 벡터 요소와 하나의 스칼라 요소로 구성
        - 장점 : 연산속도가 빠르고, 짐벌락 현상이 발생하지 않는다

        - 단점 : 0~360의 각도가 아니므로 특정 각도 표현이 힘들다

        - Quaternion.Euler(x, y, z) : 오일러 x, y, z를 쿼터니온으로 변경





