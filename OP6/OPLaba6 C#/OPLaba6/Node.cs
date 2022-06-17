using System;

namespace OPLaba6
{
    class Node
    {
        public char value;
        public Node left = null, right=null, parent= null;
        public Node( char symbol)
        {
            value = symbol;
        }
        public string InfixObhid()
        {
            if ((this.left == null) & (this.right == null))
                return this.value.ToString();

            string temp = String.Concat("(", this.left.InfixObhid(), this.value.ToString(), this.right.InfixObhid(), ")");

            if (this.parent == null) return temp.Substring(1, temp.Length - 2);
            if (((this.parent.value == '+') && (this.value == '+') || (this.value == '*'))) return temp.Substring(1, temp.Length - 2);
            return temp;
        }
        public string PrefixObhid()
        {
            if ((this.left == null) & (this.right == null))
                return this.value.ToString();

            string temp = String.Concat(this.value, this.left.PrefixObhid(), this.right.PrefixObhid());
            return temp;
        }
        public string PostfixObhid()
        {
            if ((this.left == null) & (this.right == null)) return this.value.ToString();
            string temp = String.Concat(this.left.PostfixObhid(), this.right.PostfixObhid(), this.value);
            return temp;
        }

        public static void printOutSubtree(Node root, int space=-2)
        {
            if (root == null)
                return;
            space +=4;
            printOutSubtree(root.left, space);
            Console.Write("\n");
            for (int i = 4; i < space; i++)
                Console.Write(" ");
            Console.Write(root.value + "\n");
            printOutSubtree(root.right, space);
        }
    }
}
