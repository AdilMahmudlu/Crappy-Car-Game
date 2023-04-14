using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlManager : MonoBehaviour
{
	Event keyEvent;
	Text buttonText;
	KeyCode newKey;

	bool waitingForKey;

	void Start()
	{
		waitingForKey = false;
		for (int i = transform.childCount - 1; i >= 0; i--)
		{
			if (transform.GetChild(i).name == "WButton")
			{
				transform.GetChild(i).GetComponentInChildren<Text>().text = Controls.Instance.Forward.ToString();
			}
			else if (transform.GetChild(i).name == "SButton")
			{
				transform.GetChild(i).GetComponentInChildren<Text>().text = Controls.Instance.Backward.ToString();
			}
			else if (transform.GetChild(i).name == "AButton")
			{
				transform.GetChild(i).GetComponentInChildren<Text>().text = Controls.Instance.Left.ToString();
			}
			else if (transform.GetChild(i).name == "DButton")
			{
				transform.GetChild(i).GetComponentInChildren<Text>().text = Controls.Instance.Right.ToString();
			}
			else if (transform.GetChild(i).name == "SBButton")
			{
				transform.GetChild(i).GetComponentInChildren<Text>().text = Controls.Instance.Jump.ToString();
			}
			else if (transform.GetChild(i).name == "QButton")
			{
				transform.GetChild(i).GetComponentInChildren<Text>().text = Controls.Instance.AirRollLeft.ToString();
			}
			else if (transform.GetChild(i).name == "EButton")
			{
				transform.GetChild(i).GetComponentInChildren<Text>().text = Controls.Instance.AirRollRight.ToString();
			}
			else if (transform.GetChild(i).name == "RButton")
			{
				transform.GetChild(i).GetComponentInChildren<Text>().text = Controls.Instance.Restart.ToString();
			}
		}
	}

	void Update()
	{
		
	}

	private void OnGUI()
	{
		keyEvent = Event.current;
		if (keyEvent.isKey && waitingForKey) {
			newKey = keyEvent.keyCode;
			waitingForKey = false;
		}
	}

	public void StartAssignment(string keyName) {
		if(!waitingForKey) {
			StartCoroutine(AssignKey(keyName));
		}
	}

	public void SendText(Text text)
	{
		buttonText = text;
	}

	IEnumerator WaitForKey() {
		while(!keyEvent.isKey) {
			yield return null;
		}
	}

	public IEnumerator AssignKey(string keyName) {
		waitingForKey = true;
		yield return WaitForKey();
		switch(keyName) {
			case "forward":
				Controls.Instance.Forward = newKey;
				buttonText.text = Controls.Instance.Forward.ToString();
				PlayerPrefs.SetString("forward", Controls.Instance.Forward.ToString());
				break;
			case "backward":
				Controls.Instance.Backward = newKey;
				buttonText.text = Controls.Instance.Backward.ToString();
				PlayerPrefs.SetString("backward", Controls.Instance.Backward.ToString());
				break;
			case "left":
				Controls.Instance.Left = newKey;
				buttonText.text = Controls.Instance.Left.ToString();
				PlayerPrefs.SetString("left", Controls.Instance.Left.ToString());
				break;
			case "right":
				Controls.Instance.Right = newKey;
				buttonText.text = Controls.Instance.Right.ToString();
				PlayerPrefs.SetString("right", Controls.Instance.Right.ToString());
				break;
			case "jump":
				Controls.Instance.Jump = newKey;
				buttonText.text = Controls.Instance.Jump.ToString();
				PlayerPrefs.SetString("jump", Controls.Instance.Jump.ToString());
				break;
			case "arleft":
				Controls.Instance.AirRollLeft = newKey;
				buttonText.text = Controls.Instance.AirRollLeft.ToString();
				PlayerPrefs.SetString("arleft", Controls.Instance.AirRollLeft.ToString());
				break;
			case "arright":
				Controls.Instance.AirRollRight = newKey;
				buttonText.text = Controls.Instance.AirRollRight.ToString();
				PlayerPrefs.SetString("arright", Controls.Instance.AirRollRight.ToString());
				break;
			case "restart":
				Controls.Instance.Restart = newKey;
				buttonText.text = Controls.Instance.Restart.ToString();
				PlayerPrefs.SetString("restart", Controls.Instance.Restart.ToString());
				break;
		}
		yield return null;
	}
}
