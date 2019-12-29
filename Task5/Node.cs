using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
    /// <summary>
    /// Node location
    /// </summary>
    public enum Side
    {
        Left,
        Right
    }

    [DataContract(IsReference = true)]
    /// <summary>
    /// A class that describes a binary tree node
    /// </summary>
    public class Node<T> where T : IComparable
    {
        public Node()
        {
        }

        public Node(T data)
        {
            Data = data;
        }

        [DataMember]
        /// <summary>
        /// Node data
        /// </summary>
        public T Data { get; set; }

        [DataMember]
        /// <summary>
        /// Left Node
        /// </summary>
        public Node<T> LeftBranch { get; set; }

        [DataMember]
        /// <summary>
        /// Right Node
        /// </summary>
        public Node<T> RightBranch { get; set; }

        [DataMember]
        /// <summary>
        /// Parent Node
        /// </summary>
        public Node<T> ParentBranch { get; set; }   

        [DataMember]
        /// <summary>
        /// Node location
        /// </summary>
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

        public override bool Equals(object obj)
        {
            return obj is Node<T> node &&
                   EqualityComparer<T>.Default.Equals(Data, node.Data) &&
                   EqualityComparer<Node<T>>.Default.Equals(LeftBranch, node.LeftBranch) &&
                   EqualityComparer<Node<T>>.Default.Equals(RightBranch, node.RightBranch) &&
                   EqualityComparer<Node<T>>.Default.Equals(ParentBranch, node.ParentBranch);
        }

        public override int GetHashCode()
        {
            var hashCode = 613751;
            hashCode = hashCode * 32154681 + EqualityComparer<T>.Default.GetHashCode(Data);
            hashCode = hashCode * 32154681 + EqualityComparer<Node<T>>.Default.GetHashCode(LeftBranch);
            hashCode = hashCode * 32154681 + EqualityComparer<Node<T>>.Default.GetHashCode(RightBranch);
            hashCode = hashCode * 32154681 + EqualityComparer<Node<T>>.Default.GetHashCode(ParentBranch);
            return hashCode;
        }
    }
}
