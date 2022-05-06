using System;
using System.Linq;
using MoonGames.Game.FrogJump.Models;
using MoonGames.Game.FrogJump.StaticData;
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
            }
            else if (map.SelectionFrom != null && map.SelectionTo == null)
            {
                map.SelectionTo = columnMono;
                map.SelectionTo.IsSelected = true;
                Move();
            }
            else
            {
                UnSelectColumns();
            }
        }

        private void OnMovementAnimationEnd()
        {
            UnSelectColumns();
            if (IsGameEnd())
            {
                StaticDatas.RestartGame();
            }
        }

        private bool IsGameEnd()
        {
            return map.Columns.Any(o => o.Value.Items.Count == map.Columns.Count);
        }

        private void Move()
        {
            try
            {
                MapRules.Validate(map.SelectionFrom, map.SelectionTo);
                map.SelectionTo.MergeAndMove(map.SelectionFrom.Items, distanceBetweenFrogs, OnMovementAnimationEnd);
                map.SelectionFrom.Items.Clear();
            }
            catch (Exception exception)
            {
                UnSelectColumns();
                Debug.LogError(exception);
            }
        }

        private void UnSelectColumns()
        {
            if (map.SelectionFrom != null)
            {
                map.SelectionFrom.IsSelected = false;
                map.SelectionFrom = null;
            }

            if (map.SelectionTo != null)
            {
                map.SelectionTo.IsSelected = false;
                map.SelectionTo = null;
            }
        }
    }
}