using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Paper figure interface
    /// </summary>
    public interface PaperFigure : Ifigures
    {
        Color GetColor();
        void Paint(Color color);
        bool Painted();
    }
}
