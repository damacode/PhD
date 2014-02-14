using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    class ProgramManager
    {
        private List<Program> Progs;
        public ProgramManager()
        {
            Progs = new List<Program>();
        }
        public void AddProcess(String name, List<String> args)
        {
            Progs.Add(new Program(name, args));
        }
        static void Main(string[] args)
        {
            Program prog = new Program("mspaint.exe", new List<String>());
            prog.Start();
            prog.PrintInfo();
            Console.ReadKey();
            prog.Kill();
            prog.PrintInfo();
            Console.ReadKey();
        }
    }


}
