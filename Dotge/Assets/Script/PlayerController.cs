using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Rigidbody ������Ƽ, �ӵ� ��
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    
    void Update()
    {
        //Ű���� �Է� �̺�Ʈ ȭ��ǥ ����
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }

    }
    //���ӿ��� �̺�Ʈ
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
