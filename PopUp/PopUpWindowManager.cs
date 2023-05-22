using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace PopUps
{
    public enum ContentOrientation { Vertical, Horizontal }
    public class PopUpWindowManager : MonoBehaviour
    {
        public static PopUpWindowManager Instance;
        [SerializeField] private GameObject Container;
        [SerializeField] private List<Modal> Modals = new List<Modal>();
        private List<ModalController> activeModals = new List<ModalController>();
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

        public static void ConfirmationPopup(ModalContent Content, UnityAction OnOkAction, string OkLabel, UnityAction OnCancleAction, string CancleLabel, UnityAction OnAlternativeAction = null, string alternativeLable = null)
        {
            ModalController controller = GetController(Content.Orientation);
            if (controller == default) return;
            controller.ShowModal(Content, OnOkAction, OkLabel, OnCancleAction, OnAlternativeAction, CancleLabel, alternativeLable);
        }

        public static void InformationPopup(ModalContent Content, UnityAction OnOkAction, string OkLabel)
        {
            ModalController controller = GetController(Content.Orientation);
            if (controller == default) return;
            controller.ShowModal(Content, OnOkAction, OkLabel);
        }

        public static void CustomPopup(ModalContent Content, List<ModalAction> Actions)
        {
            ModalController controller = GetController(Content.Orientation);
            if (controller == default) return;
            controller.ShowModal(Content, Actions);
        }

        private static ModalController GetController(ContentOrientation Orientation)
        {
            Modal modal = Instance.GetModalByType(Orientation);
            if (modal == default) return default;
            if (Instance.activeModals.Count < 1) Instance.Container.SetActive(true); //? only set active if there is no other modal Open.
            ModalController controller = Instantiate(modal.UI, Instance.Container.transform).GetComponent<ModalController>();
            Instance.activeModals.Add(controller);
            return controller;
        }

        private Modal GetModalByType(ContentOrientation type)
        {
            foreach (Modal modal in Modals)
            {
                if (modal.ModalType == type) return modal;
            }
            Debug.LogError($"ModalType {type} not found in PopUpWindowManager List!");
            return default;
        }
        public static void OnClosedModal(ModalController modalController)
        {
            if (Instance.activeModals.Remove(modalController) && Instance.activeModals.Count < 1)
            {
                Instance.Container.SetActive(false);
            };
        }
    }
}
