﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;


//Note ----- NOT USING IT  , but if problem on WPF Password wireup comes up again it might prove usefull
//Not happy about the solution since it makes input a clear text
//clear text... for a password.... and in wpf.... and it's not encrypted when stored or in app...
//MVVM must work really well so i'm reasonably sure that app is secure

// aaaa to hell with it
//used this
//https://stackoverflow.com/questions/30631522/caliburn-micro-support-for-passwordbox

public static class PasswordBoxHelper
{
    public static readonly DependencyProperty BoundPasswordProperty =
        DependencyProperty.RegisterAttached("BoundPassword",
            typeof(string),
            typeof(PasswordBoxHelper),
            new FrameworkPropertyMetadata(string.Empty, OnBoundPasswordChanged));

    public static string GetBoundPassword(DependencyObject d)
    {
        var box = d as PasswordBox;
        if (box != null)
        {
            // this funny little dance here ensures that we've hooked the
            // PasswordChanged event once, and only once.
            box.PasswordChanged -= PasswordChanged;
            box.PasswordChanged += PasswordChanged;
        }

        return (string)d.GetValue(BoundPasswordProperty);
    }

    public static void SetBoundPassword(DependencyObject d, string value)
    {
        if (string.Equals(value, GetBoundPassword(d)))
            return; // and this is how we prevent infinite recursion

        d.SetValue(BoundPasswordProperty, value);
    }

    private static void OnBoundPasswordChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var box = d as PasswordBox;

        if (box == null)
            return;

        box.Password = GetBoundPassword(d);
    }

    private static void PasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox password = sender as PasswordBox;

        SetBoundPassword(password, password.Password);

        // set cursor past the last character in the password box
        password.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(password, new object[] { password.Password.Length, 0 });

    }

}