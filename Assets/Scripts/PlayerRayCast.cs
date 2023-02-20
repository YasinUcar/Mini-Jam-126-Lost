using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField] private GameObject _mektupCanvas;
    [SerializeField] private GorevManager _gorevManager;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.gameObject.CompareTag("Mektup"))  //t�klan�lan nesnede bu script var ise
                {
                    _mektupCanvas.SetActive(true);
                }
                // TODO : DİĞERLERİNİ EKLLEMEYİ UNUTMA!!
                if (_gorevManager.StringLevelName == "Puzzle" || _gorevManager.StringLevelName == "Puzzle2" || _gorevManager.StringLevelName == "PC" || _gorevManager.StringLevelName == "Last" || _gorevManager.StringLevelName == "Last2")
                    if (hit.transform.gameObject.CompareTag("UstKapi"))  //t�klan�lan nesnede bu script var ise
                    {
                        if (hit.transform.GetComponent<UstKapi>() != null)
                        {
                            hit.transform.GetComponent<UstKapi>().KapiyiAc();
                        }

                        //hit.transform.position = Vector3.Lerp(hit.transform.position, new Vector3(-1f, hit.transform.position.y, hit.transform.position.z), 100f*Time.deltaTime);
                    }
                if (hit.transform.gameObject.CompareTag("Puzzle"))  //
                    if (_gorevManager.StringLevelName == "Puzzle2")
                    {
                        SceneManager.LoadScene("Puzzle");
                    }
                if (hit.transform.gameObject.CompareTag("PC"))  //
                    if (_gorevManager.StringLevelName == "PC")
                    {
                        SceneManager.LoadScene("SpaceGame");
                    }
            }
        }

    }

}
