using InputSystem;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _verticalSpeed;
        [SerializeField] private float _horizontalSpeed;

        private Vector3 _mousePos;
        private Vector3 _firstPosition = new Vector3(0f, 0.25f, 0f);
        private Vector3 _currentPosition;
        private float _distanceToScreen;
        public bool _playerMovementStatus = true;

        private InputController _inputController;

        // Start is called before the first frame update
        void Start()
        {
            _inputController = gameObject.GetComponent<InputController>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!_playerMovementStatus || !_inputController.GetIsInputGiven())
                return;

            if (Input.GetMouseButton(0))
            {
                var position = Input.mousePosition;

                _distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, _distanceToScreen));
                float direction = _horizontalSpeed;
                direction = _mousePos.x > transform.position.x ? direction : -direction;

                if (Mathf.Abs(_mousePos.x - transform.position.x) > 0.5f)
                    transform.Translate(Time.deltaTime * direction, 0, 0);
            }

            transform.Translate(0, 0, Time.deltaTime * _verticalSpeed);

            _currentPosition = transform.position;
            _currentPosition.x = Mathf.Clamp(_currentPosition.x, -3f, 3f);
            transform.position = _currentPosition;
        }

        public void ChangePlayerMovementStatus()
        {
            if (_playerMovementStatus)
                _playerMovementStatus = !_playerMovementStatus;
            else
                _playerMovementStatus = !_playerMovementStatus;
        }

        public void ResetPlayerPosition()
        {
            transform.position = _firstPosition;
        }
    }
}
