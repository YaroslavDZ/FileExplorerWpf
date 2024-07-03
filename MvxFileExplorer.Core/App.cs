﻿using MvvmCross.ViewModels;
using MvxFileExplorer.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            RegisterAppStart<MainViewModel>();
        }
    }
}
