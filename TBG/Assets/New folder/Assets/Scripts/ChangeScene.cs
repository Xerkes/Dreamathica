using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ForestScene()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
	}
	
}
