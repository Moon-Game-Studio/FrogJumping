using UnityEngine.SceneManagement;

namespace MoonGames.Game.FrogJump.StaticData
{
    public static class StaticDatas
    {
        public static int frogCount = 5;

        public static void RestartGame()
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}