using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PNS.Popups
{
    public class PopupTesting : MonoBehaviour
    {
        public void ShowPositive()
        {
            Debug.Log(NotificationManger.PopUp(PopupType.Positive, "This is a positive Popup", 5f));
        }

        public void ShowNeutral()
        {
            Debug.Log(NotificationManger.PopUp(PopupType.Neutral, "This is a neutral Popup", 0.5f));
        }

        public void ShowNegative()
        {
            Debug.Log(NotificationManger.PopUp(PopupType.Negative, "This is a negative Popup", 5f));
        }
    }
}
