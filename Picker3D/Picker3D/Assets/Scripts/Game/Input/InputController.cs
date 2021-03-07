using UI;
using UnityEngine;

namespace InputSystem
{
    public class InputController : MonoBehaviour
    {
        public bool _isInputGiven;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ActivateInput();
            }
        }

        public void ActivateInput()
        {
            _isInputGiven = true;
            UIManager.Instance.CloseTapToStartText();
        }

        public void DeactivateInput()
        {
            _isInputGiven = false;
            UIManager.Instance.OpenTapToStartText();
        }

        public bool GetIsInputGiven()
        {
            return _isInputGiven;
        }
    }
}
