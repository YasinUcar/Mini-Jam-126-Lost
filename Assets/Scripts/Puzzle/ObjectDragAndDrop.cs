using UnityEngine;
using UnityEngine.EventSystems;
public class ObjectDragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    /* objeyi s�r�kleyip b�rakma i�lemini yap�yor
      objeye; scripti, collider ve canvas group eklenmeli.*/
    [SerializeField] private Canvas myCanvas;
    private RectTransform RectTransformrectTransform;
    private CanvasGroup canvasGroup_;
    [SerializeField] private GameObject havuz;
    void Start()
    {
        RectTransformrectTransform = GetComponent<RectTransform>();
        canvasGroup_ = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup_.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        RectTransformrectTransform.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        eventData.pointerDrag.transform.parent = havuz.transform;
        canvasGroup_.blocksRaycasts = true;
    }
}
