using UnityEngine;
using UnityEngine.EventSystems;
public class ObjectDragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    /* objeyi sürükleyip býrakma iþlemini yapýyor
      objeye; scripti, collider ve canvas group eklenmeli.*/
    [SerializeField] private Canvas myCanvas;
    private RectTransform RectTransformrectTransform;
    private CanvasGroup canvasGroup_;
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
        canvasGroup_.blocksRaycasts = true;
    }
}
