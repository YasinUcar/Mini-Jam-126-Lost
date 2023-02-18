using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Button()
    {
        GoToLevel("EnvanterSistemi");
    }
    private void GoToLevel(string levelSceneName)
    {
        SceneManager.LoadScene(levelSceneName);
    }
}
