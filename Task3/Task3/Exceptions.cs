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
    }
}
