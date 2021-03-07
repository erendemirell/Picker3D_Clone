using Game.Player;
using System.Collections;
using UI;
using UnityEngine;

namespace Game.Collectable
{
    public class CheckpointPlatform : MonoBehaviour
    {
        [SerializeField] private GameObject _checkpointGround;
        [SerializeField] private Transform _gateLeft;
        [SerializeField] private Transform _gateRight;

        private bool _isCheckpointPassed;
        private CheckpointCounterPlatform _counterPlatform;

        // Start is called before the first frame update
        void Start()
        {
            _counterPlatform = GetComponentInChildren<CheckpointCounterPlatform>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(CheckPlayerCollectableCountCoroutine());
                GetComponent<Collider>().enabled = false;
                other.GetComponent<PlayerMovement>().ChangePlayerMovementStatus();
                other.GetComponent<PlayerCollectableBasket>().PushAllCollectables();
            }
        }

        IEnumerator CheckPlayerCollectableCountCoroutine()
        {
            yield return new WaitForSeconds(3f);//delay for collectables 

            _isCheckpointPassed = _counterPlatform.CheckPlayerCollectableCount();

            if (_isCheckpointPassed)
            {
                StartCoroutine(OpenGateCoroutine());
                _checkpointGround.SetActive(true);
                while (_checkpointGround.transform.localPosition.y != 0)
                {
                    yield return new WaitForFixedUpdate();
                    _checkpointGround.transform.localPosition = Vector3.MoveTowards(_checkpointGround.transform.localPosition, new Vector3(_checkpointGround.transform.localPosition.x, 0f, _checkpointGround.transform.localPosition.z), 5f * Time.fixedDeltaTime);
                }
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ChangePlayerMovementStatus();
                UIManager.Instance.OpenCheckpointImages();
            }
            else
            {
                Time.timeScale = 0;
                UIManager.Instance.OpenLosePanel();
            }
        }

        IEnumerator OpenGateCoroutine()
        {
            while (_gateLeft.rotation.x != -90f)
            {
                _gateLeft.rotation = Quaternion.Lerp(_gateLeft.rotation, Quaternion.Euler(-90f, 90f, 90f), Time.deltaTime * 2f);
                _gateRight.rotation = Quaternion.Lerp(_gateRight.rotation, Quaternion.Euler(90f, 90f, 90f), Time.deltaTime * 2f);

                yield return null;
            }
        }
    }
}
