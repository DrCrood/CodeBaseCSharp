using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algoriths.Tree
{
    public abstract class Node
    {
        public abstract int Evaluate();

        public int Value;
        public char Oper;
        public bool IsOper;
        public Node? Left;
        public Node? Right;
        public bool Covered;
    };

    public class ExpressionNode : Node
    {
        public override int Evaluate()
        {
            if (IsOper)
            {
                int leftvalue = Left.Evaluate();
                int rightvalue = Right.Evaluate();
                return Oper switch
                {
                    '+' => leftvalue + rightvalue,
                    '-' => leftvalue - rightvalue,
                    '*' => leftvalue * rightvalue,
                    '/' => leftvalue / rightvalue,
                    _ => 0,
                };
            }
            else
            {
                return Value;
            }
        }
    }

    public class TreeBuilder
    {
        public Node buildTree(string[] postfix)
        {

            List<ExpressionNode> nodes = new List<ExpressionNode>();
            foreach (string s in postfix)
            {
                if (s.Length > 1 || s[0] > 47)
                {
                    nodes.Add(new ExpressionNode()
                    {
                        Value = Int32.Parse(s),
                        IsOper = false,
                        Covered = false
                    });
                }
                else
                {
                    nodes.Add(new ExpressionNode()
                    {
                        IsOper = true,
                        Oper = s[0],
                        Covered = false
                    });
                }
            }

            ExpressionNode lastNode = null;
            int lastNodeIndex = 0;
            int nodesCount = nodes.Count;
            int OpIndex = 0;
            while (nodesCount > 0)
            {
                //find the first operator
                while (!nodes[OpIndex].IsOper || nodes[OpIndex].Covered)
                {
                    OpIndex++;
                }

                if (lastNode == null)
                {
                    lastNode = nodes[OpIndex];
                    lastNode.Left = nodes[OpIndex - 2];
                    lastNode.Right = nodes[OpIndex - 1];
                    lastNodeIndex = OpIndex - 2;

                    lastNode.Covered = true;
                    lastNode.Left.Covered = true;
                    lastNode.Right.Covered = true;
                    nodesCount -= 3;
                }
                else
                {
                    //use the first digit on the left of the operator
                    int digInex = OpIndex - 1;
                    while (nodes[digInex].IsOper || nodes[digInex].Covered)
                    {
                        digInex--;
                    }
                    if (lastNodeIndex > digInex)
                    {
                        nodes[OpIndex].Left = nodes[digInex];
                        nodes[OpIndex].Right = lastNode;
                    }
                    else
                    {
                        nodes[OpIndex].Left = lastNode;
                        nodes[OpIndex].Right = nodes[digInex];

                    }
                    nodes[digInex].Covered = true;
                    nodes[OpIndex].Covered = true;
                    lastNode = nodes[OpIndex];
                    nodesCount -= 2;
                }
            }

            return lastNode;

        }

    }
}
