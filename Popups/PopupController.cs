using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
namespace PNS.Popups
{
    public enum PopupType { Positive, Negative, Neutral }
    internal class PopupController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private CanvasGroup canvas;
        private void Awake() => gameObject.SetActive(false);
        public bool Show(string content, PopupType type, float displayTime)
        {
            text.text = content;
            gameObject.SetActive(true);
            canvas.DOFade(0, 1.5f).SetDelay(displayTime).onComplete += () => Destroy(gameObject);
            return type == PopupType.Positive || type == PopupType.Neutral;
        }
    }
}
