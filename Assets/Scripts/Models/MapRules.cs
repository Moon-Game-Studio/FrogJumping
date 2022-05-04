using System;

namespace MoonGames.Game.FrogJump.Models
{
    public static class MapRules
    {
        public static void Validate(ColumnMono from, ColumnMono to)
        {
            CanMerge(from, to);
        }

        private static void CanMerge(ColumnMono from, ColumnMono to)
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

        private static bool IsThereEnoughFrogsToJump(ColumnMono from, ColumnMono to)
        {
            return Math.Abs(from.Index - to.Index) == from.Items.Count;
        }

        private static bool IsCurrentColumnEmpty(ColumnMono columnMono)
        {
            return columnMono.Items.Count == 0;
        }

        private static bool IsDestinationColumnEmpty(ColumnMono columnMono)
        {
            return columnMono.Items.Count == 0;
        }
    }
}