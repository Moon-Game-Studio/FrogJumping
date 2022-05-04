using System;
using MoonGames.Game.FrogJump.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MoonGames.Game.FrogJump.UI
{
    public class MainMenuMono : MonoBehaviour
    {
        public TMP_InputField frogCountTextBox;
        public Button startGameButton;

        private void Start()
        {
            startGameButton.onClick.AddListener(StartGameButtonOnclicked);
            frogCountTextBox.text = string.Empty;
        }

        private void StartGameButtonOnclicked()
        {
            string value = frogCountTextBox.text.Trim();

            try
            {
                int number = int.Parse(value);
                StaticDatas.frogCount = number;
                SceneManager.LoadScene("Game Scene");
            }
            catch (Exception exception)
            {
                Debug.LogError($"[{value}][{value.Length}] geçersiz bir değer. lütfen pozitif bir tam sayı giriniz!");
                Debug.LogError(exception);
            }
        }
    }
}