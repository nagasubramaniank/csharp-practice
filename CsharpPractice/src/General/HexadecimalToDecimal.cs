// Convert a hexadecimal string (with maximum length of 8) to decimal value.

using System;

namespace General
{
    public static class HexadecimalToDecimal
    {
        public static void Main(string[] args)
        {
            PrintHexadecimalToDecimal("");
            PrintHexadecimalToDecimal("0");
            PrintHexadecimalToDecimal("CafeBabe");
            PrintHexadecimalToDecimal("FFFFFFFF");
        }

        private static void PrintHexadecimalToDecimal(string hexadecimalValue)
        {
            if (hexadecimalValue.Length > 8)
            {
                throw new ArgumentException($"Hexadecimal string [{hexadecimalValue}] is too long.");
            }

            uint decimalValue = 0;

            foreach (char hexDigit in hexadecimalValue.ToCharArray())
            {
                decimalValue = decimalValue * 16 + GetDecimalValue(hexDigit);
            }

            Console.WriteLine($"Hexadecimal Value: [{hexadecimalValue}], Decimal Value: [{decimalValue}].");
        }

        private static uint GetDecimalValue(char hexadecimalDigit)
        {
            if (hexadecimalDigit >= '0' && hexadecimalDigit <= '9')
            {
                return (uint)(hexadecimalDigit - '0');
            }
            else if (hexadecimalDigit >= 'A' && hexadecimalDigit <= 'Z')
            {
                return (uint)(hexadecimalDigit - 'A' + 10);
            }
            else if (hexadecimalDigit >= 'a' && hexadecimalDigit <= 'z')
            {
                return (uint)(hexadecimalDigit - 'a' + 10);
            }
            else
            {
                throw new ArgumentException($"Encountered invalid character [{hexadecimalDigit}].");
            }
        }
    }
}
