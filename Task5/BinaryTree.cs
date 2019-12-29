using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
    [DataContract(IsReference = true)]
    public class BinaryTree<T> where T : IComparable
    {

    }
}
