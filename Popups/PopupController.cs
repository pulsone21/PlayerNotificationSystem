using UnityEngine;
using TMPro;
using DG.Tweening;

namespace PNS.Popups
{
    public enum PopupType { Positive, Negative, Neutral }
    public class PopupController : MonoBehaviour
    {
        // TODO -> Popup does not Scale Correctly on instantiation
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private CanvasGroup canvas;
        public bool Show(string content, PopupType type, float displayTime)
        {
            text.text = content;
            canvas.DOFade(0, displayTime).onComplete += () => Destroy(gameObject);
            return type == PopupType.Positive || type == PopupType.Neutral;
        }
    }
}
