using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManagerObject : MonoBehaviour
{
    public string nextSceneName;

    public string thisStageName;
    public string nextStageName;

    // Update is called once per frame
    void Update()
    {
        //タイトル -> ゲーム
        if (Input.GetKeyDown(KeyCode.Space) && thisStageName == "Title")
        {
            SceneManager.LoadScene(nextSceneName);
        }

        //ゲーム
        if (thisStageName != "Title")
        {
            //クリアアイテムの取得
            bool IsCleared = ClearItem.IsCleared;

            //リセット
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(thisStageName);
                Floating.gravity = -30;
            }

            //クリア時のシーン処理
            if (IsCleared == true && Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(nextStageName);
                Floating.gravity = -30;
            }
        }
    }
}
