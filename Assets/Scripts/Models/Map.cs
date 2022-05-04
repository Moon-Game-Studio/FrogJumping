using System.Collections.Generic;
using MoonGames.Game.FrogJump.Monos;
using UnityEngine;

namespace MoonGames.Game.FrogJump.Models
{
    public class Map
    {
        private readonly GameObject columnPrefab;
        private readonly int count;
        private readonly float distanceBetweenColumns;
        private readonly float distanceBetweenFrogs;
        private readonly GameObject frogPrefab;

        public Map(
            int count,
            GameObject columnPrefab,
            float distanceBetweenColumns,
            GameObject frogPrefab,
            float distanceBetweenFrogs)
        {
            this.count = count;
            this.columnPrefab = columnPrefab;
            this.distanceBetweenColumns = distanceBetweenColumns;
            this.frogPrefab = frogPrefab;
            this.distanceBetweenFrogs = distanceBetweenFrogs;
        }

        public ColumnMono SelectionFrom { get; set; }
        public ColumnMono SelectionTo { get; set; }
        public Dictionary<int, ColumnMono> Columns { get; private set; }

        public void InitialiseColumns(Transform parent, Vector3 anchorPoint)
        {
            Columns = new Dictionary<int, ColumnMono>();
            Vector3 zPoint = anchorPoint;
            Vector3 yPoint = anchorPoint;
            for (var i = 0; i < count; i++)
            {
                ColumnMono column = InitializeColumn(parent, i, zPoint);
                InitializeFrog(column, yPoint, column.transform);
                zPoint.z += distanceBetweenColumns;
                yPoint = zPoint;
            }
        }

        private void InitializeFrog(ColumnMono component, Vector3 yPoint, Transform parent)
        {
            GameObject frogObject = Object.Instantiate(frogPrefab, yPoint, frogPrefab.transform.rotation, parent);
            var outlinebleMono = frogObject.AddComponent<OutlinebleMono>();
            component.Items = new List<OutlinebleMono>();
            component.Items.Add(outlinebleMono);
        }

        private ColumnMono InitializeColumn(Transform parent, int i, Vector3 zPoint)
        {
            GameObject item = Object.Instantiate(columnPrefab, zPoint, Quaternion.identity, parent);
            item.name = i.ToString();
            var component = item.GetComponent<ColumnMono>();
            component.Index = i;
            Columns.Add(i, component);
            return component;
        }
    }
}