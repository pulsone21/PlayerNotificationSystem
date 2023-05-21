using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tooltips;
using PopUps;

namespace PNS
{
    public class NotificationManger : MonoBehaviour
    {
        public static NotificationManger Instance;
        public bool enableEventLog, enableToolTips, enableModal, enablePopup;
        // [SerializeField] private EventLogManager _eventLog;
        [SerializeField] private Tooltip _tooltip;
        [SerializeField] private PopUpWindowManager _popup;
        // [SerializeField] private GeneralNotifcationManager _notification;

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

        public static void Tooltip(string text, string header = "", float displayTime = 0f) => Instance._tooltip.Show(text, header, displayTime);
        public static void HideTooltip() => Instance._tooltip.Hide();

        public static void Modal() => Instance.ShowModal();

        private void ShowModal() { }

        public static bool PopUp() => Instance.ShowPopup();

        private bool ShowPopup()
        {
            return true;
        }

        public static void EventLog() => Instance.ShowEventLog();

        private void ShowEventLog()
        {

        }



    }
}
