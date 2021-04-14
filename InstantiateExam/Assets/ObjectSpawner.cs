using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject boxPrefab;

    private void Awake()
    {
        // 1. Instantiate(����������Ʈ);

        // 2. Instantiate(����������Ʈ, ��ġ, ȸ��);
        //Instantiate(boxPrefab, new Vector3(3, 0, 0), Quaternion.identity);
        //Instantiate(boxPrefab, new Vector3(0, -2, 0), Quaternion.identity);


        // 3. quaternion ȸ����
        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        // Instantiate(boxPrefab, new Vector3(2, 1, 0), rotation);

        // 4. Instantiate�� ��ȯ���� �ش� ���ӿ�����Ʈ
        GameObject clone = Instantiate(boxPrefab, Vector3.zero, rotation);

        // ������ ������Ʈ �̸� ����
        clone.name = "Box001";

        // ������ ������Ʈ ���� ����
        clone.GetComponent<SpriteRenderer>().color = Color.black;

        // ��ġ�� ũ�� ����
        clone.transform.position = new Vector3(-2, 1, 0);
        clone.transform.localScale = new Vector3(3, 2, 1);
    }
}
