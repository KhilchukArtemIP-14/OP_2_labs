using System;
using System.Linq;

namespace OPLaba6
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "9+(8*(7+(6*(5+4)-(3-2))+1))";
            Node tree = GetMyTree(source);
            Console.WriteLine("Your tree: ");
            Node.printOutSubtree(tree);
            Console.WriteLine("Infix traversal: {0}\n",tree.InfixObhid());
            Console.WriteLine("Prefix traversal: {0}\n",tree.PrefixObhid());
            Console.WriteLine("Postfix traversal: {0}\n",tree.PostfixObhid());
        }
        public static void LeftSet(Node parent, Node descendant)
        {
            parent.left = descendant;
            descendant.parent = parent;
        }
        public static void RightSet(Node parent, Node descendant)
        {
            parent.right = descendant;
            descendant.parent = parent;
        }
        public static int AnalyzeExpression(string expression)
        {
            char[] operators = new char[] { '+', '-', '*' };
            int[] kilkistDuzhokNaChar = new int[expression.Length];
            int duzhkaCounter = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    duzhkaCounter++;
                    kilkistDuzhokNaChar[i] = 2147483646;
                    continue;
                }
                if (expression[i] == ')')
                {
                    duzhkaCounter--;
                    kilkistDuzhokNaChar[i] = 2147483646;
                    continue;
                }
                kilkistDuzhokNaChar[i] = duzhkaCounter;
            }
            int temp = kilkistDuzhokNaChar[0];
            int tempIndex = 0;
            for (int i = 0; i < kilkistDuzhokNaChar.Length; i++)
            {
                if((temp>= kilkistDuzhokNaChar[i])&&(operators.Contains(expression[i])))
                {
                    temp = kilkistDuzhokNaChar[i];
                    tempIndex = i;
                }
            }
            return tempIndex;
        }
        public static Node GetMyTree(string source, Node parent= null, Action<Node, Node> setter=null)
        {
            char[] operators = new char[] { '+', '-', '*' };
            string zliva, sprava;
            int index;
            Node temp = null;
            if (parent == null)
            {
                index = AnalyzeExpression(source);
                temp = new Node(source[index]);
                zliva = source.Substring(0, index);
                sprava = source.Substring(index+1);
                GetMyTree(zliva, temp, LeftSet);
                GetMyTree(sprava, temp, RightSet);
            }
            if (source.Trim('(', ')', '-', '+', '*').Length == 1)
            {
                setter(parent, new Node(source.Trim('(', ')', '-', '+', '*')[0]));
                return null;
            }
            if (source.Trim('(', ')', '-', '+', '*').Length == 0)
            {
                return null;
            }
            index = AnalyzeExpression(source);
            temp = new Node(source[index]);
            zliva = source.Substring(0, index);
            sprava = source.Substring(index+1);
            GetMyTree(zliva, temp, LeftSet);
            GetMyTree(sprava, temp, RightSet);
            if(setter!=null) setter(parent, temp);
            return temp;
        }
        public static void PrintOutMyTree()
        {
            Console.WriteLine("  +");
            Console.WriteLine(" / \\");
            Console.WriteLine("9   *");
            Console.WriteLine("   / \\");
            Console.WriteLine("  8   +");
            Console.WriteLine("     / \\");
            Console.WriteLine("    +   1");
            Console.WriteLine("   / \\");
            Console.WriteLine("  7  __-__");
            Console.WriteLine("    /     \\");
            Console.WriteLine("   *       -");
            Console.WriteLine("  / \\     / \\");
            Console.WriteLine(" 6   +   3   2");
            Console.WriteLine("    / \\");
            Console.WriteLine("   5  4");
            Console.WriteLine("\n\n");
        }
    }
}
