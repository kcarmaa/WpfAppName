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
using System.Windows.Shapes;
using WpfAppName.ViewModel;
using WpfAppName.View;
using WpfAppName.Model;
using System.Collections.ObjectModel;

namespace WpfAppName.View
{
    /// <summary>
    /// Логика взаимодействия для WindowRole.xaml
    /// </summary>
    public partial class WindowRole : Window
    {
        public WindowRole()
        {
            InitializeComponent();
            RoleViewModel vmRole = new RoleViewModel();
            lvRole.ItemsSource = vmRole.ListRole;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            RoleViewModel vmRole = new RoleViewModel();
            WindowNewRole wnRole = new WindowNewRole()
            {
                Title = "Новая должность",
                Owner = this
            };
            int maxIdRole = vmRole.MaxId() + 1;
            Role role = new Role()
            {
                Id = maxIdRole
            };
            wnRole.DataContext = role;
            if (wnRole.ShowDialog() == true)
            {
                vmRole.ListRole.Add(role);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            RoleViewModel vmRole = new RoleViewModel();
            WindowNewRole wnRole = new WindowNewRole()
            {
                Title = "Редактирование должности",
                Owner = this
            };
            Role role = lvRole.SelectedItem as Role;
            if (role != null)
            {
                Role tempRole = role;
                wnRole.DataContext = tempRole;
                if (wnRole.ShowDialog() == true)
                {
                    role.NameRole = tempRole.NameRole;
                    lvRole.ItemsSource = null;
                    lvRole.ItemsSource = vmRole.ListRole;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для редактированния", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
