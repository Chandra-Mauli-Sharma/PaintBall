using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private Transform vfxHit;
    private Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        float speed = 40f;
        bulletRigidbody.velocity = transform.forward*speed;
    }

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(vfxHit,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
