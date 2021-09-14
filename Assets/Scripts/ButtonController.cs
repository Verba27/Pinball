using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public UnityEvent OnUp;
    public UnityEvent OnDown;

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUp.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDown.Invoke();
    }
}
