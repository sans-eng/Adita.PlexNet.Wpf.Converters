using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adita.PlexNet.Wpf.Converters.Samples
{
    [ObservableObject]
    public partial class MainViewModel
    {
        [ObservableProperty]
        private double _value = 20;
    }
}
