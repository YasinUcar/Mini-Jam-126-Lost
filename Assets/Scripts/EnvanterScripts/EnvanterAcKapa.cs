using UnityEngine;

public class EnvanterAcKapa : MonoBehaviour
{
    [SerializeField] private GameObject EnvanterPanel;
    bool acildiMi;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!acildiMi)
            {
                acildiMi = true;
                EnvanterPanel.SetActive(true);
            }
            else if (acildiMi)
            {
                EnvanterPanel.SetActive(false);
                acildiMi = false;
            }
        }

    }
}
