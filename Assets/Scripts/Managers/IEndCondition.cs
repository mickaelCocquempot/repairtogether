using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndCondition
{
    public enum ENDCONDITION { POSOR,POSFIN, LASER};
    public abstract class IEndCondition
    {
        public abstract void update(ObjectMotionController obj);
        public abstract bool isFinished(ObjectMotionController obj);
        public abstract void end(ObjectMotionController obj, float time);
    }

    public class PositionFinish : IEndCondition
    {
        public Transform targetTransform;
        public PositionFinish(Transform target)
        {
            targetTransform = target;
        }
        public override void update(ObjectMotionController obj)
        {

        }
        public override bool isFinished(ObjectMotionController obj)
        {
            return Vector3.Distance(targetTransform.position, obj.transform.position) < 0.3f;
        }

        public override void end(ObjectMotionController obj, float time)
        {
            obj.GetComponent<Collider>().enabled = false;
            obj.transform.position = Vector3.Lerp(obj.transform.position, targetTransform.position, time / 10.0f);
            obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, targetTransform.rotation, time / 10.0f);
        }
    }

    public class PositionOrientationFinish : IEndCondition
    {
        public Transform targetTransform;
        public PositionOrientationFinish(Transform target)
        {
            targetTransform = target;
        }
        public override void update(ObjectMotionController obj)
        {

        }
        public override bool isFinished(ObjectMotionController obj)
        {
            return Vector3.Distance(targetTransform.position, obj.transform.position) < 0.3f && Quaternion.Angle(targetTransform.rotation, obj.transform.rotation) < 5f;
        }

        public override void end(ObjectMotionController obj, float time)
        {
            obj.GetComponentInChildren<Collider>().enabled = false;
            obj.transform.position = Vector3.Lerp(obj.transform.position, targetTransform.position, time / 10.0f);
            obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, targetTransform.rotation, time / 10.0f);
        }
    }

    public class LaserFinish : IEndCondition
    {
        public List<GameObject> targets;
        public List<GameObject> lasered = new List<GameObject>();
        public LaserFinish(List<GameObject> path)
        {
            targets = path;
        }
        public override void update(ObjectMotionController obj)
        {
            int layerMask = 1 << 9;
            RaycastHit hit;

            if (Physics.Raycast(obj.transform.position, obj.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(obj.transform.position, obj.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                if (!lasered.Contains(hit.transform.gameObject))
                    lasered.Add(hit.transform.gameObject);
            }
            else
            {
                Debug.DrawRay(obj.transform.position, obj.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
        public override bool isFinished(ObjectMotionController obj)
        {
            return targets.Count == lasered.Count;
        }

        public override void end(ObjectMotionController obj, float time)
        {
        }
    }
}
