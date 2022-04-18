using cakeslice;
using UnityEngine;

namespace MoonGames.Game.FrogJump
{
    public class SelectableMono : MonoBehaviour
    {
        public bool isSelected;
        private Outline outline;

        public void SelectOrUnselect()
        {
            outline ??= gameObject.AddComponent<Outline>();
            outline.enabled = !isSelected;
            isSelected = !isSelected;
        }
    }
}