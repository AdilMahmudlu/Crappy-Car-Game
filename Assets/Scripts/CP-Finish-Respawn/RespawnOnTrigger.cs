using UnityEngine;

public class RespawnOnTrigger : MonoBehaviour
{
	public LastCheck saved;

	
	private void OnTriggerEnter(Collider other)
	{
		GameObject collider = GameObject.Find("Car");
		if (saved.lastOne == null)
		{
			collider.transform.position = new Vector3(0, 2.75f, -5);
			collider.transform.rotation = Quaternion.identity;
		}
		else
		{
			collider.transform.position = saved.lastOne.transform.position + new Vector3(0, 2, 0);
			collider.transform.rotation = saved.lastOne.transform.rotation;
		}
		collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
		collider.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
	}
}
