using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject boxPrefab;

    private void Awake()
    {
        // 1. Instantiate(원본오브젝트);

        // 2. Instantiate(원본오브젝트, 위치, 회전);
        //Instantiate(boxPrefab, new Vector3(3, 0, 0), Quaternion.identity);
        //Instantiate(boxPrefab, new Vector3(0, -2, 0), Quaternion.identity);


        // 3. quaternion 회전각
        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        // Instantiate(boxPrefab, new Vector3(2, 1, 0), rotation);

        // 4. Instantiate의 반환값은 해당 게임오브젝트
        GameObject clone = Instantiate(boxPrefab, Vector3.zero, rotation);

        // 생성된 오브젝트 이름 변경
        clone.name = "Box001";

        // 생성된 오브젝트 색상 변경
        clone.GetComponent<SpriteRenderer>().color = Color.black;

        // 위치와 크기 벼경
        clone.transform.position = new Vector3(-2, 1, 0);
        clone.transform.localScale = new Vector3(3, 2, 1);
    }
}
