using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int lastLevelCompleted = 0;
    public ObservableCollection<HashSet<string>, string> hubActiveSwitches = new(new HashSet<string>());

    public string sceneToLoad = "";

    public int heldFirefliesOnHub = 0;

    public void LoadScene()
    {
        if (sceneToLoad == "") return;
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        sceneToLoad = "";
    }

    public void StartLoading()
    {
        SceneManager.LoadScene("Scenes/LoadingScene");
    }
}
