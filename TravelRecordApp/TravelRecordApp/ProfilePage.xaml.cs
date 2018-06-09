﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //var postTable = conn.Table<Post>().ToList();
            var postTable = await Post.Read();

            var categoriesCount = Post.PostCategories(postTable);

            categoryListView.ItemsSource = categoriesCount;

            postCountLabel.Text = postTable.Count.ToString();
            //}
        }
    }
}