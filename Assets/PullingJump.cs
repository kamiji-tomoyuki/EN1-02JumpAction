using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Vector3 clickPosition;
    private bool isCanJump;

    [SerializeField]
    private float jumpPower = 20;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0,-50,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            //クリックした座標と離した座標の差分を取得
            Vector3 dist = clickPosition-Input.mousePosition;
            //クリックとリリースが同じ座標ならば無視
            if(dist.sqrMagnitude == 0 ) { return; }
            //差分を標準化し、jumpPowerをかけ合わせた値を移動量にする
            rb.velocity = dist.normalized * jumpPower;
        }

        if( Input.GetKeyDown(KeyCode.Space) )
        {
            Physics.gravity *= -1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("衝突した");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("接触中");
        //衝突している点の情報が複数格納されている
        ContactPoint[] contacts = collision.contacts;
        //0番目の衝突情報から、衝突している点の法線を取得
        Vector3 otherNormal = contacts[0].normal;
        //上方向ベクトル 長さ1
        Vector3 upVector = new Vector3(0,1,0);
        //上方向と法線の内積
        float dotUN = Vector3.Dot(upVector, otherNormal);
        //内積値に逆三角関数arccosをかけて角度を算出、度数法に変換
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        //2つのベクトルがなす角度が45度より小さければジャンプ可能
        if( dotDeg <= 45 )
        {
            isCanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("離脱した");
        isCanJump = false;
    }
}
