using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerControllor playerControllor;  //플레이어 컨트롤 스크립트
    CameraController cameraController;  //카메라 컨트롤 스크립트
    GameObject player;  //플레이어 오브젝트
    GameObject cam; //카메라 오브젝트
    Vector3 vEnd;
    private void Awake()
    {
        //플레이어 리소스, 컴포넌트 불러오기
        player = Instantiate(Resources.Load<GameObject>("TrollGiant"));
        player.AddComponent<PlayerControllor>();
        playerControllor = player.GetComponent<PlayerControllor>();
        //카메라 컴포넌트 불러오기
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
                    //오브젝트를 클릭했을 때
                    Debug.Log(hit.transform.gameObject.name);
                }
                else if (hit.collider.CompareTag("Ground"))
                {
                    //땅을 클릭했을 때
                    vEnd = hit.point;   
                }
            }
        }

        //클릭한 위치와 오브젝트의 위치가 다를 때
        if (Vector3.Distance(player.transform.position, vEnd) > 0.1f)
        {
            //이동
            playerControllor.isMove = true;
            playerControllor.vectorEnd = vEnd;
        }
        else
        {
            //정지
            playerControllor.isMove = false;
        }


    }
}
