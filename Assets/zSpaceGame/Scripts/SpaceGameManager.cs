using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpaceGameManager : MonoBehaviour
{
    public static SpaceGameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _timeText;
    private float time = 30f;
    public float GameTime { get => time; }
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        time -= Time.deltaTime;
        _timeText.text = Mathf.Round(time).ToString();
        if (time <= 0f)
        {
            //TODO : Bakılacak
            SceneManager.LoadScene("MainScene");
        }
    }
    public void ResetGame()
    {
        StartCoroutine(ResetThisGame());
    }
    IEnumerator ResetThisGame()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("SpaceGame");
    }
}
