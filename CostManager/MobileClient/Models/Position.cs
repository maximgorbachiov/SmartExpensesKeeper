using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileClient.Models
{
    public class Position
    {
        public int Price { get; set; }
        public int Title { get; set; }
        public int Count { get; set; }
        public int Weight { get; set; }
        public int Capacity { get; set; }
    }
}