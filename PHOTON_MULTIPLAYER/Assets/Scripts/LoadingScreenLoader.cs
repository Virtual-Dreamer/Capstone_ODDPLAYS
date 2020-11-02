using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenLoader : MonoBehaviour
{
    public Slider slider;

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadSceneAsynchronously(sceneName));
    }

    IEnumerator LoadSceneAsynchronously(string sceneName)
    {
        AsyncOperation sceneOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!sceneOperation.isDone)
        {
            float progress = Mathf.Clamp01(sceneOperation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }
}
