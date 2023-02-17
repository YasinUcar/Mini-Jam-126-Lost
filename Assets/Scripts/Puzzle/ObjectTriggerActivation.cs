using UnityEngine;
using UnityEngine.EventSystems;
public class ObjectTriggerActivation : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject droppedObject;  //dogru par�a
    [SerializeField] private GameObject[] droppedObjects; // yanl�� par�alar
    [SerializeField] private GameObject activeObjects; //aktif olacak par�a
    private bool objectEntered = false;
    private Vector3[] initialPositions;
    private void Start()
    {
        initialPositions = new Vector3[droppedObjects.Length];
        for (int i = 0; i < droppedObjects.Length; i++)
        {
            initialPositions[i] = droppedObjects[i].GetComponent<RectTransform>().localPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == droppedObject)
        {
            objectEntered = true;
        }
        for (int i = 0; i < droppedObjects.Length; i++)
        {
            if (collision.gameObject == droppedObjects[i])
            {
                objectEntered = true;
            }
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (objectEntered)
        {
            //aktif olmas� gereken par�a aktif olur
            if (eventData.pointerDrag.gameObject == droppedObject)
            {
                eventData.pointerDrag.SetActive(false);
                activeObjects.SetActive(true);
            }
            //eski konumlar�na geri d�nerler
            for (int i = 0; i < droppedObjects.Length; i++)
            {
                if (eventData.pointerDrag.gameObject == droppedObjects[i])
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().localPosition = initialPositions[i];
                }
            }
        }
    }
}
