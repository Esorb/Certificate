﻿using Esorb.Certificate.App.ViewModel;
using System;
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
using Esorb.Certificate.App.Model.Enumerables;

namespace Esorb.Certificate.App.View.Pages;

public partial class TeacherPage : Page
{
    public readonly TeachersViewModel Teachers;
    public TeacherPage(TeachersViewModel teachers)
    {
        InitializeComponent();
        Teachers = teachers;
        DataContext = Teachers;
    }
    private void TeachersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        CommandManager.InvalidateRequerySuggested();
    }
}
