using UnityEngine;
using TMPro;

namespace Game.Collectable
{
    public class CheckpointCounterPlatform : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _counterText;

        private int _currentCount;
        private int _targetCount;

        private void OnCollisionEnter(Collision collision)
        {
            var collectable = collision.gameObject.GetComponent<CollectableObject>();

            if (collectable != null)
            {
                _counterText.text = ++_currentCount + "/" + _targetCount;
                Destroy(collectable.gameObject);
            }
        }

        public bool CheckPlayerCollectableCount()
        {
            if (_currentCount >= _targetCount)
                return true;
            else
                return false;
        }

        public void SetTargetCount(int index)
        {
            int currentLevel = GameManager.Instance.GetLevel();
            int targetCountMultiplier = Mathf.CeilToInt(currentLevel / 10f);
            if (targetCountMultiplier == 0) targetCountMultiplier = 1;
            if (targetCountMultiplier > 3) targetCountMultiplier = 3;

            switch (index)
            {
                case 0:
                    _targetCount = targetCountMultiplier * 10;
                    break;
                case 1:
                    _targetCount = (targetCountMultiplier + 1) * 10;
                    break;
                case 2:
                    _targetCount = (targetCountMultiplier + 2) * 10;
                    break;
                default:
                    break;
            }

            _counterText.text = _currentCount + "/" + _targetCount;
        }
    }
}
