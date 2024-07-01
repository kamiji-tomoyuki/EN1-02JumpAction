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
        //�^�C�g�� -> �Q�[��
        if (Input.GetKeyDown(KeyCode.Space) && thisStageName == "Title")
        {
            SceneManager.LoadScene(nextSceneName);
        }

        //�Q�[��
        if (thisStageName != "Title")
        {
            //�N���A�A�C�e���̎擾
            bool IsCleared = ClearItem.IsCleared;

            //���Z�b�g
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(thisStageName);
                Floating.gravity = -30;
            }

            //�N���A���̃V�[������
            if (IsCleared == true && Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(nextStageName);
                Floating.gravity = -30;
            }
        }
    }
}
