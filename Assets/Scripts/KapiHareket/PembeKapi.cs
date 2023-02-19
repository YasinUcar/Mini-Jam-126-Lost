using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PembeKapi : MonoBehaviour
{
    public float openAngle = 90.0f; // Kapýnýn açýlma açýsý
    public float openSpeed = 2.0f; // Kapýnýn açýlma hýzý
    public float closeSpeed = 2.0f; // Kapýnýn kapanma hýzý
    public float waitTime = 5.0f; // Kapýnýn açýk kalma süresi

    private bool isOpen = false; // Kapýnýn açýk olup olmadýðýný tutan deðiþken
    private Quaternion startRotation; // Kapýnýn baþlangýç rotasyonu
    private Quaternion targetRotation; // Kapýnýn hedef rotasyonu
    private float elapsedTime = 0.0f; // Kapýnýn açýk kaldýðý süreyi tutan deðiþken

    private void Start()
    {
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(targetRotation.x - openAngle, 0, 0);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsMouseOverObject()) // Sol fare butonuna basýldýðýnda
        {
            isOpen = !isOpen; // Kapýnýn durumunu tersine çevir
            elapsedTime = 0.0f; // Açýk kaldýðý süreyi sýfýrla
        }
        if (isOpen) // Kapý açýlýyorsa
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
        }
        else // Kapý kapanýyorsa
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, Time.deltaTime * closeSpeed);
        }
        if (isOpen && elapsedTime < waitTime) // Kapý açýk ve belirlenen süre dolmadýysa
        {
            elapsedTime += Time.deltaTime; // Geçen süreyi güncelle
        }
        else // Kapý belirlenen süre boyunca açýk kaldýysa veya kapalýysa
        {
            isOpen = false; // Kapýyý kapat
        }
    }
    private bool IsMouseOverObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform == transform;
        }
        return false;
    }
}
