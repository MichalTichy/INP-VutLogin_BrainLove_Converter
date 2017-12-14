using System;
using System.Linq;
using System.Text;

namespace VutLogin_BrainLove_Converter
{
   public static class VutLoginTranslator
    {
        public static string Translate(string vutLogin)
        {
            int b, c, d;

            StringBuilder sb = new StringBuilder();
            BrainLoveCodeGenerator.ChangeRegisterValue(11, sb);

            BrainLoveCodeGenerator.StartWhile(sb);

            BrainLoveCodeGenerator.ChangeRegisterValue(-1, sb);

            BrainLoveCodeGenerator.ChangeRegister(+1, sb);
            b = 120;

            BrainLoveCodeGenerator.ChangeRegisterValue(8, sb); //set B to X

            BrainLoveCodeGenerator.ChangeRegister(+1, sb);

            var cChange = RoundOff(vutLogin[1]);
            c = cChange * 11;
            BrainLoveCodeGenerator.ChangeRegisterValue(cChange, sb);

            BrainLoveCodeGenerator.ChangeRegister(+1, sb);
            var dChange = RoundOff(vutLogin[2]);
            d = dChange * 11;
            BrainLoveCodeGenerator.ChangeRegisterValue(dChange, sb);

            BrainLoveCodeGenerator.ChangeRegister('d', 'a', sb);
            BrainLoveCodeGenerator.EndWhile(sb);

            //print X
            BrainLoveCodeGenerator.ChangeRegister(1, sb);
            BrainLoveCodeGenerator.PrintChar(sb);

            BrainLoveCodeGenerator.ChangeRegister(1, sb);
            c = BrainLoveCodeGenerator.ChangeRegisterValueToChar(vutLogin[1], c, sb);
            BrainLoveCodeGenerator.PrintChar(sb);

            BrainLoveCodeGenerator.ChangeRegister(1, sb);
            d = BrainLoveCodeGenerator.ChangeRegisterValueToChar(vutLogin[2], d, sb);
            BrainLoveCodeGenerator.PrintChar(sb);

            char currentRegister = 'd';
            foreach (char ch in vutLogin.Skip(3))
            {
                var registerWithNearestValue = BrainLoveCodeGenerator.GetRegisterWithNearestValue(b, ch, c, d);

                BrainLoveCodeGenerator.ChangeRegister(currentRegister, registerWithNearestValue, sb);
                currentRegister = registerWithNearestValue;
                switch (registerWithNearestValue)
                {
                    case 'b':
                        b = BrainLoveCodeGenerator.ChangeRegisterValueToChar(ch, b, sb);
                        break;
                    case 'c':
                        c = BrainLoveCodeGenerator.ChangeRegisterValueToChar(ch, c, sb);
                        break;
                    case 'd':
                        d = BrainLoveCodeGenerator.ChangeRegisterValueToChar(ch, d, sb);
                        break;
                }

                BrainLoveCodeGenerator.PrintChar(sb);
            }
            return sb.ToString();
        }

        private static int RoundOff(int i)
        {
            return ((int)Math.Round(i / 11.0));
        }
    }
}
