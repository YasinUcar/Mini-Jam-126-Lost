using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject timerManager;
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Button()
    {
        timerManager.SetActive(true);
        GoToLevel("GameScene");

    }
    private void GoToLevel(string levelSceneName)
    {
        SceneManager.LoadScene(levelSceneName);
    }
    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }
    public void Save()
    {
        settingsPanel.SetActive(false);
    }
}
