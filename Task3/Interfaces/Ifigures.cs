using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Colors
    /// </summary>
    public enum Color
    {
        None, Red, Green, Blue, White, Black
    }
    /// <summary>
    /// Figures interface
    /// </summary>
    public interface Ifigures
    {
        double SquareFigure { get; }
        double Perimeter { get; }
        string GetMaterial();
        string GetTypeFigure();
    }
}
