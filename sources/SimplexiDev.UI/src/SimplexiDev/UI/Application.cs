/***********************************************************************************************************************
 * FileName:            Application.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

using SimplexiDev.Native;
using SimplexiDev.Internal;
using SimplexiDev.Runtime.InteropServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace SimplexiDev.UI
{
    public sealed unsafe class Application : NativeComponent
    {
        private static readonly object _lock = new();
        private static readonly Queue<Action> queue = new();

        public Application() : base() { }

        public event EventHandler<CancelEventArgs> Exiting;

        public static Application Current { get; private set; }
        internal static Window MainWindow { get; private set; }

        public static int Run(Window window)
        {
            MainWindow = window;
            return Run(() => window.Show());
        }

        private static int Run(Action action)
        {
            try
            {
                QueueMain(action);
                Libui.uiMain();
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                return -1;
            }
            return 0;
        }

        public static void QueueMain(Action action)
        {
            queue.Enqueue(action);
            Libui.uiQueueMain(&OnQueueMainFunc, new IntPtr(queue.Count));
        }

        public static void Shutdown() => Libui.uiQuit();

        //TODO: private static void Steps() => Libui.uiMainSteps();
        //TODO: private static bool Step(bool wait) => Libui.uiMainStep(wait);

        [UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
        private static bool OnShouldQuitFunc(IntPtr data)
        {
            CancelEventArgs args = new();
            Current.Exiting?.Invoke(Current, args);
            return !args.Cancel;
        }

        [UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
        private static void OnQueueMainFunc(IntPtr data)
        {
            lock (_lock)
            {
                queue.Dequeue().Invoke();
            }
        }

        protected override void StartInitialization(params object[] args)
        {
            base.StartInitialization(args);
            lock (_lock)
            {
                Current = this;
                Libui.uiInitOptions options = new() { Size = UIntPtr.Zero };
                string errStr = Utf8Helper.GetUtf16String(Libui.uiInit(&options), false);

                if (!string.IsNullOrEmpty(errStr))
                {
                    Console.WriteLine(errStr);
                    throw new Exception(errStr);
                }
            }
        }

        protected override void EndInitialization()
        {
            Libui.uiOnShouldQuit(&OnShouldQuitFunc, IntPtr.Zero);
        }

        protected override void ReleaseUnmanagedResources()
        {
            Libui.uiUninit();
            base.ReleaseUnmanagedResources();
        }
    }
}