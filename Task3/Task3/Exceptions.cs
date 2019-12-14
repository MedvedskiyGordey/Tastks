using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Exceptions
    {
        public class InvalidParamException : Exception
        {
            public override string Message
            {
                get { return "Invalid parameters."; }
            }
            public InvalidParamException() : base()
            {
            }
        }
        public class CutException : Exception
        {
            public override string Message
            {
                get { return "Unable to cut."; }
            }

            public CutException() : base()
            {
            }
        }
        public class PaintException : Exception
        {
            public override string Message
            {
                get { return "Already painted."; }
            }

            public PaintException() : base()
            {
            }
        }

        public class EmptyBoxException : Exception
        {
            public override string Message
            {
                get { return "Empty box."; }
            }

            public EmptyBoxException() : base()
            {
            }
        }

        public class ExistFigureException : Exception
        {
            public override string Message
            {
                get { return "The figure is already in the box."; }
            }

            public ExistFigureException() : base()
            {
            }
        }

        public class NoPlaceException : Exception
        {
            public override string Message
            {
                get { return "In the box, the maximum number of figures."; }
            }

            public NoPlaceException() : base()
            {
            }
        }

        /*public class NotFoundException : Exception
        {
            public override string Message
            {
                get { return "Figure not found."; }
            }

            public NotFoundException() : base()
            {
            }
        }*/
    }
}
