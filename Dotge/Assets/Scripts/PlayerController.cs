using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Rigidbody 프로퍼티, 속도 값
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //키보드 입력 이벤트 화살표 조종
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;

    }
    //게임오버 이벤트
    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
