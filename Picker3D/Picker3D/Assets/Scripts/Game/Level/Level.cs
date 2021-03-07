using Game.Collectable;
using UnityEngine;

namespace Game.Level
{
    public class Level : MonoBehaviour
    {
        private CheckpointCounterPlatform[] _checkpointPlatforms;

        public void Initialize()
        {
            _checkpointPlatforms = GetComponentsInChildren<CheckpointCounterPlatform>();

            for (int i = 0; i < _checkpointPlatforms.Length; i++)
            {
                _checkpointPlatforms[i].SetTargetCount(i);
            }
        }
    }
}
