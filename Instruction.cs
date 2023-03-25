using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiteVM
{
    internal enum Instruction
    {
        NOP = 0x00, //Pushes an int onto the stack
        INT = 0x01, //Pushes an int onto the stack
        ADD = 0xA1, //Pops top 2 values from the stack and pushes their sum
        SUB = 0xA2, //Pops top 2 values from the stack and pushes their difference
        MUl = 0xA3, //Pops top 2 values from the stack and pushes their product
        DIV = 0xA4, //Pops top 2 values from the stack and pushes their quotient
        MOD = 0xA5, //Pops top 2 values from the stack and pushes their modulus
        SWP = 0x90, //Swaps the top 2 values on the stack
        WRT = 0xE0, //Pops the stack and writes it to the console
        RDL = 0xE1, //Pushes a readline into the stack
        SLP = 0xF0, //Sleeps for the popped amount of milliseconds
        SLPS = 0xF1, //Sleeps for the popped amount of seconds

        //Functions and Goto
        GOTO = 0xC0,
    };
}
