using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VutLogin_BranLove_Converter
{
    public static class BrainLoveCodeGenerator
    {
        public static char GetRegisterWithNearestValue(int b, char ch, int c, int d)
        {
            int ValueOfRegisterWithNearestValue = 255;
            char RegisterWithNearestValue = 'X';

            if (Math.Abs(b - ch) < ValueOfRegisterWithNearestValue)
            {
                ValueOfRegisterWithNearestValue = Math.Abs(b - ch);
                RegisterWithNearestValue = 'b';
            }
            if (Math.Abs(c - ch) < ValueOfRegisterWithNearestValue)
            {
                ValueOfRegisterWithNearestValue = Math.Abs(c - ch);
                RegisterWithNearestValue = 'c';
            }
            if (Math.Abs(d - ch) < ValueOfRegisterWithNearestValue)
            {
                ValueOfRegisterWithNearestValue = Math.Abs(d - ch);
                RegisterWithNearestValue = 'd';
            }
            return RegisterWithNearestValue;
        }

        public static void ChangeRegister(char current, char wanted, StringBuilder sb)
        {
            ChangeRegister(wanted - current, sb);
        }

        public static int ChangeRegisterValueToChar(char c, int currentRegisterValue, StringBuilder sb)
        {
            var change = c - currentRegisterValue;
            ChangeRegisterValue(change, sb);
            return c;
        }

        public static void ChangeRegister(int by, StringBuilder sb)
        {
            while (by != 0)
            {
                if (by < 0)
                {
                    sb.Append('<');
                    by++;
                }
                else
                {
                    sb.Append('>');
                    by--;
                }
            }
        }

        public static void ChangeRegisterValue(int by, StringBuilder sb)
        {
            while (by != 0)
            {
                if (by < 0)
                {
                    sb.Append('-');
                    by++;
                }
                else
                {
                    sb.Append('+');
                    by--;
                }
            }
        }

        public static void PrintChar(StringBuilder sb)
        {
            sb.Append('.');
        }

        public static void StartWhile(StringBuilder sb)
        {
            sb.Append('[');
        }

        public static void EndWhile(StringBuilder sb)
        {
            sb.Append(']');
        }
    }
}
