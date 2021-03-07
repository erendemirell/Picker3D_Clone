using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] GameObject player;
        [SerializeField] Vector3 offset;

        // Use this for initialization
        void Start()
        {
            offset = transform.position - player.transform.position;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = player.transform.position + offset - new Vector3(player.transform.position.x, player.transform.position.y);
        }
    }
}
