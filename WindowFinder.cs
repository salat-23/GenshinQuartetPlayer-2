﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GenshinQuartetPlayer2
{
    public class WindowFinder
    {
        public static IntPtr GenshinImpactWindow = FindWindow(null, "Genshin Impact");
        const int SW_MINIMIZE = 6;
        public static void Find()
        {
            Process[] hWndGenshinImpact = GetProcesses();
            foreach (Process proc in hWndGenshinImpact)
            {
                ShowWindow(proc.MainWindowHandle, 1);
                SetForegroundWindow(proc.MainWindowHandle);
            }
            Thread.Sleep(250);
        }

        protected static Process[] GetProcesses()
        {
            Process[] genshinImpact = Process.GetProcessesByName("GenshinImpact");
            foreach (var proc in genshinImpact) if (proc != null) Console.WriteLine(genshinImpact);
            return genshinImpact;
        }

        public static bool WindowStatus()
        {
            IntPtr thisWindow = GetForegroundWindow();
            return GenshinImpactWindow == thisWindow;
        }

        public static void MinimizeWindow()
        {
            ShowWindow(GenshinImpactWindow, SW_MINIMIZE);
        }

        public static void Test()
        {
            Process[] genshinImpact = Process.GetProcessesByName("GenshinImpact");
            Process h = genshinImpact.FirstOrDefault();
            Console.WriteLine(genshinImpact.Length);
            foreach (var proc in genshinImpact) Console.WriteLine(proc.MainWindowHandle);
            if (WindowStatus() != true) Console.WriteLine("Window Iconic");
            else Console.WriteLine("Window Active");
        }

        [DllImport("User32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int showWindowCommand);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

    }
}
