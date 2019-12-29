using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
    [DataContract(IsReference = true)]
    /// <summary>
    /// Binary tree class
    /// </summary>
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTree()
        {
        }

        [DataMember]
        /// <summary>
        /// Root node
        /// </summary>
        public Node<T> RootNode { get; private set; }

        [DataMember]
        /// <summary>
        /// Number of nodes
        /// </summary>
        public int NodeCount { get; private set; }

        /// <summary>
        /// Adding a node to the binary tree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        private Node<T> Add(Node<T> node, Node<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentBranch = null;
                NodeCount++;
                return RootNode = node;
            }
            
            if (currentNode == null)
            {
                currentNode = RootNode;
            }
            
            node.ParentBranch = currentNode;
            
            int compareRes = node.Data.CompareTo(currentNode.Data);//Node comparison

            if (compareRes == 0)
            {
                if (currentNode.RightBranch == null)
                {
                    NodeCount++;
                    return currentNode.RightBranch = node;
                }
                else
                {
                    return Add(node, currentNode.RightBranch);
                }
            }
            else if (compareRes < 0)
            {
                if (currentNode.LeftBranch == null)
                {
                    NodeCount++;
                    return currentNode.LeftBranch = node;
                }
                else
                {
                    return Add(node, currentNode.LeftBranch);
                }
            }
            else
            {
                if (currentNode.RightBranch == null)
                {
                    NodeCount++;
                    return currentNode.RightBranch = node;
                }
                else
                {
                    return Add(node, currentNode.RightBranch);
                }
            }
        }

        /// <summary>
        /// Adding Data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node<T> Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentException("Not null.");
            }
            return Add(new Node<T>(data));
        }

        /// <summary>
        /// Node deletion
        /// </summary>
        /// <param name="node"></param>
        public void Remove(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentException("Not null.");
            }
            
            var side = node.BranchSide;
            
            if (node.LeftBranch == null && node.RightBranch == null)
            {
                if (side == null & node.ParentBranch == null)
                {
                    RootNode = null;
                    return;
                }
                
                if (side == Side.Left)
                {
                    node.ParentBranch.LeftBranch = null;
                }
                else
                {
                    node.ParentBranch.RightBranch = null;
                }
            }
            else if (node.LeftBranch == null)
            {
                if (side == Side.Left)
                {
                    node.ParentBranch.LeftBranch = node.RightBranch;
                }
                else if (side == Side.Right)
                {
                    node.ParentBranch.RightBranch = node.RightBranch;
                }
                else
                {
                    node.ParentBranch = null;
                    RootNode = node.RightBranch;
                }
            }
            else if (node.RightBranch == null)
            {
                if (side == Side.Left)
                {
                    node.ParentBranch.LeftBranch = node.LeftBranch;
                }
                else if (side == Side.Right)
                {
                    node.ParentBranch.RightBranch = node.LeftBranch;
                }
                else
                {
                    node.ParentBranch = null;
                    RootNode = node.LeftBranch;
                }
            }
            else
            {
                if (side == Side.Left)
                {
                    node.ParentBranch.LeftBranch = node.RightBranch;
                    node.RightBranch.ParentBranch = node.ParentBranch;
                    Add(node.LeftBranch, node.RightBranch);
                }
                else if (side == Side.Right)
                {
                    node.ParentBranch.RightBranch = node.RightBranch;
                    node.RightBranch.ParentBranch = node.ParentBranch;
                    Add(node.LeftBranch, node.RightBranch);
                }
                else
                {
                    var left = node.LeftBranch;
                    var rightLeft = node.RightBranch.LeftBranch;
                    var rightRight = node.RightBranch.RightBranch;
                    
                    node.Data = node.RightBranch.Data;
                    
                    node.RightBranch = rightRight;
                    node.LeftBranch = rightLeft;
                    
                    Add(left, node);
                }
            }
        }
        
        /// <summary>
        /// Find node
        /// </summary>
        /// <param name="data"></param>
        /// <param name="startNode"></param>
        /// <returns></returns>
        public Node<T> Find(T data, Node<T> startNode = null)
        {
            if (startNode == null)
            {
                startNode = RootNode;
            }
            
            int compareRes = data.CompareTo(startNode.Data);
            
            if (compareRes == 0) return startNode;
            else if (compareRes < 0)
            {
                if (startNode.LeftBranch == null)
                {
                    return null;
                }
                else
                {
                    return Find(data, startNode.LeftBranch);
                }
            }
            else
            {
                if (startNode.RightBranch == null)
                {
                    return null;
                }
                else
                {
                    return Find(data, startNode.RightBranch);
                }
            }
        }

        /// <summary>
        /// Tree balancing
        /// </summary>
        public void BalanceTree()
        {
            List<Node<T>> listOfNodes = new List<Node<T>>();

            FillList(RootNode, listOfNodes);
            foreach (Node<T> node in listOfNodes)
            {
                node.LeftBranch = null;
                node.RightBranch = null;
            }


            RootNode = null;
            int count = NodeCount;
            NodeCount = 0;
            
            BalanceTree(0, count - 1, listOfNodes);
        }

        /// <summary>
        /// List filling
        /// </summary>
        /// <param name="node"></param>
        /// <param name="list"></param>
        private void FillList(Node<T> node, List<Node<T>> list)
        {
            if (node != null)
            {
                FillList(node.LeftBranch, list);
                
                list.Add(node);
                
                FillList(node.RightBranch, list);
            }
        }

        /// <summary>
        /// Tree balancing
        /// </summary>
        private void BalanceTree(int minSublist, int maxSublist, List<Node<T>> list)
        {
            if (minSublist <= maxSublist)
            {
                int middleNode = (int)Math.Ceiling(((double)minSublist + maxSublist) / 2);
                
                Add(list[middleNode]);
                
                BalanceTree(minSublist, middleNode - 1, list);
                BalanceTree(middleNode + 1, maxSublist, list);
            }
        }
    }
}
