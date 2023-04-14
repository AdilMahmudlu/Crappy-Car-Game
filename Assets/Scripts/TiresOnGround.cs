using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiresOnGround : MonoBehaviour
{
	public bool onGround;
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Tires") {
			onGround = true;
		}
	}
	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider.tag == "Tires") {
			onGround = true;
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.tag != "Road") {
			onGround = false;
		}
	}
}
