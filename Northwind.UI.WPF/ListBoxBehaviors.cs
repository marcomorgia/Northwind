﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Northwind.UI.WPF
{
    static class ListBoxBehaviors
    {


        public static void SetDoubleClickCommand(UIElement element, ICommand value)
        {
            element.SetValue(DoubleClickCommandProperty, value);
        }

        public static ICommand GetDoubleClickCommand(UIElement element)
        {
            return (ICommand)element.GetValue(DoubleClickCommandProperty);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DoubleClickCommandProperty =
            DependencyProperty.RegisterAttached("DoubleClickCommand", typeof(ICommand), typeof(ListBoxBehaviors), new PropertyMetadata(null, new PropertyChangedCallback(DoubleClickCommand_PropertyChanged)));

        private static void DoubleClickCommand_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement target = d as UIElement;

            if (e.OldValue != null)
            {
                target.RemoveHandler(ListBox.MouseDoubleClickEvent, new RoutedEventHandler(ListBox_DoubleClick));
            }
            if (e.NewValue != null)
            {
                target.AddHandler(ListBox.MouseDoubleClickEvent, new RoutedEventHandler(ListBox_DoubleClick));
            }
        }

        private static void ListBox_DoubleClick(object sender, RoutedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            ICommand doubleClickCommand = GetDoubleClickCommand(listBox);

            if (doubleClickCommand.CanExecute(e))
            {
                doubleClickCommand.Execute(e);
            }
        }
    }
}
