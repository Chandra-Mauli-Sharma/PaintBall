using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
   {
      public Transform target;
      public GameObject player;
     
      void OnTriggerEnter(Collider others)
      {
         CharacterController cc = player.GetComponent<CharacterController>();
 
         cc.enabled = false;
         player.transform.position=target.transform.position;
         cc.enabled = true;
      }
   }