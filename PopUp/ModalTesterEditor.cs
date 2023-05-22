using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PopUps
{


    [CustomEditor(typeof(ModalTester))]
    public class ModalTesterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ModalTester mT = (ModalTester)target;


            if (GUILayout.Button("Get Vertical Modal"))
            {
                mT.type = ContentOrientation.Vertical;
                mT.ShowModal();
            }

            GUILayout.Space(5f);

            if (GUILayout.Button("Get Horizontal Modal"))
            {
                mT.type = ContentOrientation.Horizontal;
                mT.ShowModal();
            }

        }
    }
}
