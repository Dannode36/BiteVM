using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiteVM
{
    internal class Parser
    {
        public static Dictionary<string, int> gotoMap = new();

        public static byte[] Parse(string fileName)
        {
            //Split the string into individual instructions
            string[] instText = File.ReadAllText(fileName, Encoding.UTF8).Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            //Convert them from string to byte
            byte[] instSet = new byte[instText.Length];

            for (int i = 0; i < instSet.Length; i++)
            {
                if (instText[i].StartsWith('$'))
                {
                    gotoMap.Add(instText[i], i);
                    instSet[i] = (byte)Instruction.NOP;
                    continue;
                }
                instSet[i] = ParseInstruction(instText[i], i);
            }
            return instSet;
        }

        public static byte ParseInstruction(string value, int instNum)
        {
            //If its just a literal then return it as a byte else try parse it into an instruction
            //Maybe LITERAL should require a literal preceeding it
            if (int.TryParse(value, out int literal))
            {
                try
                {
                    checked
                    {
                        return (byte)literal;
                    }
                }
                catch
                {
                    Console.WriteLine("Instruction " + instNum + $": Value overflowed ({literal}).");
                    return (byte)literal;
                }
            }
            try
            {
                return (byte)(Instruction)Enum.Parse(typeof(Instruction), value, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Instruction " + instNum + ": " + e.Message);
                throw;
            }
        }
    }
}
