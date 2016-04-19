using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadOnClick : MonoBehaviour {



	public GameObject loadingImage;
	public void LoadScene (int level)
	{
		bool start = Input.GetButtonDown("Submit");

		if (start)
		{
	
			loadingImage.SetActive(true);
			SceneManager.LoadScene(level);
			AudioController.instance.PlaySound (AudioController.AudioType.power_up);
		}
	}
}




