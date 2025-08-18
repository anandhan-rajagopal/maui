using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls.Xaml;

namespace Maui.Controls.Sample.Issues;

[Issue(IssueTracker.Github, 31139, "Binding updates from background thread should marshal to UI thread (Windows)", PlatformAffected.All)]
public class Issue31139 : ContentPage
{
    public Issue31139()
    {
        BindingContext = new Issue31139ViewModel();

        var label = new Label();
        label.SetBinding(Label.TextProperty, nameof(Issue31139ViewModel.Time));
        this.Content = label;
	}
}

public class Issue31139ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public Issue31139ViewModel()
    {
        Thread t = new Thread(() =>
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            while (true)
            {
                try
                {
                    Time = "Time elapsed: " + stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                Thread.Sleep(1000);
            }
        });

        t.IsBackground = true;
        t.Start();
    }

    private string _time = string.Empty;
    public string Time
    {
        get => _time;
        private set
        {
            if (_time != value)
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
    }
}