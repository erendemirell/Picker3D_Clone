using Game.Level;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private int _level;

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

            _level = GameStatus.Instance.GetLevel();
        }

        private void Start()
        {
            LevelManager.Instance.InitializeLevel();
        }

        public int GetLevel()
        {
            return _level;
        }

        public void IncreaseLevel()
        {
            _level++;
        }
    }
}
