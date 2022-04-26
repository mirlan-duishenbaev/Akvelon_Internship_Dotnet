using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse_Tree
{
    internal class Operations
    {

        public static void DoTree<T>(Tree<T> tree, Action<T> action)
        {
            if (tree == null) return;
            Parallel.Invoke(
                ()=> DoTree(tree.Left, action),
                ()=> DoTree(tree.Right, action),
                ()=> action(tree.Data)
            );
        }
    }
}
