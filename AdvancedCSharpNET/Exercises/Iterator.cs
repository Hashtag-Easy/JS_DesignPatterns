﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Exercises
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }

        //implement Pre-Order traversal over given tree
        public IEnumerable<T> PreOrder
        {
            get
            {
                foreach (var node in PreOrderTraverse(this)) 
                {
                    yield return node.Value;
                }
            }
        }


        private IEnumerable<Node<T>> PreOrderTraverse(Node<T> root)
        {
            yield return root;

            if(root.Left != null) 
            {
                foreach (var left in PreOrderTraverse(root.Left))
                {
                    yield return left;
                }
            }
            if (root.Right != null)
            {
                foreach (var right in PreOrderTraverse(root.Right))
                {
                    yield return right;
                }
            }
        }
    }
}
