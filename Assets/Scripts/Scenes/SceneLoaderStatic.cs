using UnityEngine.SceneManagement;

public static class SceneLoaderStatic {

    public static void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
