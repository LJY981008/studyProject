using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    private Animator animator;
    private Vector3 vectorDir;
    private Vector3 vectorRot;

    public float speed = 2f;    //�̵� �ӵ�
    public bool isMove { get; set; }
    public Vector3 vectorEnd { get; set; }
    

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //�̵� ���� �ƴ� ��
        if (!isMove)
        {
            //���ִ� �ִϸ��̼��� ��� 
            animator.SetInteger("iAniIndex", 0);
        }
        else
        {
            Move();
            animator.SetInteger("iAniIndex", 1);
        }
    }


    public void Move()
    {
        vectorDir = vectorEnd - transform.position;
        vectorRot = Vector3.RotateTowards(transform.forward, vectorDir.normalized, Time.deltaTime * speed, 0f);
        transform.position = Vector3.MoveTowards(transform.position, vectorEnd, Time.deltaTime * speed);
        transform.rotation = Quaternion.LookRotation(vectorRot);
    }

}
