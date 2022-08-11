using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    private Animator animator;
    private Vector3 vectorDir;
    private Vector3 vectorRot;

    public float speed = 2f;    //이동 속도
    public bool isMove { get; set; }
    public Vector3 vectorEnd { get; set; }
    

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //이동 중이 아닐 때
        if (!isMove)
        {
            //서있는 애니메이션을 재생 
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
