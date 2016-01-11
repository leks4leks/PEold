using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.BaseVM
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler pceh = PropertyChanged;
            if (pceh != null)
            {
                pceh(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual bool SetValue<T>(ref T target, T value, string propertyName)
        {
            return SetValue(ref target, value, propertyName, true);
        }

        protected virtual bool SetValue<T>(ref T target, T value, string propertyName, bool isEqualsCheck)
        {
            if (Object.Equals(target, value)) return false;
            target = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
