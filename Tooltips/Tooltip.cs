using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace PNS.Tooltips
{
    [ExecuteInEditMode()]
    internal class Tooltip : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI Header;
        [SerializeField] private TextMeshProUGUI Text;
        [SerializeField, Tooltip("On the Text Gameobject")] private LayoutElement layoutElement;
        [SerializeField, Tooltip("How much letters per line is allowed for the Text Gameobject")] private int MaxLetterPerLine = 41;
        public float xOffset, yOffset;
        private bool _activeTimer = false;
        private float _displayTimer = 0f;
        private void Awake() => gameObject.SetActive(false);

        /// <summary>
        /// Displays the Tooltip with the given Text, Header and optional DisplayTime
        /// </summary>
        /// <param name="text"></param>
        /// <param name="header"></param>
        /// <param name="displayTime"></param>Optional: If there is no other action which disables the Tooltip, it can be done this way;
        internal void Show(string text, string header = "", float displayTime = 0f)
        {
            Header.text = header;
            if (header.Length < 1) Header.gameObject.SetActive(false);
            Text.text = text;
            CheckWrappLimit();
            gameObject.SetActive(true);
            if (displayTime > 0f)
            {
                _activeTimer = true;
                _displayTimer = displayTime;
            }
        }

        private void Update()
        {
            CalculatePosition();
            if (!_activeTimer) return;
            _displayTimer -= Time.deltaTime;
            if (_displayTimer > 0f) return;
            _activeTimer = false;
            Hide();
        }

        private void CheckWrappLimit()
        {
            bool warpping = Header.text.Length > MaxLetterPerLine || Text.text.Length > MaxLetterPerLine;
            layoutElement.enabled = warpping;
        }

        private void CalculatePosition()
        {
            Vector3 mousePos = Input.mousePosition;
            float pivotX = mousePos.x / Screen.width;
            float pivotY = mousePos.y / Screen.height;
            pivotX = pivotX >= 0.5f ? 1 : 0;
            pivotY = pivotY >= 0.5f ? 1 : 0;
            float offX = xOffset * (pivotX == 1 ? 1 : -1);
            float offY = yOffset * (pivotY == 1 ? 1 : -1);
            transform.position = new Vector2(mousePos.x - offX, mousePos.y - offY);
            GetComponent<RectTransform>().pivot = new Vector2(pivotX, pivotY);
        }
        internal void Hide()
        {
            gameObject.SetActive(false);
            Header.gameObject.SetActive(true);
            Header.text = "Header";
            Text.text = "Text here";
        }

    }
}
