using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tooltips;
using PopUps;
using UnityEngine.Events;

namespace PNS
{
    public class NotificationManger : MonoBehaviour
    {
        public static NotificationManger Instance;

        private void Awake()
        {
            if (Instance)
            {
                DestroyImmediate(this);
            }
            else
            {
                Instance = this;
            }
        }

        #region Tooltip
        [Header("Tooltip Settings")]
        [SerializeField] private bool enableToolTips;
        [SerializeField] private Tooltip _tooltip;
        public static void Tooltip(string text, string header = "", float displayTime = 0f)
        {
            if (!Instance.enableToolTips) return;
            Instance._tooltip.Show(text, header, displayTime);
        }
        public static void HideTooltip()
        {
            if (!Instance.enableToolTips) return;
            Instance._tooltip.Hide();
        }

        #endregion

        #region Modals

        [Space(5f), Header("Modal Settings")]
        [SerializeField] private bool enableModal;
        [SerializeField] private bool multiModals;
        [SerializeField] private Transform ModalContainer;
        [SerializeField] private List<Modal> Modals = new List<Modal>();
        [SerializeField] private List<ModalController> activeModals = new List<ModalController>();

        public static void ConfirmationPopup(ModalContent Content, UnityAction OnOkAction, string OkLabel, UnityAction OnCancleAction, string CancleLabel, UnityAction OnAlternativeAction = null, string alternativeLable = null)
        {
            if (!Instance.enableModal) return;
            ModalController controller = GetController(Content.Orientation);
            if (controller == default) return;
            controller.ShowModal(Content, OnOkAction, OkLabel, OnCancleAction, OnAlternativeAction, CancleLabel, alternativeLable);
        }

        public static void InformationPopup(ModalContent Content, UnityAction OnOkAction, string OkLabel)
        {
            if (!Instance.enableModal) return;
            ModalController controller = GetController(Content.Orientation);
            if (controller == default) return;
            controller.ShowModal(Content, OnOkAction, OkLabel);
        }

        public static void CustomPopup(ModalContent Content, List<ModalAction> Actions)
        {
            if (!Instance.enableModal) return;
            ModalController controller = GetController(Content.Orientation);
            if (controller == default) return;
            controller.ShowModal(Content, Actions);
        }

        private static ModalController GetController(ContentOrientation Orientation)
        {
            Modal modal = Instance.GetModalByType(Orientation);
            if (modal == default) return default;
            if (!Instance.multiModals && Instance.activeModals.Count > 0)
            {
                Debug.Log("Modal is already active");
                return default;
            }
            ModalController controller = Instantiate(modal.UI, Instance.ModalContainer).GetComponent<ModalController>();
            Instance.activeModals.Add(controller);
            return controller;
        }

        private Modal GetModalByType(ContentOrientation type)
        {
            foreach (Modal modal in Modals)
            {
                if (modal.Orientation == type) return modal;
            }
            Debug.LogError($"ModalType {type} not found in PopUpWindowManager List!");
            return default;
        }
        public static void OnClosedModal(ModalController modalController)
        {
            if (!Instance.enableModal) return;
            Instance.activeModals.Remove(modalController);
        }

        #endregion

        #region PopUp
        [Space(5f), Header("PopUp Settings")]
        [SerializeField] private bool enablePopup;
        public static bool PopUp() => Instance.ShowPopup();

        private bool ShowPopup()
        {
            return true;
        }

        #endregion

        #region EventLog

        [Space(5f), Header("EventLog Settings")]
        [SerializeField] private bool enableEventLog;
        public static void EventLog() => Instance.ShowEventLog();

        private void ShowEventLog()
        {
            if (!enableEventLog) return;

        }

        #endregion
    }
}
