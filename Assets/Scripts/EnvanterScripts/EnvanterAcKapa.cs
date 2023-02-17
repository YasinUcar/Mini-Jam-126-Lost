using UnityEngine;

public class EnvanterAcKapa : MonoBehaviour
{
    [SerializeField] private GameObject EnvanterPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            EnvanterPanel.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            EnvanterPanel.SetActive(false);
        }
    }
}
