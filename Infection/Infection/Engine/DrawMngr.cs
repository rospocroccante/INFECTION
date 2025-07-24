using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{

    static class DrawMngr
    {
        private static List<I_Drawable> items;

        static DrawMngr()
        {
            items = new List<I_Drawable>();
        }

        public static void AddItem(I_Drawable item)
        {
            items.Add(item);
        }

        public static void RemoveItem(I_Drawable item)
        {
            items.Remove(item);
        }

        public static void ClearAll()
        {
            for (int i = 0; i < items.Count; i++)
            {
                items.Clear();
            }
        }

        public static void Draw()
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Draw();
            }
        }
    }
}
