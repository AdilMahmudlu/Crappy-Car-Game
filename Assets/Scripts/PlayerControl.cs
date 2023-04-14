using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float Speed;
	public float RotationSpeed;
	public float JumpForce;
	public float downForce;
	Rigidbody car;
	public LastCheck saved;
	public bool grounded;
	public GameObject Ground;

	private void Start()
	{
		car = FindObjectOfType<PlayerControl>().GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Road")
		{
			Ground = collision.collider.gameObject;
		} 
	}

	private void Update()
	{
		if (grounded) {
			if (Input.GetKey(Controls.Instance.Forward))
			{
				car.AddForce(car.transform.forward * Speed * Time.deltaTime);
			}
			if (Input.GetKey(Controls.Instance.Backward))
			{
				car.AddForce(-car.transform.forward * Speed * Time.deltaTime);
			}
			if (Input.GetKey(Controls.Instance.Left))
			{
				car.transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0);
			}
			if (Input.GetKey(Controls.Instance.Right))
			{
				car.transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
			}
		}
		
		
		if (Input.GetKey(Controls.Instance.Restart)) {
			if (saved.lastOne == null) {
				car.transform.position = new Vector3(0, 2.75f, -5);
				car.transform.rotation = Quaternion.identity;
			}
			else
			{
				car.transform.position = saved.lastOne.transform.position + new Vector3(0, 2, 0);
				car.transform.rotation = saved.lastOne.transform.rotation;
			}
			car.GetComponent<Rigidbody>().velocity = Vector3.zero;
			car.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}

		if (Ground == null) {
			grounded = false;
		} else {
			grounded = Ground.GetComponent<TiresOnGround>().onGround;
		}
		
		if (!grounded) {
			if (Input.GetKey(Controls.Instance.Forward)) {
				car.angularVelocity = Vector3.zero;
				car.transform.Rotate(RotationSpeed * Time.deltaTime, 0, 0);
			}
			if (Input.GetKey(Controls.Instance.Backward)) {
				car.angularVelocity = Vector3.zero;
				car.transform.Rotate(-RotationSpeed * Time.deltaTime, 0, 0);
			}
			if (Input.GetKey(Controls.Instance.AirRollLeft)) {
				car.angularVelocity = Vector3.zero;
				car.transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
			}
			if (Input.GetKey(Controls.Instance.AirRollRight)) {
				car.angularVelocity = Vector3.zero;
				car.transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime);
			}
			if (Input.GetKey(Controls.Instance.Left)) {
				car.angularVelocity = Vector3.zero;
				car.transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0);
			}
			if (Input.GetKey(Controls.Instance.Right)) {
				car.angularVelocity = Vector3.zero;
				car.transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
			}
 		}

		if (Input.GetKeyDown(Controls.Instance.Jump)) 
		{
			if (grounded) 
			{
				car.AddForce(car.transform.up * JumpForce);
			}
		}
		if (grounded) {
			car.AddForce(-car.transform.up.normalized * downForce * Time.deltaTime);
		}

		car.AddForce(new Vector3(0, -1, 0) * downForce * Time.deltaTime);

		if (Vector3.Angle(car.velocity.normalized, car.transform.forward) >= 60 && grounded) {
			car.velocity /= 1.0025f;
		}
	}
}