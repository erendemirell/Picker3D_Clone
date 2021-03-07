using Game;
using Game.Level;
using Game.Player;
using InputSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField] private Text _currentLevelText;
        [SerializeField] private Text _nextLevelText;
        [SerializeField] private GameObject _tapToStartText;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private Image[] _checkpointImages;

        GameObject _player;

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

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            WriteLevelTexts();
        }

        public void OpenCheckpointImages()
        {
            for (int i = 0; i < _checkpointImages.Length; i++)
            {
                if (_checkpointImages[i].color == Color.white)
                {
                    _checkpointImages[i].color = new Color(255f, 128f, 0f, 255f);
                    break;
                }
            }
        }

        public void CloseCheckpointImages()
        {
            for (int i = 0; i < _checkpointImages.Length; i++)
            {
                _checkpointImages[i].color = Color.white;
            }
        }

        public void OpenTapToStartText()
        {
            _tapToStartText.SetActive(true);
        }

        public void CloseTapToStartText()
        {
            _tapToStartText.SetActive(false);
        }

        public void OpenWinPanel()
        {
            _winPanel.SetActive(true);
        }

        public void CloseWinPanel()
        {
            _winPanel.SetActive(false);
        }

        public void OpenLosePanel()
        {
            _losePanel.SetActive(true);
        }

        public void CloseLosePanel()
        {
            _losePanel.SetActive(false);
        }

        public void ClickNextLevelButton()
        {
            CloseCheckpointImages();
            LevelManager.Instance.DestroyPreviousLevel();
            LevelManager.Instance.InitializeLevel();
            _player.GetComponent<PlayerMovement>().ResetPlayerPosition();
            _player.GetComponent<PlayerMovement>().ChangePlayerMovementStatus();
            _player.GetComponent<InputController>().DeactivateInput();
            WriteLevelTexts();
            CloseWinPanel();
        }

        public void ClickRetryLevelButton()
        {
            Time.timeScale = 1;
            CloseCheckpointImages();
            _player.GetComponent<PlayerCollectableBasket>().ClearPlayerBasket();
            LevelManager.Instance.DestroyPreviousLevel();
            LevelManager.Instance.InitializeLevel();
            _player.GetComponent<PlayerMovement>().ChangePlayerMovementStatus();
            _player.GetComponent<PlayerMovement>().ResetPlayerPosition();
            _player.GetComponent<InputController>().DeactivateInput();
            CloseLosePanel();
        }

        public void WriteLevelTexts()
        {
            _currentLevelText.text = (GameManager.Instance.GetLevel() + 1).ToString();
            _nextLevelText.text = (GameManager.Instance.GetLevel() + 2).ToString();
        }
    }
}