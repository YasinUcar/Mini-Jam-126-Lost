using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParcalarToplandi : MonoBehaviour
{
    [SerializeField] private GameObject[] taskCompleteTrigger; // aktif olacak par�alar
    [SerializeField] private GameObject congratulationsPanel;  //oyun biti� panel
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
                yield return new WaitForSeconds(1);
                GoToLevel("Puzzle");
            }
        }
    }
    private  void GoToLevel(string levelSceneName)
    {
        SceneManager.LoadScene(levelSceneName);
    }
}
