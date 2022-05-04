using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using MoonGames.Game.FrogJump.Monos;
using UnityEngine;

namespace MoonGames.Game.FrogJump.Models
{
    [UsedImplicitly]
    public class ColumnMono : MonoBehaviour
    {
        public StoneMono stone;
        private bool isSelected;

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                SetOutline(value);
            }
        }

        public List<OutlinebleMono> Items { get; set; }

        public int Index { get; set; }

        private void SetOutline(bool value)
        {
            stone.SetOutlineValue(value);
        }

        public void MergeAndMove(IEnumerable<OutlinebleMono> items, float distanceBetweenFrogs)
        {
            Vector3 position = Items.Last().gameObject.transform.position;
            
            foreach (OutlinebleMono frog in items)
            {
                frog.transform.parent = transform;
                position = GetFrogPosition(distanceBetweenFrogs, position);
                var routine = new JumpingRoutine(frog.gameObject, frog.transform.position, position);
                StartCoroutine(routine.Jump());
                //frog.transform.position = position;
                Items.Add(frog);
            }
        }

        private Vector3 GetFrogPosition(float distanceBetweenFrogs, Vector3 position)
        {
            return new Vector3(position.x, position.y + distanceBetweenFrogs, position.z);
        }
    }
}