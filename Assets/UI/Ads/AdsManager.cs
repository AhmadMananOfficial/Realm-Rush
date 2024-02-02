using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
	[SerializeField] private InterstitialAd interstitialAd; // Reference to your InterstitialAd script
	[SerializeField] private SceneController sceneController; // Reference to your SceneController script

	

	public void ShowAdAndRestartGame()
	{
		
		sceneController.PauseGame(); // Pause the game if ad isn't already loading
		interstitialAd.ShowAd(); // Start loading the ad
			
		
	}

	// Called when the ad finishes loading
	public void OnUnityAdsAdLoaded(string adUnitId)
	{
		if (adUnitId == interstitialAd._adUnitId)
		{
			
			interstitialAd.ShowAd(); // Show the ad
			Debug.Log("onloaded");
		}
	}

	// Called when the ad is shown, skipped, or closed
	public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
	{
		sceneController.ResumeGame(); // Resume the game after the ad finishes
		sceneController.RestartGame(); // Restart the game
		Debug.Log("oncomplete");
	}

	// Called if the ad fails to load
	public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
	{
		Debug.LogWarning($"Ad failed to load: {adUnitId} - {error} - {message}");
		
		sceneController.ResumeGame(); // Resume the game if the ad fails
		sceneController.RestartGame(); // Restart the game (handle differently if needed)
		Debug.Log("Failed");
	}
}
