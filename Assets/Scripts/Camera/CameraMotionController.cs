using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotionController : MonoBehaviour
{

    [SerializeField]
    private GameObject CenterGameOject;
    [SerializeField]
    private float Speed;

    private float radius;

    private Vector3 mCenter;

    private float theta = 0f;
    private float phi = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 30F;
        radius = 2F;
    }

    // Update is called once per frame
    void Update()
    {
        mCenter = CenterGameOject.transform.position;
        transform.LookAt(CenterGameOject.transform);

        //Test
        //        Debug.Log(Vector3.Distance(transform.position, CenterGameOject.transform.position));

        if (/*Vector3.Distance(transform.position, CenterGameOject.transform.position) > radius &&*/ Input.mouseScrollDelta.y != 0)
        {
            if(Input.mouseScrollDelta.y == 1)
                transform.Translate(0, 0, 1F);
            else if (Input.mouseScrollDelta.y == -1)
                transform.Translate(0, 0, -1F);
        }
        if (Input.GetKey(KeyCode.Mouse0))
            MoveUp();
        if (Input.GetKey(KeyCode.Mouse1))
            MoveRight();


    }

    public void MoveDistanceFromObject()
    {
        if (/*Vector3.Distance(transform.position, CenterGameOject.transform.position) > radius &&*/ Input.mouseScrollDelta.y != 0)
        {
            if (Input.mouseScrollDelta.y == 1)
                transform.Translate(0, 0, 1F);
            else if (Input.mouseScrollDelta.y == -1)
                transform.Translate(0, 0, -1F);
        }
    }

    public void MoveLeft()
    {
        transform.RotateAround(mCenter, CenterGameOject.transform.up, Speed * Time.deltaTime);
        transform.LookAt(CenterGameOject.transform);
    }

    public void MoveLeft(float iSpeed)
    {

        transform.RotateAround(mCenter, CenterGameOject.transform.up, Speed * iSpeed * Time.deltaTime);
        transform.LookAt(CenterGameOject.transform);
    }

    public void MoveRight()
    {
        transform.RotateAround(mCenter, -CenterGameOject.transform.up, Speed * Time.deltaTime);
        transform.LookAt(CenterGameOject.transform);
    }

    public void MoveRight(float iSpeed)
    {
        transform.RotateAround(mCenter, -CenterGameOject.transform.up, Speed * iSpeed * Time.deltaTime);
        transform.LookAt(CenterGameOject.transform);
    }

    public void MoveUp()
    {
        transform.RotateAround(mCenter, transform.right, Speed * Time.deltaTime);
        transform.LookAt(CenterGameOject.transform);
    }

    public void MoveUp(float iSpeed)
    {
        transform.RotateAround(mCenter, transform.right, Speed* iSpeed * Time.deltaTime);
        transform.LookAt(CenterGameOject.transform);
    }

    public void MoveDown()
    {
        transform.RotateAround(mCenter, -transform.right, Speed * Time.deltaTime);
        transform.LookAt(CenterGameOject.transform);
    }

    public void MoveDown(float iSpeed)
    {
        transform.RotateAround(mCenter, -transform.right, Speed * iSpeed * Time.deltaTime);
        transform.LookAt(CenterGameOject.transform);
    }


}

