using UnityEngine;
using UnityEngine.EventSystems;
public class ObjectTriggerActivation : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject droppedObject;  //dogru par�a
    [SerializeField] private GameObject activeObjects; //aktif olacak par�a
    private bool objectEntered = false;
    private Vector3[] initialPositions;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == droppedObject)
        {
            objectEntered = true;
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
        }
    }
}
