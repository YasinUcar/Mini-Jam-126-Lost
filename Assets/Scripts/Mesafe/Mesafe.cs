using TMPro;
using UnityEngine;

public class Mesafe : MonoBehaviour
{
    [SerializeField] private GameObject karakter;
    [SerializeField] private GameObject hedefNesne;
    [SerializeField] private TextMeshProUGUI hedefNesneText;
    void Update()
    {
        Mesafe_();
    }
    private void Mesafe_()
    {
        float distance = Vector3.Distance(karakter.transform.position, hedefNesne.transform.position);
        hedefNesneText.text = distance.ToString("F2")+"m";
        Debug.Log(hedefNesneText.text);
    }
}
