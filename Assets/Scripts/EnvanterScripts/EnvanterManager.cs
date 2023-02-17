using UnityEngine;
public class EnvanterManager : MonoBehaviour
{
    private  SlotYonetimi slotYonetimi;
    void Start()
    {
        slotYonetimi = GameObject.FindObjectOfType<SlotYonetimi>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.gameObject.GetComponent<SahneItemIslemi>()!=null)  //týklanýlan nesnede bu script var ise
                {
                    slotYonetimi.SlotaItemEkle(hit.transform.gameObject.GetComponent<SahneItemIslemi>().slotItem);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
