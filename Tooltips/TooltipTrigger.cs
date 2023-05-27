using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace PNS.Tooltips
{
    internal class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public string Header;
        [TextArea] public string Description;
        private float hoverDelay = 0.5f;
        private float currentDelay = 0f;
        private Sequence sequence;

        public void OnPointerEnter(PointerEventData eventData)
        {
            sequence = DOTween.Sequence();
            sequence.Append(DOTween.To(() => currentDelay, x => currentDelay = x, 1, hoverDelay).OnComplete(() => NotificationManger.Tooltip(Description, Header)));
            sequence.Play();
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            sequence.Kill();
            currentDelay = 0;
            NotificationManger.HideTooltip();
        }
    }
}
