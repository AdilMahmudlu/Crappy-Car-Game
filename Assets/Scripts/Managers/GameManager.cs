using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject finishMenu;
	public Text scoreText;
	public GameObject scoreTimer;
	public GameObject pauseMenu;
	bool paused;
	public GameObject car;
	public static float timer;

	private void Start()
	{
		Time.timeScale = 1;
		scoreTimer.SetActive(true);
		finishMenu.SetActive(false);
		pauseMenu.SetActive(false);
		paused = false;
		timer = -3f;
		car = GameObject.Find("Car");
		car.GetComponent<PlayerControl>().enabled = false;
		GameObject.FindObjectOfType<FollowPlayer>().GetComponent<FollowPlayer>().enabled = true;
	}
	private void FixedUpdate()
	{
		if (!Finish.finished)
		{
			timer += Time.deltaTime;
			if (timer >= 0)
			{
				car.GetComponent<PlayerControl>().enabled = true;
			}
			else
			{
				car.GetComponent<PlayerControl>().enabled = false;
			}
		}
		if (timer <= 0)
		{
			scoreTimer.GetComponent<Text>().color = Color.red;
			scoreTimer.GetComponent<Text>().text = Mathf.Abs(timer).ToString("0");
		}
		else
		{
			scoreTimer.GetComponent<Text>().color = Color.black;
			scoreTimer.GetComponent<Text>().text = timer.ToString("0.00");
		}
		if (Finish.finished)
		{
			GameObject.FindObjectOfType<FollowPlayer>().GetComponent<FollowPlayer>().enabled = false;
			Invoke("ScreenChange", 2f);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!paused)
			{
				Pause();
			}
			else
			{
				Resume();
			}
		}
	}

	public void ScreenChange()
	{
		scoreTimer.SetActive(false);
		scoreText.text = timer.ToString("0.00");
		finishMenu.SetActive(true);
	}
	public void Pause()
	{
		Time.timeScale = 0f;
		paused = true;
		pauseMenu.SetActive(true);
	}
	public void Resume()
	{
		Time.timeScale = 1f;
		paused = false;
		pauseMenu.SetActive(false);
	}
	public void Restart()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void NextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void MainMenu() {
		SceneManager.LoadScene(0);
	}
}