using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace PopUps
{
    [System.Serializable]
    public class ModalContent
    {
        public readonly string Header;
        public readonly string Text;
        public readonly Sprite Image;
        public readonly ContentOrientation Orientation;
        public ModalContent(string header, string text, Sprite image, ContentOrientation orientation)
        {
            Header = header;
            Text = text;
            Image = image;
            Orientation = orientation;
        }
    }
}
