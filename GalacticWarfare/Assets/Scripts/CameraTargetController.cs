using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetController : MonoBehaviour
{
    [SerializeField] private float advanceSpeed;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * advanceSpeed * Time.deltaTime);
    }
}
