using UnityEngine;

namespace Game
{
    public class GameStatus : MonoBehaviour
    {
        public static GameStatus Instance;

        private const string LEVEL_KEY = "level";

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(this);
            }
        }

        public void SetLevel(int level)
        {
            PlayerPrefs.SetInt(LEVEL_KEY, level);
        }

        public int GetLevel()
        {
            return PlayerPrefs.GetInt(LEVEL_KEY, 0);
        }
    }
}
