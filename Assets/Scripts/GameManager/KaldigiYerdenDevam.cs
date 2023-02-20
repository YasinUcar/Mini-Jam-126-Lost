using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KaldigiYerdenDevam : MonoBehaviour
{
    [SerializeField] private GameObject[] taskCompleteTrigger; // aktif olacak par�alar
    [SerializeField] private GameObject congratulationsPanel;  //oyun biti� panel
    [SerializeField] private GorevManager _gorevManager;
    private void Awake()
    {
        Cursor.visible = enabled;
        Cursor.lockState = CursorLockMode.None;
    }
    void Update()
    {
        CheckTasks();
    }
    void CheckTasks()
    {
        StartCoroutine(WaitForCompletion());

    }
    IEnumerator WaitForCompletion()
    {
        for (int i = 0; i < taskCompleteTrigger.Length; i++)
        {
            if (taskCompleteTrigger.All(x => x.activeInHierarchy)) //t�m par�alar aktifse oyun biter ve kazan�r
            {
                yield return new WaitForSeconds(1);
                congratulationsPanel.SetActive(true);
                _gorevManager.StringLevelName = "PC";
                yield return new WaitForSeconds(1);
                GoToLevel("GameScene");
            }
        }
    }
    private void GoToLevel(string levelSceneName)
    {
        SceneManager.LoadScene(levelSceneName);
    }
}
