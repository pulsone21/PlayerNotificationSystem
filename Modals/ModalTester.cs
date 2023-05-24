using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PNS.Modals
{
    public class ModalTester : MonoBehaviour
    {
        public Sprite Image;

        public void ShowConfirmationPopUp()
        {
            ModalContent content = new ModalContent(
                                    "This is a Confirmation Popup",
                                    "It only contains Text and no image, also it has an Ok and Cancle Button. Also it is Horizontal Oriented",
                                    null,
                                    ContentOrientation.Horizontal);
            NotificationManger.ConfirmationPopup(content, OkAction, "Ok", CancleAction, "Cancle");
        }

        public void ShowInformationPopUp()
        {
            ModalContent content = new ModalContent(
                                        "This is a Infomration Popup",
                                        "It only contains Text and no image, also it has an Acknowledge Button. It is Vertical Oriented",
                                        null,
                                        ContentOrientation.Vertical);
            NotificationManger.InformationPopup(content, AcknowledgeAction, "Acknowledge");
        }

        public void ShowCustomPopUp()
        {
            ModalContent content = new ModalContent(
                                        "This is a Custom Popup",
                                        "It contains Text and an image, also it has 3 custom Buttons. It is Vertical Oriented",
                                        Image,
                                        ContentOrientation.Vertical);
            List<ModalAction> actions = new List<ModalAction>(){
                new ModalAction(FirstAction, "FirstAction"),
                new ModalAction(SecondAction, "SecondAction"),
                new ModalAction(ThirdAction, "ThirdAction")
            };
            NotificationManger.CustomPopup(content, actions);
        }
        private void OkAction() => Debug.Log("This is a OkAction");
        private void CancleAction() => Debug.Log("This is a CancleAction");
        private void AcknowledgeAction() => Debug.Log("This is a AcknowledgeAction");
        private void FirstAction() => Debug.Log("This is the First action");
        private void SecondAction() => Debug.Log("This is the second action");
        private void ThirdAction() => Debug.Log("This is the third action");
        private void ForthAction() => Debug.Log("This is the forth action");
    }
}