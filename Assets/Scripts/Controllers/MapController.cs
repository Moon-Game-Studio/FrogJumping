using MoonGames.Game.FrogJump.Models;

namespace MoonGames.Game.FrogJump.Controllers
{
    public class MapController
    {
        private readonly Map map;

        public MapController(Map map)
        {
            this.map = map;
        }

        public void Select(MapColumn column)
        {
            column.IsSelected = !column.IsSelected;

            if (!column.IsSelected)
            {
                return;
            }

            if (map.SelectionFrom == null)
            {
                map.SelectionFrom = column;
            }
            else if (map.SelectionFrom != null && map.SelectionTo != null)
            {
                map.SelectionTo = column;
                Move();
            }
        }

        private void Move()
        {
            MapRules.Validate(map.SelectionFrom, map.SelectionTo);
            map.SelectionTo.Add(map.SelectionFrom.Items);
            map.SelectionFrom.Items.Clear();
            UnSelectColumns();
        }

        private void UnSelectColumns()
        {
            map.SelectionFrom.IsSelected = false;
            map.SelectionTo.IsSelected = false;
            //TODO animation etc
        }
    }
}