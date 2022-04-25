using cakeslice;
using UnityEngine;

namespace MoonGames.Game.FrogJump.Monos
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