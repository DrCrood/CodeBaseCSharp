using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeBase.DataStructure
{
    public enum OperationType
    {
        PLUS = 0,
        MINUS = 1,
        TIMES = 2,
        DIVIDE = 3,
        UNDEFINED = 4
    }
    internal class ExpNode
    {
        public string expression { get; set; }
        public bool IsDigit { get; set; }
        public double Value { get; set; }
        public ExpNode Left  { get; set; }
        public ExpNode Right { get; set; }
        public OperationType Type { get; set; }
        public double Evaluate()
        {
           if(this.IsDigit)
            {
                return Value;
            }
           else
            {
                switch(Type)
                {
                    case OperationType.PLUS:
                        if(Left is null)
                        {
                            return this.Right.Evaluate();
                        }
                        else if(Right is null)
                        {
                            return this.Left.Evaluate();
                        }
                        return this.Left.Evaluate() + this.Right.Evaluate();
                    case OperationType.MINUS:
                        if (Left is null)
                        {
                            return this.Right.Evaluate()*(-1);
                        }
                        else if (Right is null)
                        {
                            return this.Left.Evaluate();
                        }
                        return this.Left.Evaluate() - this.Right.Evaluate();
                    case OperationType.TIMES:
                        if (Right is null)
                        {
                            return this.Left.Evaluate();
                        }
                        return this.Left.Evaluate() * this.Right.Evaluate();
                    case OperationType.DIVIDE:
                        if (Right is null)
                        {
                            return this.Left.Evaluate();
                        }
                        return this.Left.Evaluate() / this.Right.Evaluate();
                    default:
                        return 0;
                }
            }
        }

        public static bool ParenthesisIsValid(string s)
        {
            Stack<char> stack = new Stack<char> ();
            foreach(char c in s)
            {
                if(c == ')')
                {
                    if(stack.Count < 1) { return false; }
                    stack.Pop();
                }
                if(c == '(')
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
        }
        public bool ParseExpression()
        {
            List<char> chars = expression.ToList();
            while(chars.Contains('('))
            {
                int size = chars.Count;
                Stack<int> stack = new Stack<int>();
                for(int i=0; i < size; i++)
                {
                    if (chars[i] == '(')
                    {
                        stack.Push(i);
                    }

                    if (chars[i] == ')')
                    {
                        int start = stack.Pop();

                    }

                }
            }

            (string left, string right) = GetSubExpressions(expression, out OperationType type);
            if(left.Length > 0 || right.Length > 0)
            {
                Type = type;
                Left = left.Length > 0 ? new ExpNode() { expression = left } : null;
                Right = right.Length > 0 ? new ExpNode() { expression = right } : null;
                if(Left is null && Right is null) { return false; }
                if((type == OperationType.TIMES || type == OperationType.DIVIDE) &&(Left is null)) { return false; }
                return ((Left is null || (Left is not null && Left.ParseExpression())) && (Right is null || (Right is not null && Right.ParseExpression())));
            }

            if(Double.TryParse(expression, out double value))
            {
                Value = value;
                IsDigit = true;
                return true;
            }

            return false;
        }

        private (string left, string right) GetSubExpressions(string exp, out OperationType type)
        {
            if(!exp.Contains('('))
            {
                int index = exp.IndexOf('+');
                if(index >= 0)
                {
                    string leftString = exp.Substring(0, index);
                    string rightString = exp.Substring(index + 1);
                    type = OperationType.PLUS;
                    return (leftString, rightString);
                }

                index = exp.LastIndexOf('-');
                if(index >= 0)
                {
                    string leftString = exp.Substring(0,index);
                    string rightString = exp.Substring(index + 1);
                    type = OperationType.MINUS;
                    return (leftString, rightString);
                }
                index = exp.IndexOf('*');
                if(index >=0)
                {
                    string leftString = exp.Substring(0,index);
                    string rightString = exp.Substring(index+1);
                    type=OperationType.TIMES;
                    return (leftString, rightString);
                }
                index = exp.IndexOf('/');
                if(index >= 0)
                {
                    string leftString = exp.Substring(0,index);
                    string rightString = exp.Substring(index + 1);
                    type = OperationType.DIVIDE;
                    return (leftString, rightString);
                }
                type = OperationType.UNDEFINED;
                return ("", "");
            }

            List<string> exps = new List<string>();
            int size = exp.Length;
            Stack<int> stack = new Stack<int>();
            for(int i=0; i<size; i++)
            {
                if (exp[i] == '(')
                {
                    stack.Push(i);
                }
                if(exp[i] == ')')
                {
                    stack.Pop();
                }


            }

            if(exp.Contains('+'))
            {

            }

            int plIndex = exp.IndexOf('(');
            int prIndex = exp.LastIndexOf(')');
            if(plIndex < 0 && prIndex < 0 )
            {
                
            }
            else
            {

            }

            type = OperationType.PLUS;
            return ("","");
        }
    }

    public class Calculator
    {
        public double Evaluate(string expression)
        {
            if(TryParseExpression(expression, out ExpNode root))
            {
                return root.Evaluate();
            }
            else
            {
                return Double.NaN;
            }

        }

        private bool IsNumberOrDecimalPoint(char c)
        {
            char[] Digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
            return Digits.Contains(c);
        }

        private bool IsOperatorOrParenthesis(char c)
        {
            char[] NonDigits = new char[] { '+', '-', '*', '/', ')', '(' };
            return NonDigits.Contains(c);
        }

        private bool CheckAndCleanExpression(string exp, out string cleanExpression)
        {
            cleanExpression = Regex.Replace(exp, @"\s+", "");
            if (cleanExpression.Length < 1)
            {
                return false;
            }            

            foreach (char c in cleanExpression)
            {
                if (!IsNumberOrDecimalPoint(c) && !IsOperatorOrParenthesis(c))
                {
                    return false;
                }
            }
            int plIndex = cleanExpression.IndexOf('(');
            int prIndex = cleanExpression.LastIndexOf(')');
            if ((plIndex < 0 && prIndex >= 0) || (plIndex >= 0 && prIndex < 0))
            {
                return false;
            }
            while (plIndex == 0 && prIndex == cleanExpression.Length - 1)
            {
                if (!ExpNode.ParenthesisIsValid(cleanExpression.Substring(1, cleanExpression.Length - 2))) { break; }
                cleanExpression = cleanExpression.Substring(1, cleanExpression.Length - 2);
                plIndex = cleanExpression.IndexOf('(');
                prIndex = cleanExpression.LastIndexOf(')');
            }

            if ((plIndex < 0 && prIndex >= 0) || (plIndex >= 0 && prIndex < 0))
            {
                return false;
            }
            if (cleanExpression.Length < 1)
            {
                return false;
            }
            return true;
        }

        private bool TryParseExpression(string expression, out ExpNode root)
        {
            if(!CheckAndCleanExpression(expression, out string cleanedExpression))
            {
                root = null;
                return false;
            }

            root = new ExpNode();
            root.expression = cleanedExpression;
            if(root.ParseExpression())
            {
                return true;
            }
            return false;
        }
    }
}

