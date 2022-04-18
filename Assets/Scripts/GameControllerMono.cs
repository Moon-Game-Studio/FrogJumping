using UnityEngine;

namespace MoonGames.Game.FrogJump
{
    public class GameControllerMono : MonoBehaviour
    {
        public Camera mainCamera;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectObject();
            }
        }

        private void SelectObject()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.Log(Input.mousePosition);
            bool raycast = Physics.Raycast(ray, out RaycastHit hit);
            if (!raycast)
            {
                return;
            }

            if (!hit.transform.gameObject.TryGetComponent(out SelectableMono selectable))
            {
                return;
            }

            selectable.SelectOrUnselect();
        }
    }
}