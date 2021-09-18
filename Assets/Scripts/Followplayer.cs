using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Followplayer : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Cinemachine Target") !=null)
            virtualCamera.Follow=GameObject.FindGameObjectWithTag("Cinemachine Target").transform;
    }
}
