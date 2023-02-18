using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParcalarToplandi : MonoBehaviour
{
    public GameObject karakter;
    private Vector3 karakterPosition;//karakter konum verileri kayýt



    [SerializeField] private GameObject[] taskCompleteTrigger; // aktif olacak parçalar
    [SerializeField] private GameObject congratulationsPanel;  //oyun bitiþ panel
    private void Start()
    {
        karakterPosition = karakter.transform.position;
        // Daha önce kaydedilmiþ konum bilgilerini al
        float playerX = PlayerPrefs.GetFloat("playerX", 0);
        float playerY = PlayerPrefs.GetFloat("playerY", 0);
        float playerZ = PlayerPrefs.GetFloat("playerZ", 0);

        // Karakteri kaydedilen konuma taþý
        karakter.transform.position = new Vector3(playerX, playerY, playerZ);
    }
    void Update()
    {
        CheckTasks();
    }
  
    void CheckTasks()
    {
        if (taskCompleteTrigger.All(x => x.activeInHierarchy)) //tüm parçalar aktifse oyun biter ve kazanýr
        {
            karakterPosition = karakter.transform.position;
            PlayerPrefs.SetFloat("playerX", karakterPosition.x);
            PlayerPrefs.SetFloat("playerY", karakterPosition.y);
            PlayerPrefs.SetFloat("playerZ", karakterPosition.z);
            congratulationsPanel.SetActive(true);
            StartCoroutine(GoToLevelAfterDelay("Puzzle", 2.0f));
        }
    }
    private  IEnumerator GoToLevelAfterDelay(string levelSceneName,float deger)
    {
        yield return new WaitForSeconds(deger);
        SceneManager.LoadScene(levelSceneName);
    }
}
