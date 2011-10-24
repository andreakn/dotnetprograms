using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace DbToolMac
{
    public partial class MainWindow : NSWindow
    {
        // Called when created from unmanaged code
        public MainWindow(IntPtr handle) : base (handle)
        {
            Initialize();
        }
		
        // Called when created directly from a XIB file
        [Export ("initWithCoder:")]
        public MainWindow(NSCoder coder) : base (coder)
        {
            Initialize();
        }
		
        void Initialize()
        {
        }
    }
}

