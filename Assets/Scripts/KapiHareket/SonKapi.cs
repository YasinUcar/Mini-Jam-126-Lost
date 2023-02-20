using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonKapi : MonoBehaviour
{
    public float openAngle = 90.0f; // Kap�n�n a��lma a��s�
    public float openSpeed = 2.0f; // Kap�n�n a��lma h�z�
    public float closeSpeed = 2.0f; // Kap�n�n kapanma h�z�
    public float waitTime = 5.0f; // Kap�n�n a��k kalma s�resi

    private bool isOpen = false; // Kap�n�n a��k olup olmad���n� tutan de�i�ken
    private Quaternion startRotation; // Kap�n�n ba�lang�� rotasyonu
    private Quaternion targetRotation; // Kap�n�n hedef rotasyonu
    private float elapsedTime = 0.0f; // Kap�n�n a��k kald��� s�reyi tutan de�i�ken
    [SerializeField] private GorevManager _gorevManager;
    private void Start()
    {
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(targetRotation.x - openAngle, 0, 0);
    }
    IEnumerator LerpPosition()
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < 5f)
        {

            //transform.position = Vector3.Lerp(startPosition, new Vector3(transform.position.x, transform.position.y, -1f), time / 5f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, 0, 90f), time / 5f);
            time += Time.deltaTime;

            yield return null;
        }
    }


    public void KapiyiAc()
    {
        StartCoroutine(LerpPosition());
        _gorevManager.StringLevelName = "Cat";
    }
    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0) && IsMouseOverObject()) // Sol fare butonuna bas�ld���nda
    //     {
    //         isOpen = !isOpen; // Kap�n�n durumunu tersine �evir
    //         elapsedTime = 0.0f; // A��k kald��� s�reyi s�f�rla
    //     }
    //     if (isOpen) // Kap� a��l�yorsa
    //     {
    //         transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
    //     }
    //     else // Kap� kapan�yorsa
    //     {
    //         transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, Time.deltaTime * closeSpeed);
    //     }
    //     if (isOpen && elapsedTime < waitTime) // Kap� a��k ve belirlenen s�re dolmad�ysa
    //     {
    //         elapsedTime += Time.deltaTime; // Ge�en s�reyi g�ncelle
    //     }
    //     else // Kap� belirlenen s�re boyunca a��k kald�ysa veya kapal�ysa
    //     {
    //         isOpen = false; // Kap�y� kapat
    //     }
    // }
    // private bool IsMouseOverObject()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;
    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         return hit.transform == transform;
    //     }
    //     return false;
    // }
}
