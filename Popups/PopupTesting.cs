using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PNS.Popups
{
    internal class PopupTesting : MonoBehaviour
    {
        private int counter;
        public void ShowPositive()
        {
            Debug.Log(NotificationManger.PopUp(PopupType.Positive, $"This is a positive Popup - {counter}", 5f));
            counter++;
        }

        public void ShowNeutral()
        {
            Debug.Log(NotificationManger.PopUp(PopupType.Neutral, $"This is a neutral Popup - {counter}", 0.5f));
            counter++;
        }

        public void ShowNegative()
        {
            Debug.Log(NotificationManger.PopUp(PopupType.Negative, $"This is a negative Popup - {counter}", 5f));
            counter++;
        }
    }
}
