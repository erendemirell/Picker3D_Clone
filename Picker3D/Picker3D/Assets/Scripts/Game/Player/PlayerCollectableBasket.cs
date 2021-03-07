using Game.Collectable;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player {
    public class PlayerCollectableBasket : MonoBehaviour
    {
        private List<CollectableObject> _playerBasket = new List<CollectableObject>();

        public void PushAllCollectables()
        {
            foreach (var item in _playerBasket)
            {
                item.PushObject();
            }
        }

        public void ClearPlayerBasket()
        {
            _playerBasket.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            var collectable = other.GetComponent<CollectableObject>();

            if (collectable != null)
            {
                _playerBasket.Add(collectable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var collectable = other.GetComponent<CollectableObject>();

            if (collectable != null)
            {
                _playerBasket.Remove(collectable);
            }
        }
    }
}
