using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase
{
    interface ICanJump
    {
        public void Jump();
        public void JumpHigh()
        {
            Console.WriteLine("Jump high with ICanJump.");
        }
    }
}
