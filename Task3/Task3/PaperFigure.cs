﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface PaperFigure : Ifigures
    {
        Color GetColor();
        void Paint(Color color);
        bool Painted();
    }
}
