using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Button()
    {
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
