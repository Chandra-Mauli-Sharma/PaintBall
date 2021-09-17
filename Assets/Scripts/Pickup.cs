using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform theDest;
    public GameObject fire;
    public GameObject steam;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position=theDest.position;
            this.transform.parent = GameObject.Find("Pick").transform;
        }
    }
    void OnMouseDown()
    {
        Destroy(fire);
        steam.SetActive(true);
    }
}
