using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
    public enum Side
    {
        Left,
        Right
    }

    [DataContract(IsReference = true)]
    public class Node<T> where T : IComparable
    {
        public Node(T data)
        {
            Data = data;
        }

        [DataMember]
        public T Data { get; set; }

        [DataMember]
        public Node<T> LeftBranch { get; set; }

        [DataMember]
        public Node<T> RightBranch { get; set; }

        [DataMember]
        public Node<T> ParentBranch { get; set; }

        [DataMember]
        public Side? BranchSide
        {
            get
            {
                if (ParentBranch == null)
                {
                    return null;
                }
                else if (ParentBranch.LeftBranch == this)
                {
                    return Side.Left;
                }
                else
                {
                    return Side.Right;
                }
            }
            private set
            {

            }
        }
    }
}
