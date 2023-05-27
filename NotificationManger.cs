using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PNS.Tooltips;
using PNS.Modals;
using PNS.Popups;
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
            _popUps = new Dictionary<PopupType, PopupController>(){
                {PopupType.Positive, _positivePopup ?? null},
                {PopupType.Neutral, _neutralPopup ?? null},
                {PopupType.Negative, _negativePopup ?? null}
            };

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

        public static void ConfirmationModal(ModalContent Content, UnityAction OnOkAction, string OkLabel, UnityAction OnCancleAction, string CancleLabel, UnityAction OnAlternativeAction = null, string alternativeLable = null)
        {
            if (!Instance.enableModal) return;
            ModalController controller = GetController(Content.Orientation);
            if (controller == default) return;
            controller.ShowModal(Content, OnOkAction, OkLabel, OnCancleAction, OnAlternativeAction, CancleLabel, alternativeLable);
        }

        public static void InformationModal(ModalContent Content, UnityAction OnOkAction, string OkLabel)
        {
            if (!Instance.enableModal) return;
            ModalController controller = GetController(Content.Orientation);
            if (controller == default) return;
            controller.ShowModal(Content, OnOkAction, OkLabel);
        }

        public static void CustomModal(ModalContent Content, List<ModalAction> Actions)
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
        internal static void OnClosedModal(ModalController modalController)
        {
            if (!Instance.enableModal) return;
            Instance.activeModals.Remove(modalController);
        }

        #endregion

        #region PopUp

        [Space(5f), Header("PopUp Settings")]
        [SerializeField] private bool _enablePopup;
        [SerializeField] private Transform _popUpContainer;
        [SerializeField] private PopupController _positivePopup, _neutralPopup, _negativePopup;
        [SerializeField] private float _defaultDisplayTime = 1.5f;
        private Dictionary<PopupType, PopupController> _popUps;
        public static bool PopUp(PopupType type, string text, float displayTime = 0f)
        {
            if (!Instance._enablePopup)
            {
                Debug.LogError("PopUps are not enabled!");
                return false;
            }
            return Instance.ShowPopup(type, text, displayTime == 0f ? Instance._defaultDisplayTime : displayTime);
        }
        private bool ShowPopup(PopupType type, string text, float displayTime)
        {
            if (_popUps[type] != null)
            {
                PopupController pc = Instantiate(_popUps[type]).GetComponent<PopupController>();
                pc.transform.SetParent(_popUpContainer, false);
                return pc.Show(text, type, displayTime);
            }
            Debug.LogError($"PopUp with Type: {type} are not in the list");
            return false;
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
