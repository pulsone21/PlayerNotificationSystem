using UnityEngine;

namespace PNS.Tooltips
{
    internal class TooltipTesting : MonoBehaviour
    {
        public void ShowTooltip()
        {
            NotificationManger.Tooltip("This Tooltip is triggered via Code, has no header and is dispalyed 2 seconds", "", 2f);
        }
    }
}
