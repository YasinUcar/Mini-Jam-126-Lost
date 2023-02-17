using System.Collections.Generic;
using UnityEngine;
public class SlotYonetimi : MonoBehaviour
{
    [SerializeField] private List<GameObject> SlotlarinTumu;
    public void SlotaItemEkle(GameObject eklenecekNesne)
    {
        for (int i = 0; i < SlotlarinTumu.Count; i++)
        {
            if (!SlotlarinTumu[i].GetComponent<SlotDurumu>().slotDurumu)
            {
                eklenecekNesne.transform.parent = SlotlarinTumu[i].transform;
                eklenecekNesne.transform.localPosition = new Vector3(0,0,0);
                SlotlarinTumu[i].GetComponent<SlotDurumu>().slotDurumu = true;
                break;
            }
            else
            {
                continue;  //devam et, bir sonraki slota geç
            }
        }
    }
}
