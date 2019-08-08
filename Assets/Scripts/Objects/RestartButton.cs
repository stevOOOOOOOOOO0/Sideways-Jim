using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
	
	public int LoadScene;
    
	public void Restart()
	{
		SceneManager.LoadScene(LoadScene);
	}   
}