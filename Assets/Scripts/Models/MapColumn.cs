using System.Collections.Generic;
using MoonGames.Game.FrogJump.Monos;

namespace MoonGames.Game.FrogJump.Models
{
    public class MapColumn
    {
        public MapColumn(int index, StoneMono stone)
        {
            Index = index;
            Stone = stone;
            Items = new List<SelectableMono>();
        }

        public bool IsSelected { get; set; }
        public List<SelectableMono> Items { get; }
        public int Index { get; }
        public StoneMono Stone { get; }

        public void Add(IEnumerable<SelectableMono> items)
        {
            
            Items.AddRange(items);
        }
    }
}