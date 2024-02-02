using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	[SerializeField] private Animator animator;
	
	
	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
		animator.SetTrigger("FadeIn");
		Time.timeScale = 1f;
	}


}
	

	
	
	
	

