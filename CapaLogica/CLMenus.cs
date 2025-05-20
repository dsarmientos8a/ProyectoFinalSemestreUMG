using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    internal class CLMenus
    {
        public int MtdTipoMenu(string Precio)
        {
            int PrecioMenu = 0;
            switch(Precio)
            {
                case "Desayunos":
                    PrecioMenu = 50;
                    break;
                case "Almuerzos":
                    PrecioMenu = 100;
                    break;
                case "Cenas":
                    PrecioMenu = 75;
                    break;
                case "Postres":
                    PrecioMenu = 35;
                    break;
                case "Bebidas":
                    PrecioMenu = 25;
                    break;
            }

            return PrecioMenu;
        }
    }
}
