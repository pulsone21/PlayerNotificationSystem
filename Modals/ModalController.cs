using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace PNS.Modals
{
    internal class ModalController : MonoBehaviour
    {
        [Header("Header Settings")]
        [SerializeField] private TextMeshProUGUI HeaderText;

        [Space(5f)]
        [Header("Content Settings")]
        [SerializeField] private TextMeshProUGUI ContentText;
        [SerializeField] private Image Image;

        [Space(5f)]
        [Header("Footer Settings")]
        [SerializeField] private Transform ButtonContainer;
        [SerializeField] private Transform ButtonPrefab;

        private void Awake() => gameObject.SetActive(false);

        public void ShowModal(ModalContent content,
                            UnityAction OnOkAction,
                            string OkLabel,
                            UnityAction OnCancleAction = null,
                            UnityAction OnAlternativeAction = null,
                            string CancleLabel = null,
                            string alternativeLable = null)

        {
            SetDefaults(content);
            CreateButton(OkLabel, OnOkAction);
            if (OnCancleAction != null) CreateButton(CancleLabel, OnCancleAction);
            if (OnAlternativeAction != null) CreateButton(alternativeLable, OnAlternativeAction);
            Show();
        }

        public void ShowModal(ModalContent content, List<ModalAction> ModalActions)
        {
            SetDefaults(content);
            foreach (ModalAction action in ModalActions)
            {
                CreateButton(action.ButtonLable, action.ClickAction);
            }
            Show();
        }

        private void CreateButton(string lable, UnityAction action)
        {
            Button btn = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity, ButtonContainer).GetComponent<Button>();
            btn.onClick.AddListener(action);
            btn.onClick.AddListener(CloseModal);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = lable;
        }

        private void SetDefaults(ModalContent content)
        {
            HeaderText.text = content.Header;
            ContentText.text = content.Text;

            if (content.Image != null)
            {
                Image.sprite = content.Image;
                Image.gameObject.SetActive(true);
            }
            else
            {
                Image.gameObject.SetActive(false);
            }
        }
        private void Show() => gameObject.SetActive(true);

        public void CloseModal()
        {
            NotificationManger.OnClosedModal(this);
            Destroy(gameObject);
        }
    }
}
