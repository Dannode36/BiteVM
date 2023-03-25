using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiteVM
{
    internal class VM
    {
        readonly Stack<int> stack = new(1024);
        int reg0 = 0;
        int reg1 = 0;

        public int Run(byte[] instructions)
        {
            for (int i = 0; i < instructions.Length; i++)
            {
                switch ((Instruction)instructions[i])
                {
                    case Instruction.INT:
                        stack.Push(instructions[++i]);
                        break;
                    case Instruction.ADD:
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case Instruction.SUB:
                        stack.Push(stack.Pop() - stack.Pop());
                        break;
                    case Instruction.MUl:
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case Instruction.DIV:
                        stack.Push(stack.Pop() / stack.Pop());
                        break;
                    case Instruction.MOD:
                        stack.Push(stack.Pop() % stack.Pop());
                        break;
                    case Instruction.SWP:
                        reg0 = stack.Pop();
                        reg1 = stack.Pop();
                        stack.Push(reg0);
                        stack.Push(reg1);
                        break;
                    case Instruction.WRT:
                        Console.WriteLine(stack.Pop());
                        break;
                    /*case Instruction.RDL:
                        stack.Push(int.Parse(Console.ReadLine()));
                        break;*/
                    case Instruction.SLP:
                        Thread.Sleep(stack.Pop());
                        break;
                    case Instruction.SLPS:
                        Thread.Sleep(stack.Pop() * 1000);
                        break;
                    default:
                        break;
                }
            }
            return 1;
        }
    }
}
