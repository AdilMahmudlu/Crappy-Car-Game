using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
	public GameObject MainMenu;
	public GameObject LevelsMenu;
	public GameObject HowToPlayMenu;
	public GameObject ControlsMenu;
	public bool resetMode;
	public Text score1;
	public Text score2;
	public Text score3;
	public Text score4;
	public Text score5;
	public Text score6;

	private void Start() {
		MainMenu.SetActive(true);
		LevelsMenu.SetActive(false);
		HowToPlayMenu.SetActive(false);
		ControlsMenu.SetActive(false);
		resetMode = false;
		score1.text = PlayerPrefs.GetFloat("Level1", 0).ToString("0.00");
		score2.text = PlayerPrefs.GetFloat("Level2", 0).ToString("0.00");
		score3.text = PlayerPrefs.GetFloat("Level3", 0).ToString("0.00");
		score4.text = PlayerPrefs.GetFloat("Level4", 0).ToString("0.00");
		score5.text = PlayerPrefs.GetFloat("Level5", 0).ToString("0.00");
		score6.text = PlayerPrefs.GetFloat("Level6", 0).ToString("0.00");
	}

	public void Level1() {
		if (resetMode) {
			PlayerPrefs.SetFloat("Level1", 0);
			score1.text = PlayerPrefs.GetFloat("Level1").ToString("0.00");
			resetMode = false;
			score1.color = Color.white;
			score2.color = Color.white;
			score3.color = Color.white;
			score4.color = Color.white;
			score5.color = Color.white;
			score6.color = Color.white;
		}
		else
		{
			SceneManager.LoadScene(1);
		}
	}
	public void Level2()
	{
		if (resetMode)
		{
			PlayerPrefs.SetFloat("Level2", 0);
			score2.text = PlayerPrefs.GetFloat("Level2").ToString("0.00");
			resetMode = false;
			score1.color = Color.white;
			score2.color = Color.white;
			score3.color = Color.white;
			score4.color = Color.white;
			score5.color = Color.white;
			score6.color = Color.white;
		}
		else
		{
			SceneManager.LoadScene(2);
		}
	}
	public void Level3()
	{
		if (resetMode)
		{
			PlayerPrefs.SetFloat("Level3", 0);
			score3.text = PlayerPrefs.GetFloat("Level3").ToString("0.00");
			resetMode = false;
			score1.color = Color.white;
			score2.color = Color.white;
			score3.color = Color.white;
			score4.color = Color.white;
			score5.color = Color.white;
			score6.color = Color.white;
		}
		else
		{
			SceneManager.LoadScene(3);
		}
	}
	public void Level4()
	{
		if (resetMode)
		{
			PlayerPrefs.SetFloat("Level4", 0);
			score4.text = PlayerPrefs.GetFloat("Level4").ToString("0.00");
			resetMode = false;
			score1.color = Color.white;
			score2.color = Color.white;
			score3.color = Color.white;
			score4.color = Color.white;
			score5.color = Color.white;
			score6.color = Color.white;
		}
		else
		{
			SceneManager.LoadScene(4);
		}
	}
	public void Level5()
	{
		if (resetMode)
		{
			PlayerPrefs.SetFloat("Level5", 0);
			score5.text = PlayerPrefs.GetFloat("Level5").ToString("0.00");
			resetMode = false;
			score1.color = Color.white;
			score2.color = Color.white;
			score3.color = Color.white;
			score4.color = Color.white;
			score5.color = Color.white;
			score6.color = Color.white;
		}
		else
		{
			SceneManager.LoadScene(5);
		}
	}
	public void Level6()
	{
		if (resetMode)
		{
			PlayerPrefs.SetFloat("Level6", 0);
			score6.text = PlayerPrefs.GetFloat("Level6").ToString("0.00");
			resetMode = false;
			score1.color = Color.white;
			score2.color = Color.white;
			score3.color = Color.white;
			score4.color = Color.white;
			score5.color = Color.white;
			score6.color = Color.white;
		}
		else
		{
			SceneManager.LoadScene(6);
		}
	}

	public void MainToLevels() {
		MainMenu.SetActive(false);
		LevelsMenu.SetActive(true);
	}
	public void BackToMain() {
		MainMenu.SetActive(true);
		LevelsMenu.SetActive(false);
		HowToPlayMenu.SetActive(false);
		ControlsMenu.SetActive(false);
	}
	public void MainToHTP() {
		MainMenu.SetActive(false);
		HowToPlayMenu.SetActive(true);
	}
	public void MainToControls() {
		MainMenu.SetActive(false);
		ControlsMenu.SetActive(true);
	}
	public void QuitGame() {
		Application.Quit();
		Debug.Log("Quitted");
	}
	public void ResetMode() {
		resetMode = true;
		score1.color = Color.red;
		score2.color = Color.red;
		score3.color = Color.red;
		score4.color = Color.red;
		score5.color = Color.red;
		score6.color = Color.red;
	}
}
