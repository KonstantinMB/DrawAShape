using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borimechkov.ProjectShapes.Figures
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(string message)
            : base(message)
        {

        }
    }
    public class InvalidTextException : Exception
    {
        public InvalidTextException(string message)
            :base(message)
        {

        }
    }
    public class InvalidColorException : Exception
    {
        public InvalidColorException()
        {

        }
    }
}
