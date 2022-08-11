using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerControllor playerControllor;  //�÷��̾� ��Ʈ�� ��ũ��Ʈ
    CameraController cameraController;  //ī�޶� ��Ʈ�� ��ũ��Ʈ
    GameObject player;  //�÷��̾� ������Ʈ
    GameObject cam; //ī�޶� ������Ʈ
    Vector3 vEnd;
    private void Awake()
    {
        //�÷��̾� ���ҽ�, ������Ʈ �ҷ�����
        player = Instantiate(Resources.Load<GameObject>("TrollGiant"));
        player.AddComponent<PlayerControllor>();
        playerControllor = player.GetComponent<PlayerControllor>();
        //ī�޶� ������Ʈ �ҷ�����
        cam = GameObject.FindWithTag("MainCamera");
        cameraController = cam.GetComponent<CameraController>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    //������Ʈ�� Ŭ������ ��
                    Debug.Log(hit.transform.gameObject.name);
                }
                else if (hit.collider.CompareTag("Ground"))
                {
                    //���� Ŭ������ ��
                    vEnd = hit.point;   
                }
            }
        }

        //Ŭ���� ��ġ�� ������Ʈ�� ��ġ�� �ٸ� ��
        if (Vector3.Distance(player.transform.position, vEnd) > 0.1f)
        {
            //�̵�
            playerControllor.isMove = true;
            playerControllor.vectorEnd = vEnd;
        }
        else
        {
            //����
            playerControllor.isMove = false;
        }


    }
}
