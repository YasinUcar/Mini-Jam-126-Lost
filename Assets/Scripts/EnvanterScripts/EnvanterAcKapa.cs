using UnityEngine;
using UnityEngine.UI;
public class EnvanterAcKapa : MonoBehaviour
{
    [SerializeField] private GameObject EnvanterPanel;

    [SerializeField] RectTransform rt;
    bool acildiMi;
    private void Start()
    {

        rt.localScale = Vector3.zero;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!acildiMi)
            {
                acildiMi = true;
                rt.localScale = Vector3.zero;
            }
            else if (acildiMi)
            {
                rt.localScale = new Vector3(1, 1, 1);
                acildiMi = false;
            }
        }

    }
}
