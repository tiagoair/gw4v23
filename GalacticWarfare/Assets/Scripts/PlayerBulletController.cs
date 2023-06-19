using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeToLive;
    

    private void Start()
    {
        Invoke("DestroyBullet", timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);    
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
