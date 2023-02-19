using UnityEngine;
public class SureBiterse : MonoBehaviour
{
    private Timer timer;
    [SerializeField] private GameObject tryAgainPanel;
    void Start()
    {
        timer = GameObject.FindObjectOfType<Timer>();
    }
    private void Update()
    {
        if (timer.currentTime <= 0)
        {
            tryAgainPanel.SetActive(true);
        }
    }
}
