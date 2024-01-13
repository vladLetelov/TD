using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes
    {
        linear,
        loop
    }
    public int movementDirection = 1;
    public int MoveingTo = 0;
    public Transform[] PathElements;
    public PathTypes PathType;



    public void OnDrawGizmos()
    {
        if (PathElements == null || PathElements.Length < 2)
        {
            return;
        }

        for (var i = 1; i < PathElements.Length; i++)
        {
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);
        }

        if (PathType == PathTypes.loop)
        {
            Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);
        }
    }

    public GameObject MovingObject;
    public IEnumerable<Transform> GetNextPathPoint()

    {
        if (PathElements == null || PathElements.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return PathElements[MoveingTo];

            if (PathElements.Length == 1)
            {
                continue;
            }

            if (PathType == PathTypes.linear)
            {
                if (MoveingTo <= 0)
                {
                    movementDirection = 1;
                }
                else if (MoveingTo >= PathElements.Length - 1)
                {
                    movementDirection = -1;
                }
            }

            MoveingTo = MoveingTo + movementDirection;

            if (PathType == PathTypes.loop)
            {
                if (MoveingTo >= PathElements.Length)
                {
                    MoveingTo = 0;
                }
                if (MoveingTo < 0)
                {
                    MoveingTo = PathElements.Length - 1;
                }
            }

            if (MoveingTo == PathElements.Length - 1)
            {
                Destroy(MovingObject);
            }
        }
    }

    public IEnumerator<Transform> GetClosestPathPoint(Vector3 currentPosition)
    {
        if (PathElements == null || PathElements.Length < 1)
            yield break;

        var closestPoint = PathElements[0];
        var minDistance = Vector3.Distance(currentPosition, closestPoint.position);

        for (int i = 1; i < PathElements.Length; i++)
        {
            var distance = Vector3.Distance(currentPosition, PathElements[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestPoint = PathElements[i];
            }
        }

        yield return closestPoint;
    }
}
