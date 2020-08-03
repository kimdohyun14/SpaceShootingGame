using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // 플레이어 비행체의 이동 속도
    public float Speed = 15.0f;
    // 플레이어 게임오브젝트의 Transform 컴포넌트
    private Transform myTransform = null;
    // 플레이어가 생성하게 될 원본 총알 프리팝
    public GameObject BulletPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        // Transform 컴포넌트를 캐싱.
        myTransform = GetComponent<Transform>();
        // myTransform = GetComponent("Transform") as Transform;
    }

    // Update is called once per frame
    void Update()
    {
        // [이동]
        // -1 ~ 1 왼쪽 화살키(-1) 오른쪽 화살키(1)
        float axis = Input.GetAxis("Horizontal");
        //Debug.Log("axis : " + axis);

        // FPS frame per second,
        // 30 FPS : 1초에 30번 호출
        // 매 프레임당 이 게임 오브젝트가 우리가 원하는 속도와 방향으로 이동하는 양.
        Vector3 moveAmount = axis * Speed * -Vector3.right * Time.deltaTime;

        // 플레이어가 해당 카메라를 벗어나지 않도록 해준다.
        // 플레이어의 x는 -60 ~ 60 사이로만 움직일 수 있게 해주고,
        if(myTransform.position.x <= 60.0f && myTransform.position.x >= -60.0f)
        {
            myTransform.Translate(moveAmount);
        }
        // 60을 초과해버리면, 플레이어의 위치를 59로 셋팅해준다.
        else if(myTransform.position.x > 60.0f)
        {
            myTransform.position = new Vector3(59.0f, myTransform.position.y, myTransform.position.z);
        }
        // -60으로 미만해버리면, 플레이어의 위치를 -59로 셋팅해준다.
        else
        {
            myTransform.position = new Vector3(-59.0f, myTransform.position.y, myTransform.position.z);
        }
        
        

        // [슈팅]
        // space bar 키가 눌렸다면.
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            // BulletPrefab을 현재 내가 있는 위치에서 회전을 시키지 않은 상태로 인스턴싱.
            Instantiate(BulletPrefab, myTransform.position, Quaternion.identity);
        }
    }
}
