using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerPath : MonoBehaviour
{

    public enum MovementType
    {
        Moving,
        Lerping
    }
    public MovementType Type = MovementType.Moving;
    public MovementPath MyPath;
    public float speed = 1;
    public float maxDistance = .1f;
    public float speed_rotation;


    private IEnumerator<Transform> pointInPath;

    // Start is called before the first frame update
    void Start()
    {
        if (MyPath == null)
        {
            return;
        }

        pointInPath = MyPath.GetNextPathPoint().GetEnumerator();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            return;
        }
        transform.position = pointInPath.Current.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            return;
        }
        if (Type == MovementType.Moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        else if (Type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        Vector3 newDir = Vector3.RotateTowards(transform.forward, (pointInPath.Current.position - transform.position), 1, 0.0F);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newDir), Time.deltaTime * speed_rotation);

        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSqure < maxDistance * maxDistance)
        {
            if (pointInPath.MoveNext() == false)
            {
                pointInPath = null;
            }
        }




    }
}
