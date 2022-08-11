using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset; //카메라의 위치(플레이어와의 거리)
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
        //카메라와 플레이어의 거리를 두고 플레이어의 이동거리만큼 카메라 이동
        transform.position = player.transform.position + offset;
    }

}
