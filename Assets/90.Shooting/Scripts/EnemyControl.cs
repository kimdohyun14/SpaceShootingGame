using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // 적의 이동속도
    public float EnemySpeed = 50.0f;
    // 적의 Transform Component
    private Transform myTransform = null;
    // 피격 이펙트
    public GameObject Explosion = null;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 적 게임오브젝트의 이동
        Vector3 moveAmount = EnemySpeed * Vector3.back * Time.deltaTime;
        myTransform.Translate(moveAmount);

        // 화면 밖을 나갔다면 위치를 다시 세팅.
        if(myTransform.position.y < -50.0f)
        {
            InitPosition();
        }
    }

    /// <summary>
    /// 내 위치를 초기화해주는 함수.
    /// 중복된 코드가 있다면, 함수로 묶어서 재활용한다.
    /// 실무에서는 이렇게 사용함.
    /// </summary>
    void InitPosition()
    {
        // x축 -60 ~ 60, y축 50, z축 0 으로 다시 셋팅해준다.
        myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f),
            50.0f, 0.0f);
    }

    // 나의 충돌체 영역에 트리거 설정이된 충돌체가 부딪쳤다면 발생되는 이벤트 함수.
    // 물리 이벤트 함수
    private void OnTriggerEnter(Collider other)
    {
        // 총알에 맞았다면.
        if(other.tag == "Bullet")
        {
            // Enemy를 맞췄다면 점수를 100점씩 증가시킨다.
            MainControl.Score += 100; 
            // Debug.Log("Bullet Trigger Enter");
            // 피격 이벤트 생성.
            Instantiate(Explosion, myTransform.position, Quaternion.identity);

            InitPosition();
            Destroy(other.gameObject);
        }

        if(other.tag == "Player")
        {
            //Debug.Log("hit!!");
            MainControl.Life -= 1;
            InitPosition();
        }
    }
}
