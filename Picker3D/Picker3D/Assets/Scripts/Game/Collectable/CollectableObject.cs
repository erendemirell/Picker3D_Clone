using UnityEngine;

namespace Game.Collectable
{
    public class CollectableObject : MonoBehaviour
    {
        [SerializeField] float pushForce = 10f;

        Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void PushObject()
        {
            _rigidbody.AddForce(Vector3.forward * pushForce);
        }
    }
}
