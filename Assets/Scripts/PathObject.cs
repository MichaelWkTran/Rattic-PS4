using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathObject : MonoBehaviour
{
    static public List<MovingPlatform> platformsPlayerOn = new List<MovingPlatform>();

    [SerializeField] PathCreator pathCreator;
    [SerializeField] EndOfPathInstruction endOfPath;
    [SerializeField] float distanceOnPath;
    [SerializeField] float moveSpeed;

    [Header("Sprite Path Rotaton")]
    [SerializeField] Transform rotatingTransform;
    [SerializeField] bool rotateAlongPath;
    [SerializeField] float angularOffset;

    void OnValidate()
    {
        if (!pathCreator) return;

        //Set the distanceOnPath to loop to the begining of the path to avoid it reaching over the maximum float value
        distanceOnPath = Mathf.Repeat(distanceOnPath, pathCreator.path.length * 2.0f);

        //Set the platform position to the path
        transform.position = pathCreator.path.GetPointAtDistance(distanceOnPath, endOfPath);

        //Set the platform rotation to the path
        if (rotateAlongPath && rotatingTransform != null)
        {
            Vector3 pathDirection = pathCreator.path.GetDirectionAtDistance(distanceOnPath, endOfPath);
            rotatingTransform.transform.rotation = Quaternion.Euler(0, 0, angularOffset + (Mathf.Atan2(pathDirection.y, pathDirection.x) * Mathf.Rad2Deg));
        }
    }

    void Update()
    {
        //Move the distance the platform is on the path
        distanceOnPath += Time.deltaTime * moveSpeed;

        //Set the distanceOnPath to loop to the begining of the path to avoid it reaching over the maximum float value
        distanceOnPath = Mathf.Repeat(distanceOnPath, pathCreator.path.length * 2.0f);

        //Set the platform position to the path
        transform.position = pathCreator.path.GetPointAtDistance(distanceOnPath);

        //Set the platform rotation to the path
        if (rotateAlongPath)
        {
            Vector3 pathDirection = pathCreator.path.GetDirectionAtDistance(distanceOnPath, endOfPath);
            rotatingTransform.transform.rotation = Quaternion.Euler(0, 0, angularOffset + (Mathf.Atan2(pathDirection.y, pathDirection.x) * Mathf.Rad2Deg));
        }
    }
}
