using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float BulletSpeed = 100.0f;
    private Transform myTransform = null;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveAmount = BulletSpeed * Vector3.up * Time.deltaTime;
        myTransform.Translate(moveAmount);

        // 화면 밖으로 나갔다면.
        if(myTransform.position.y > 60.0f)
        {
            // 해당 오브젝트를 사라지게 합니다.
            Destroy(gameObject); // gameObject는 BulletPrefab을 말한다.
        }
    }
}
