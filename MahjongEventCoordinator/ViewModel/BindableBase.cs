// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using System;
using System.ComponentModel;

namespace MahjongEventCoordinator.ViewModel
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Assign<T>(string propertyName, out T storage, T existing, T value) where T : IComparable
        {
            if ((value == null) || (value.CompareTo(existing) != 0))
            {
                storage = value;
                Notify(propertyName);
            }
            else
            {
                storage = value;
            }
        }

        public void Notify(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        public void Notify(string p1, string p2, string p3 = null, string p4 = null, string p5 = null, string p6 = null)
        {
            Notify(p1);
            Notify(p2);
            if (p3 != null) { Notify(p3); }
            if (p4 != null) { Notify(p4); }
            if (p5 != null) { Notify(p5); }
            if (p6 != null) { Notify(p6); }
        }
    }
}