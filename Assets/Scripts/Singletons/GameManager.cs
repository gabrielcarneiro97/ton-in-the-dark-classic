using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Observable<int> lastLevelCompleted = new(0);
    public ObservableCollection<HashSet<string>, string> hubActiveSwitches = new(new HashSet<string>());

    public string sceneToLoad = "";

    public void LoadScene()
    {
        Debug.Log("Loading " + sceneToLoad);

        if (sceneToLoad == "") return;
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        Debug.Log("Starting loading " + sceneToLoad);
        yield return new WaitForSeconds(2f);
        Debug.Log("Ended waiting " + sceneToLoad);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Debug.Log("Loading end " + sceneToLoad);
        sceneToLoad = "";
    }

    public void StartLoading()
    {
        SceneManager.LoadScene("Scenes/LoadingScene");
    }
}
