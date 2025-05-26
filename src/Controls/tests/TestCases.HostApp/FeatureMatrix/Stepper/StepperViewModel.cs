// using System;
// using System.ComponentModel;
// using System.Diagnostics;
// using System.Globalization;
// using System.Runtime.CompilerServices;
// using System.Windows.Input;
// using Microsoft.Maui.Controls;

// namespace Maui.Controls.Sample;

// public class StepperViewModel : INotifyPropertyChanged
// {
//     private double _minimum = 0;
//     private double _maximum = 100;
//     private double _increment = 1;
//     private double _value = 5;
//     private bool _isEnabled = true;
//     private Color _backgroundColor = Colors.Transparent;
//     private FlowDirection _flowDirection = FlowDirection.LeftToRight;
//     private bool _isVisible = true;

//     public double Minimum
//     {
//         get => _minimum;
//         set
//         {
//             if (_minimum != value)
//             {
//                 _minimum = value;
//                 OnPropertyChanged();

//             }
//         }
//     }

//     public double Maximum
//     {
//         get => _maximum;
//         set
//         {
//             if (_maximum != value)
//             {
//                 _maximum = value;
//                 OnPropertyChanged();
//             }
//         }
//     }

//     public double Increment
//     {
//         get => _increment;
//         set
//         {
//             if (_increment != value)
//             {
//                 _increment = value;
//                 OnPropertyChanged();
//             }
//         }
//     }

//     public double Value
//     {
//         get => _value;
//         set
//         {
//             if (_value != value)
//             {
//                 _value = value;
//                 OnPropertyChanged();
//             }
//         }
//     }

//     public bool IsEnabled
//     {
//         get => _isEnabled;
//         set
//         {
//             if (_isEnabled != value)
//             {
//                 _isEnabled = value;
//                 OnPropertyChanged();
//             }
//         }
//     }

//     public Color BackgroundColor
//     {
//         get => _backgroundColor;
//         set
//         {
//             if (_backgroundColor != value)
//             {
//                 _backgroundColor = value;
//                 OnPropertyChanged();
//             }
//         }
//     }

//     public FlowDirection FlowDirection
//     {
//         get => _flowDirection;
//         set
//         {
//             if (_flowDirection != value)
//             {
//                 _flowDirection = value;
//                 OnPropertyChanged();
//             }
//         }
//     }

//     public bool IsVisible
//     {
//         get => _isVisible;
//         set
//         {
//             if (_isVisible != value)
//             {
//                 _isVisible = value;
//                 OnPropertyChanged();
//             }
//         }
//     }

// //     public ICommand ApplyIncrementCommand { get; }
// //     public ICommand SetLtrFlowDirectionCommand { get; }
// //     public ICommand SetRtlFlowDirectionCommand { get; }

// //  public StepperViewModel()
// //         {
// //             ApplyIncrementCommand = new Command(ApplyIncrement);
// //             SetLtrFlowDirectionCommand = new Command(() => FlowDirection = FlowDirection.LeftToRight);
// //             SetRtlFlowDirectionCommand = new Command(() => FlowDirection = FlowDirection.RightToLeft);
// //         }

// //         private string _incrementText;

// //         public string IncrementText
// //         {
// //             get => _incrementText;
// //             set
// //             {
// //                 if (_incrementText != value)
// //                 {
// //                     _incrementText = value;
// //                     OnPropertyChanged();
// //                 }
// //             }
// //         }

// //         private void ApplyIncrement()
// //         {
// //             if (double.TryParse(IncrementText, NumberStyles.Any, CultureInfo.InvariantCulture, out double incrementValue) &&
// //                 incrementValue > 0)
// //             {
// //                 Increment = incrementValue;
// //                 Application.Current.MainPage.DisplayAlert("Success", $"Increment value changed to {incrementValue}", "OK");
// //             }
// //         }

//     public event PropertyChangedEventHandler PropertyChanged;

//     protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
//     {
//         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//     }

// }


using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui.Controls.Sample
{
    public class StepperViewModel : INotifyPropertyChanged
    {
        private double _minimum = 0;
        private double _maximum = 10;
        private double _increment = 1;
        private double _value = 0;
        private bool _isEnabled = true;
        private bool _isVisible = true;
        private Color _backgroundColor = Colors.Transparent;
        private FlowDirection _flowDirection = FlowDirection.LeftToRight;

        public double Minimum
        {
            get => _minimum;
            set => SetProperty(ref _minimum, value);
        }

        public double Maximum
        {
            get => _maximum;
            set => SetProperty(ref _maximum, value);
        }

        public double Increment
        {
            get => _increment;
            set => SetProperty(ref _increment, value);
        }

        public double Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        public Color BackgroundColor
        {
            get => _backgroundColor;
            set => SetProperty(ref _backgroundColor, value);
        }

        public FlowDirection FlowDirection
        {
            get => _flowDirection;
            set => SetProperty(ref _flowDirection, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}