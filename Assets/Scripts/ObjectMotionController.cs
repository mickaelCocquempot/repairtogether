using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMotionController : MonoBehaviour
{
    private Rigidbody rigidbody;

    public Vector3 velocity;
    public Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = velocity;
        rigidbody.angularVelocity = rotation;
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
