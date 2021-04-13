using UnityEngine;

public class DebugText : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    void Start()
    {
        print("나는 나야 두밤바");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    private void Awake()
    {
        Debug.Log("여기는 Awake 때 콘솔 창에 메시지를 출력해주는 부분");
    }
}
