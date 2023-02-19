using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParcalarToplandi : MonoBehaviour
{
    public GameObject karakter;
    private Vector3 karakterPosition;//karakter konum verileri kay�t
    private bool nesnelerSilinsin = false;
    [SerializeField] private GameObject[] SilinecekNesneler;

    [SerializeField] private GameObject[] taskCompleteTrigger; // aktif olacak par�alar
    [SerializeField] private GameObject congratulationsPanel;  //oyun biti� panel
    private void Start()
    {
        nesnelerSilinsin = PlayerPrefs.GetInt("nesnelerSilinsin", 0) == 1;
        if (nesnelerSilinsin)
        {
            for (int i = 0; i < SilinecekNesneler.Length; i++)
            {
                Destroy(SilinecekNesneler[i]);
            }
        }
        karakterPosition = karakter.transform.position;
        // Daha �nce kaydedilmi� konum bilgilerini al
        float playerX = PlayerPrefs.GetFloat("playerX", 0);
        float playerY = PlayerPrefs.GetFloat("playerY", 0);
        float playerZ = PlayerPrefs.GetFloat("playerZ", 0);

        // Karakteri kaydedilen konuma ta��
        //karakter.transform.position = new Vector3(playerX, playerY, playerZ);
    }
    void Update()
    {
        CheckTasks();
    }
  
    void CheckTasks()
    {
        if (taskCompleteTrigger.All(x => x.activeInHierarchy)) //t�m par�alar aktifse oyun biter ve kazan�r
        {
            PlayerPrefs.SetInt("nesnelerSilinsin", 1);
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
