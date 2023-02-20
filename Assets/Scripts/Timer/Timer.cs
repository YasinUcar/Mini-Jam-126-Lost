using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float currentTime;
    [SerializeField] private float totalTime;
    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);


    }
    void Start()
    {
        currentTime = totalTime;
        timerText.text = TimeToString(currentTime);
        StartCoroutine(CountdownTime());
    }
    private IEnumerator CountdownTime()
    {
        while (currentTime >= 0)
        {
            timerText.text = TimeToString(currentTime);
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        yield return null;
    }
    private string TimeToString(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void Update()
    {
        print(currentTime);
        if (currentTime <= 0f)
        {
            SceneManager.LoadScene("GameScene");
            PlayerPrefs.DeleteAll();
            currentTime = totalTime;
        }

    }

}

