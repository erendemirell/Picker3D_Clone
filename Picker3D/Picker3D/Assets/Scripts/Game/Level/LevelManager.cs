using System.Collections.Generic;
using UnityEngine;

namespace Game.Level
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        public List<Level> levels;
        private Level _currentLevel;

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

        public void InitializeLevel()
        {
            int randomLevel = Random.Range(0, levels.Count);

            _currentLevel = Instantiate(levels[randomLevel]);
            _currentLevel.Initialize();
        }

        public void DestroyPreviousLevel()
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel.gameObject);
            }
        }

        public void RetryLevel()
        {
            _currentLevel = Instantiate(_currentLevel);
            _currentLevel.Initialize();
        }
    }
}
