﻿using SharpDox.Sdk.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SharpDox.GUI.Controls.ConfigGrid
{
    public partial class ConfigComboBoxControl : UserControl
    {
        public static readonly DependencyProperty ConfigItemDisplayNameProperty = DependencyProperty.Register("ConfigItemDisplayName", typeof(string), typeof(ConfigComboBoxControl));
        public static readonly DependencyProperty ConfigItemValueProperty = DependencyProperty.Register("ConfigItemValue", typeof(string), typeof(ConfigComboBoxControl));
        public static readonly DependencyProperty WaterMarkTextProperty = DependencyProperty.Register("WaterMarkText", typeof(string), typeof(ConfigComboBoxControl));
        public static readonly DependencyProperty WaterMarkColorProperty = DependencyProperty.Register("WaterMarkColor", typeof(SolidColorBrush), typeof(ConfigComboBoxControl));

        public ConfigComboBoxControl()
        {
            DataContext = this;
            InitializeComponent();
        }

        public string ConfigItemDisplayName
        {
            get { return (string)GetValue(ConfigItemDisplayNameProperty); }
            set { SetValue(ConfigItemDisplayNameProperty, value); }
        }

        public string ConfigItemValue
        {
            get { return (string)GetValue(ConfigItemValueProperty); }
            set { SetValue(ConfigItemValueProperty, value); }
        }

        public string WaterMarkText
        {
            get { return (string)GetValue(WaterMarkTextProperty); }
            set { SetValue(WaterMarkTextProperty, value); }
        }

        public SolidColorBrush WaterMarkColor
        {
            get { return (SolidColorBrush)GetValue(WaterMarkColorProperty); }
            set { SetValue(WaterMarkColorProperty, value); }
        }
    }
}
