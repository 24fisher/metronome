﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;


namespace Metron
{

    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();



            /// <summary>
            /// Here we choose timer class to use:
            /// 
            /// ConcreteTimerWin32
            /// ConcreteXamarinTimer
            /// ConcreteTimerCLR
            /// </summary>

            var implementorTimer = new ConcreteTimerWin32();
            DataContext = new MetronomeViewModel(implementorTimer);

            
            //Setting window position
            Left = MetronWPF.Properties.Settings.Default.WindowPosition.Left;
            Top = MetronWPF.Properties.Settings.Default.WindowPosition.Top;
        }

        #region Events
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((MetronomeViewModel)DataContext)?.TempoSliderMoved();
        }

        private void Button_Click_Stop(object sender, RoutedEventArgs e)
        {
            
            ((MetronomeViewModel)DataContext).Stop();
        }

        private void Button_Click_Pattern(object sender, RoutedEventArgs e)
        {
            ((MetronomeViewModel)DataContext).ChangePattern();
        }

        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {

            ((MetronomeViewModel)DataContext).Run();

            
        }
        #endregion

        #region Textbox input filter
        private void TextBox_Pattern_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            


            if (!Int32.TryParse(e.Text, out int value))
            {
                e.Handled = true;
            }
            else
            {
                if(!(e.Text.Equals("0") || e.Text.Equals("1")))
                {
                    e.Handled = true;
                }
            }
        }

        private void TextBox_Pattern_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            MetronWPF.Properties.Settings.Default.WindowPosition = this.RestoreBounds;
            MetronWPF.Properties.Settings.Default.Save();
        }
        #endregion


    }
}
