using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public float height;
	public float distance;
	public Transform targetObject;
	public float smoothSpeed = 2f;


    // Update is called once per frame
    void FixedUpdate()
    {
		Vector3 newPosition = targetObject.position + new Vector3(0, height, 0) - targetObject.forward.normalized * distance;
		Vector3 newerPosition = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
		transform.position = newerPosition;
		transform.LookAt(targetObject);
    }
}
