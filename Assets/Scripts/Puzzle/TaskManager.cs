using System.Collections;
using System.Linq;
using UnityEngine;
public class TaskManager : MonoBehaviour
{
    [SerializeField] private GameObject[] taskCompleteTrigger; // aktif olacak parçalar
    [SerializeField] private GameObject congratulationsPanel;  //oyun bitiþ panel
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
            if (taskCompleteTrigger.All(x => x.activeInHierarchy)) //tüm parçalar aktifse oyun biter ve kazanýr
            {
                yield return new WaitForSeconds(1);
                congratulationsPanel.SetActive(true);
            }
        }
    }
}
