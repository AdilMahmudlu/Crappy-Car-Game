using UnityEngine;

public class CheckPoint : MonoBehaviour
{
	public bool canCheck;
	public CheckPoint preCheckPoint;
	public GameObject nextCheckPoint;

	private void Start()
	{
		if (preCheckPoint == null) {
			canCheck = true;	
		} else {
			canCheck = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(canCheck) {
			GameObject.Find("LastCheckPoint").GetComponent<LastCheck>().lastOne = this.gameObject;
			if (nextCheckPoint.name == "FinishLine") {
				nextCheckPoint.GetComponent<Finish>().canFinish = true;
			} else {
				nextCheckPoint.GetComponent<CheckPoint>().canCheck = true;
			}
			canCheck = false;
		}	
	}
}
