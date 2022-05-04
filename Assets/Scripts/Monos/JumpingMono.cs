using System.Collections;
using UnityEngine;

namespace MoonGames.Game.FrogJump.Monos
{
    public class JumpingRoutine
    {
        private readonly GameObject jumper;
        private readonly Vector3 startPoint;
        private readonly Vector3 destionationPoint;

        public float height = 1f;
        public float jumpSpeed = 5f;

        public JumpingRoutine(GameObject jumper, Vector3 startPoint, Vector3 destionationPoint)
        {
            this.jumper = jumper;
            this.startPoint = startPoint;
            this.destionationPoint = destionationPoint;
        }

        public IEnumerator Jump()
        {
            while (Vector3.Distance(jumper.transform.position, destionationPoint) > 0.1f)
            {
                Transform transform = jumper.transform;
                float currentZ = startPoint.z;
                float destinationZ = destionationPoint.z;
                float dist = destinationZ - currentZ;

                Vector3 position = transform.position;
                float nextZ = Mathf.MoveTowards(position.z, destinationZ, jumpSpeed * Time.deltaTime);
                float baseY = Mathf.Lerp(startPoint.y, destionationPoint.y, (nextZ - currentZ) / dist);
                float arc = height * (nextZ - currentZ) * (nextZ - destinationZ) / (-0.25f * dist * dist);

                float x0 = startPoint.x;
                float x1 = destionationPoint.x;
                float nextX = Mathf.MoveTowards(position.x, x1, jumpSpeed * Time.deltaTime);

                var nPos = new Vector3(nextX, baseY + arc, nextZ);

                position = nPos;
                transform.position = position;
                yield return new WaitForSeconds(0.01f);
            }
            
        }
    }
}