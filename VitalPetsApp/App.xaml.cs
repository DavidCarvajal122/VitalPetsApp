﻿using VitalPetsApp.Views;

namespace VitalPetsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());

        }
    }
}
