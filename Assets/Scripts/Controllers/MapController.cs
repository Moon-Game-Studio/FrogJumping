using System;
using MoonGames.Game.FrogJump.Models;
using UnityEngine;

namespace MoonGames.Game.FrogJump.Controllers
{
    public class MapController
    {
        private readonly float distanceBetweenFrogs;
        private readonly Map map;

        public MapController(Map map, float distanceBetweenFrogs)
        {
            this.map = map;
            this.distanceBetweenFrogs = distanceBetweenFrogs;
        }

        public void Select(ColumnMono columnMono)
        {
            columnMono.IsSelected = !columnMono.IsSelected;

            if (!columnMono.IsSelected)
            {
                return;
            }

            if (map.SelectionFrom == null)
            {
                map.SelectionFrom = columnMono;
                map.SelectionFrom.IsSelected = true;
                Debug.Log(map.SelectionFrom);
            }
            else if (map.SelectionFrom != null && map.SelectionTo == null)
            {
                map.SelectionTo = columnMono;
                map.SelectionTo.IsSelected = true;
                Debug.Log(map.SelectionFrom);
                Debug.Log(map.SelectionTo);
                Move();
            }
        }

        private void Move()
        {
            try
            {
                MapRules.Validate(map.SelectionFrom, map.SelectionTo);
                map.SelectionTo.MergeAndMove(map.SelectionFrom.Items, distanceBetweenFrogs);
                map.SelectionFrom.Items.Clear();
            }
            catch (Exception exception)
            {
                Debug.LogWarning(exception);
            }
            finally
            {
                UnSelectColumns();
            }
        }

        private void UnSelectColumns()
        {
            map.SelectionFrom.IsSelected = false;
            map.SelectionTo.IsSelected = false;
            map.SelectionFrom = null;
            map.SelectionTo = null;
        }
    }
}