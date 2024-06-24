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
        Physics.gravity = new Vector3(0, -50, 0);
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
            //�N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clickPosition - Input.mousePosition;
            //�N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
            if (dist.sqrMagnitude == 0) { return; }
            //������W�������AjumpPower���������킹���l���ړ��ʂɂ���
            rb.velocity = dist.normalized * jumpPower;
        }

        //�d�͑���
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics.gravity = new Vector3(0, -50, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Physics.gravity = new Vector3(0, 50, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Physics.gravity = new Vector3(-50, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Physics.gravity = new Vector3(50, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("�Փ˂���");
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("�ڐG��");
        //�Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;
        //0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾
        Vector3 otherNormal = contacts[0].normal;

        //�����x�N�g�� ����1
        Vector3 jumpVector = new Vector3();
        //�d�͉�
        if (Physics.gravity.y == -50)
        {
            jumpVector = new Vector3(0, 1, 0);
        }
        //�d�͏�
        if (Physics.gravity.y == 50)
        {
            jumpVector = new Vector3(0, -1, 0);
        }
        //�d�͉E
        if (Physics.gravity.x == -50)
        {
            jumpVector = new Vector3(1, 0, 0);
        }
        //�d�͍�
        if (Physics.gravity.x == 50)
        {
            jumpVector = new Vector3(-1, 0, 0);
        }

        //�����Ɩ@���̓���
        float dotUN = Vector3.Dot(jumpVector, otherNormal);
        //���ϒl�ɋt�O�p�֐�arccos�������Ċp�x���Z�o�A�x���@�ɕϊ�
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        //2�̃x�N�g�����Ȃ��p�x��45�x��菬������΃W�����v�\
        if (dotDeg <= 45)
        {
            isCanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("���E����");
        isCanJump = false;
    }
}
