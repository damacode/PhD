using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    class Program
    {
        private String Name;
        private List<String> Args;
        private String WorkingDirectory;
        private Process P;
        public Program(String name, List<String> args)
        {
            this.Name = name;
            this.Args = args;
            this.WorkingDirectory = ".";
        }
        public Program(String name, List<String> args, String workingDirectory)
        {
            this.Name = name;
            this.Args = args;
            this.WorkingDirectory = workingDirectory;
        }
        ~Program()
        {
            if (!P.HasExited)
            {
                P.Kill();
            }
        }
        public Boolean Start()
        {
            try
            {
                ProcessStartInfo pStartInfo = new ProcessStartInfo(this.Name, String.Join(" ", this.Args));
                pStartInfo.UseShellExecute = false;
                pStartInfo.WorkingDirectory = this.WorkingDirectory;
                pStartInfo.RedirectStandardError = true;
                pStartInfo.RedirectStandardInput = true;
                pStartInfo.RedirectStandardOutput = true;
                P = System.Diagnostics.Process.Start(pStartInfo);
                return true;
            }
            catch (Win32Exception w32e)
            {
                Console.WriteLine("Win32Exception starting " + this.Name + " with arguments " + String.Join(" ", this.Args) + " in directory " + this.WorkingDirectory + " .");
                Console.WriteLine(w32e.Message);
                return false;
            }
        }

        public Boolean Kill()
        {
            try
            {
                if (!P.HasExited) { 
                   P.Kill();
            }
                return true;
            }
            catch (Win32Exception w32e)
            {
                Console.WriteLine("Win32Exception killing " + this.Name + " with arguments " + String.Join(" ", this.Args) + " in directory " + this.WorkingDirectory + " .");
                Console.WriteLine(w32e.Message);
                return false;
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Id :" + P.Id);
            Console.WriteLine("ProcessName :" + P.ProcessName);
            Console.WriteLine("Arguments :" + P.StartInfo.Arguments);
            Console.WriteLine("WorkingDirectory :" + P.StartInfo.WorkingDirectory);
            Console.WriteLine("StartInfo :" + P.StartInfo);
            Console.WriteLine("StartTime :" + P.StartTime);
            Console.WriteLine("Responding :" + P.Responding);
            Console.WriteLine("HasExited :" + P.HasExited);
            if (P.HasExited) { 
                Console.WriteLine("ExitTime :" + P.ExitTime);
                Console.WriteLine("ExitCode :" + P.ExitCode);
            }
            Console.WriteLine("TotalProcessorTime :" + P.TotalProcessorTime);
            Console.WriteLine("UserProcessorTime :" + P.UserProcessorTime);
            Console.WriteLine("PrivilegedProcessorTime :" + P.PrivilegedProcessorTime);
            Console.WriteLine("Handle :" + P.Handle);
            Console.WriteLine("HandleCount :" + P.HandleCount);
            Console.WriteLine("MinWorkingSet :" + P.MinWorkingSet);
            Console.WriteLine("MaxWorkingSet :" + P.MaxWorkingSet);
            Console.WriteLine("WorkingSet64 :" + P.WorkingSet64);
            Console.WriteLine("PeakWorkingSet64 :" + P.PeakWorkingSet64);
            Console.WriteLine("NonpagedSystemMemorySize64 :" + P.NonpagedSystemMemorySize64);
            Console.WriteLine("PagedSystemMemorySize64 :" + P.PagedSystemMemorySize64);
            Console.WriteLine("PagedMemorySize64 :" + P.PagedMemorySize64);
            Console.WriteLine("PeakPagedMemorySize64 :" + P.PeakPagedMemorySize64);
            Console.WriteLine("PrivateMemorySize64 :" + P.PrivateMemorySize64);
            Console.WriteLine("VirtualMemorySize64 :" + P.VirtualMemorySize64);
            Console.WriteLine("PeakVirtualMemorySize64 :" + P.PeakVirtualMemorySize64);            
            //Console.WriteLine("BasePriority :" + P.BasePriority);
            //Console.WriteLine("CanRaiseEvents :" + P.CanRaiseEvents);
            //Console.WriteLine("Container :" + P.Container);
            //Console.WriteLine("DesignMode :" + P.DesignMode);
            //Console.WriteLine("EnableRaisingEvents :" + P.EnableRaisingEvents);
            //Console.WriteLine("Events :" + P.Events);
            //Console.WriteLine("MachineName :" + P.MachineName);
            //Console.WriteLine("MainModule :" + P.MainModule);
            //Console.WriteLine("MainWindowHandle :" + P.MainWindowHandle);
            //Console.WriteLine("MainWindowTitle :" + P.MainWindowTitle);
            //Console.WriteLine("Modules :" + P.Modules);
            //Console.WriteLine("PriorityBoostEnabled :" + P.PriorityBoostEnabled);
            //Console.WriteLine("PriorityClass :" + P.PriorityClass);
            //Console.WriteLine("ProcessName :" + P.ProcessName);
            //Console.WriteLine("ProcessorAffinity :" + P.ProcessorAffinity);
            //Console.WriteLine("SessionId :" + P.SessionId);
            //Console.WriteLine("Site :" + P.Site);
            //Console.WriteLine("StandardError :" + P.StandardError);
            //Console.WriteLine("StandardInput :" + P.StandardInput);
            //Console.WriteLine("StandardOutput :" + P.StandardOutput);
            //Console.WriteLine("SynchronizingObject :" + P.SynchronizingObject);
            //Console.WriteLine("Threads :" + P.Threads);
        }
    }
}
