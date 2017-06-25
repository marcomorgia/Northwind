﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Northwind.Model
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            VerifyPropertyName(propertyName);
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        [DebuggerStepThrough]
        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new InvalidOperationException();
        }
    }
}
