using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class ClickHelper : MonoBehaviour,IPointerClickHandler
    {
        public Action OnClick;
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }
    }
}
