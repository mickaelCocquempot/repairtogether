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
    // Start is called before the first frame update
    void Start()
    {
        mCenter = CenterGameOject.transform.position;
        Speed = 30F;
        radius = 2F;
    }

    // Update is called once per frame
    void Update()
    {

        //Test
        Debug.Log(Vector3.Distance(transform.position, CenterGameOject.transform.position));

        if (/*Vector3.Distance(transform.position, CenterGameOject.transform.position) > radius &&*/ Input.mouseScrollDelta.y != 0)
        {
            if (Input.mouseScrollDelta.y == 1)
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
        transform.RotateAround(mCenter, Vector3.up, Speed * Time.deltaTime);
    }

    public void MoveLeft(float iSpeed)
    {
        transform.RotateAround(mCenter, Vector3.up, iSpeed * Time.deltaTime);
    }

    public void MoveRight()
    {
        transform.RotateAround(mCenter, Vector3.down, Speed * Time.deltaTime);
    }

    public void MoveRight(float iSpeed)
    {
        transform.RotateAround(mCenter, Vector3.down, iSpeed * Time.deltaTime);
    }

    public void MoveUp()
    {
        transform.RotateAround(mCenter, Vector3.right, Speed * Time.deltaTime);
    }

    public void MoveUp(float iSpeed)
    {
        transform.RotateAround(mCenter, Vector3.right, iSpeed * Time.deltaTime);
    }

    public void MoveDown()
    {
        transform.RotateAround(mCenter, Vector3.left, Speed * Time.deltaTime);
    }

    public void MoveDown(float iSpeed)
    {
        transform.RotateAround(mCenter, Vector3.left, iSpeed * Time.deltaTime);
    }


}

