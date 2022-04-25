using System;

namespace MoonGames.Game.FrogJump.Models
{
    public static class MapRules
    {
        public static void Validate(MapColumn from, MapColumn to)
        {
            CanMerge(from, to);
        }

        private static void CanMerge(MapColumn from, MapColumn to)
        {
            if (IsCurrentColumnEmpty(from))
            {
                throw new Exception(nameof(IsCurrentColumnEmpty));
            }

            if (IsDestinationColumnEmpty(to))
            {
                throw new Exception(nameof(IsDestinationColumnEmpty));
            }

            if (!IsThereEnoughFrogsToJump(from, to))
            {
                throw new Exception(nameof(IsThereEnoughFrogsToJump));
            }
        }

        private static bool IsThereEnoughFrogsToJump(MapColumn from, MapColumn to)
        {
            return Math.Abs(from.Index - to.Index) == from.Items.Count;
        }

        private static bool IsCurrentColumnEmpty(MapColumn column)
        {
            return column.Items.Count == 0;
        }

        private static bool IsDestinationColumnEmpty(MapColumn column)
        {
            return column.Items.Count == 0;
        }
    }
}