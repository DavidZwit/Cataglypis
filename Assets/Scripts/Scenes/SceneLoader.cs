using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    void OnEnable()
    {
        Health.Lost += ReloadScene;
    }

    void OnDisable()
    {
        Health.Lost -= ReloadScene;
    }
    public void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
