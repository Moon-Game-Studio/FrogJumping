using UnityEngine;
using UnityEngine.UI;

namespace MoonGames.Game.FrogJump.Monos
{
    public class StoneMono : MonoBehaviour
    {
        public bool isSelected;
        private Outline outline;

        private void Start()
        {
            if (outline == null)
            {
                outline = gameObject.AddComponent<Outline>();
            }
        }

        public void SetOutlineValue(bool value)
        {
            outline.enabled = value;
            isSelected = value;
        }
    }
}