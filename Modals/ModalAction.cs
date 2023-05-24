using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PNS.Modals
{
    public class ModalAction
    {
        public readonly UnityAction ClickAction;
        public readonly string ButtonLable;

        public ModalAction(UnityAction clickAction, string buttonLable)
        {
            ClickAction = clickAction;
            ButtonLable = buttonLable;
        }
    }
}
