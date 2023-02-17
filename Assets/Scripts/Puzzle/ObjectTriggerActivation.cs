using UnityEngine;
using UnityEngine.EventSystems;
public class ObjectTriggerActivation : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject droppedObject;  //dogru parça
    [SerializeField] private GameObject activeObjects; //aktif olacak parça
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
            //aktif olmasý gereken parça aktif olur
            if (eventData.pointerDrag.gameObject == droppedObject)
            {
                eventData.pointerDrag.SetActive(false);
                activeObjects.SetActive(true);
            }
        }
    }
}
