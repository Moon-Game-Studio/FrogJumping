using UnityEngine;

namespace MoonGames.Game.FrogJump.Monos
{
    public class JumpingMono : MonoBehaviour
    {
        public float height = 1f;
        public float jumpSpeed = 5f;

        public GameObject currentPoint;
        public GameObject nextPoint;

        private void Start() { }

        private void Update()
        {
            Vector3 currentPosition = currentPoint.transform.position;
            Vector3 nextPosition = nextPoint.transform.position;
            float currentZ = currentPosition.z;
            float destinationZ = nextPosition.z;
            float dist = destinationZ - currentZ;

            float nextZ = Mathf.MoveTowards(transform.position.z, destinationZ, jumpSpeed * Time.deltaTime);
            float baseY = Mathf.Lerp(currentPosition.y, nextPosition.y, (nextZ - currentZ) / dist);
            float arc = height * (nextZ - currentZ) * (nextZ - destinationZ) / (-0.25f * dist * dist);

            float x0 = currentPosition.x;
            float x1 = nextPosition.x;
            float nextX = Mathf.MoveTowards(transform.position.x, x1, jumpSpeed * Time.deltaTime);

            var nPos = new Vector3(nextX, baseY + arc, nextZ);

            transform.position = nPos;
        }
    }
}