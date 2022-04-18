using UnityEngine;

namespace MoonGames.Game.FrogJump
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
            float z0 = currentPoint.transform.position.z;
            float z1 = nextPoint.transform.position.z;
            float dist = z1 - z0;

            float nextZ = Mathf.MoveTowards(transform.position.z, z1, jumpSpeed * Time.deltaTime);
            float baseY = Mathf.Lerp(currentPoint.transform.position.y, nextPoint.transform.position.y, (nextZ - z0) / dist);
            float arc = height * (nextZ - z0) * (nextZ - z1) / (-0.25f * dist * dist);

            float x0 = currentPoint.transform.position.x;
            float x1 = nextPoint.transform.position.x;
            float nextX = Mathf.MoveTowards(transform.position.x, x1, jumpSpeed * Time.deltaTime);

            var nPos = new Vector3(nextX, baseY + arc, nextZ);

            transform.position = nPos;
        }
    }
}