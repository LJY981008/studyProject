using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset; //ī�޶��� ��ġ(�÷��̾���� �Ÿ�)
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = transform.position;
    }
    void Update()
    {
        setCamera();    
    }
    public void setCamera()
    {
        //ī�޶�� �÷��̾��� �Ÿ��� �ΰ� �÷��̾��� �̵��Ÿ���ŭ ī�޶� �̵�
        transform.position = player.transform.position + offset;
    }

}
