namespace ExtMethodsDelegatesLambdaLINQHomework
{
    using System;
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder input, int index, int length)
        {
            if (index < 0 || index > input.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index + length>input.Length)
            {
                throw new IndexOutOfRangeException();
            }

            StringBuilder result = new StringBuilder();
            string inputAsString = input.ToString();
            for (int i = index; i < index + length; i++)
            {
                result.Append(inputAsString[i]);
            }

            return result;
        }
    }
}
