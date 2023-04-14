using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
	public bool canFinish;
	public CheckPoint checkPoint;
	public static bool finished;
	GameObject car;

    void Start()
    {
		finished = false;
		canFinish = false;
		car = GameObject.Find("Car");
    }

	public void OnTriggerEnter() 
	{
		if (canFinish && !finished) {
			GameObject.Find("LastCheckPoint").GetComponent<LastCheck>().lastOne = this.gameObject;
			car.GetComponent<Rigidbody>().velocity *= 0.5f;
			car.GetComponent<PlayerControl>().enabled = false;
			finished = true;
			switch (SceneManager.GetActiveScene().buildIndex)
			{
				case 1:
					if (PlayerPrefs.GetFloat("Level1") > GameManager.timer || PlayerPrefs.GetFloat("Level1") == 0)
					{
						PlayerPrefs.SetFloat("Level1", GameManager.timer);
					}
					break;
				case 2:
					if (PlayerPrefs.GetFloat("Level2") > GameManager.timer || PlayerPrefs.GetFloat("Level2") == 0)
					{
						PlayerPrefs.SetFloat("Level2", GameManager.timer);
					}
					break;
				case 3:
					if (PlayerPrefs.GetFloat("Level3") > GameManager.timer || PlayerPrefs.GetFloat("Level3") == 0)
					{
						PlayerPrefs.SetFloat("Level3", GameManager.timer);
					}
					break;
				case 4:
					if (PlayerPrefs.GetFloat("Level4") > GameManager.timer || PlayerPrefs.GetFloat("Level4") == 0)
					{
						PlayerPrefs.SetFloat("Level4", GameManager.timer);
					}
					break;
				case 5:
					if (PlayerPrefs.GetFloat("Level5") > GameManager.timer || PlayerPrefs.GetFloat("Level5") == 0)
					{
						PlayerPrefs.SetFloat("Level5", GameManager.timer);
					}
					break;
				case 6:
					if (PlayerPrefs.GetFloat("Level6") > GameManager.timer || PlayerPrefs.GetFloat("Level6") == 0)
					{
						PlayerPrefs.SetFloat("Level6", GameManager.timer);
					}
					break;
				default:
					Debug.Log("ERROR");
					break;
			}
			Debug.Log("Finished");
		}
	}
}
