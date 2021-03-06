using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField]private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField]private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField]private Transform pfBulletProjectile;
    [SerializeField]private Transform spawnBulletPosition;
    
    private StarterAssetsInputs starterAssetsInputs;

    private Animator animator;
    private void Awake(){
        starterAssetsInputs =GetComponent<StarterAssetsInputs>();
        animator=GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width/2f,Screen.height/2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(ray,out RaycastHit raycastHit,999f,aimColliderLayerMask)){
            mouseWorldPosition = raycastHit.point;
        }

        if(starterAssetsInputs.aim){
            aimVirtualCamera.gameObject.SetActive(true);
            animator.SetLayerWeight(1,Mathf.Lerp(animator.GetLayerWeight(1),1f,Time.deltaTime * 10f));
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y= transform.position.y;
            Vector3 aimDirection =  (worldAimTarget-transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward,aimDirection,Time.deltaTime * 20f);
                    
            if(starterAssetsInputs.shoot)
            {
                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));  
                starterAssetsInputs.shoot=false;
            }
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            animator.SetLayerWeight(1,Mathf.Lerp(animator.GetLayerWeight(1),0f,Time.deltaTime * 10f));
        }



        if(Input.GetKey(KeyCode.C))
        {
            animator.SetBool("Crouch",true);
        }
        if(Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("Crouch",false);
        }
    }
}
