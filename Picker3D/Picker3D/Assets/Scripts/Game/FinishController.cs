using Game.Player;
using UI;
using UnityEngine;

namespace Game
{
    public class FinishController : MonoBehaviour
    {
        BoxCollider _collider;

        // Start is called before the first frame update
        void Start()
        {
            _collider = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                print("Finish");
                _collider.enabled = false;
                other.GetComponent<PlayerCollectableBasket>().ClearPlayerBasket();
                other.GetComponent<PlayerMovement>().ChangePlayerMovementStatus();
                GameManager.Instance.IncreaseLevel();
                UIManager.Instance.OpenWinPanel();
                GameStatus.Instance.SetLevel(GameManager.Instance.GetLevel());
            }
        }
    }
}
