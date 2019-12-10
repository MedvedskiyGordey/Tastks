using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public enum Color
    {
        None, Red, Green, Blue, White, Black
    }
    public interface Ifigures
    {
        double Square { get; }
        double Perimetr { get; }
        string GetMaterial();
        string GetTypeFigure();
    }
}
