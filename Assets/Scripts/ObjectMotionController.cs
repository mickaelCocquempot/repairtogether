using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMotionController : MonoBehaviour
{
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetMotion(Vector3 velocity, Vector3 angularVelocity)
    {
        rigidbody.velocity = velocity;
        rigidbody.angularVelocity = angularVelocity;
    }

    void Lock()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    void UnLock()
    {
        rigidbody.constraints = RigidbodyConstraints.None;
    }
}
