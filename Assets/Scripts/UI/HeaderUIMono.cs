using MoonGames.Game.FrogJump.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace MoonGames.Game.FrogJump.UI
{
    public class HeaderUIMono : MonoBehaviour
    {
        public Button restartButton;

        private void Start()
        {
            restartButton.onClick.AddListener(OnRestart);
        }

        private static void OnRestart()
        {
            StaticDatas.RestartGame();
        }
    }
}