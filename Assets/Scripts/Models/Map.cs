using System.Collections.Generic;
using MoonGames.Game.FrogJump.Monos;

namespace MoonGames.Game.FrogJump.Models
{
    public class Map
    {
        public Map(int count)
        {
            Selectables = new SelectableMono[count];
            InitialiseColumns(count);
        }
        
        public MapColumn SelectionFrom { get; set; }
        public MapColumn SelectionTo { get; set; }

        public SelectableMono[] Selectables { get; }
        public Dictionary<int, List<SelectableMono>> Columns { get; private set; }

        private void InitialiseColumns(int count)
        {
            Columns = new Dictionary<int, List<SelectableMono>>(count);
            for (var i = 0; i < count; i++)
            {
                Columns.Add(i, new List<SelectableMono>());
            }
        }
    }
}