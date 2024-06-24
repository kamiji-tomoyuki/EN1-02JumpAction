using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    private Vector3 clickPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 dist = clickPosition-Input.mousePosition;
            //ベクトルの長さを算出
            float size = dist.magnitude;
            //ベクトルから角度(弧度法)を算出
            float angleRad = Mathf.Atan2(dist.y,dist.x);
            //Arrowの画像をクリックした場所に移動
            arrowImage.rectTransform.position = clickPosition;
            //Arrowの画像をベクトルから算出した角度を度数に変換してZ軸回転
            arrowImage.rectTransform.rotation
                = Quaternion.Euler(0,0,angleRad * Mathf.Rad2Deg);
            //Arrowの画像の大きさをドラッグした距離にあわせる
            arrowImage.rectTransform.sizeDelta = new Vector2(size,size);
        }
    }
}
