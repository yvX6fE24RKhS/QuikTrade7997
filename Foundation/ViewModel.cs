//source:   https://habrahabr.ru/post/208326/
//author:   poemmuse
//release:  7 января 2014
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Windows.Input;

namespace Foundation
{
   [DataContract]
   public class ViewModel : ViewModelBase, IDataErrorInfo
   {
      public ViewModel()
      {
         Initialize();
      }

      string IDataErrorInfo.this[string propertyName]
      {
         get
         {
            return this.PropertyBindings.ContainsKey(propertyName)
                ? this.PropertyBindings[propertyName].InvokeValidation()
                : null;
         }
      }

      public PropertyBinding this[Expression<Func<object>> expression]
      {
         get
         {
            var propertyName = GetPropertyName(expression);
            if (!this.PropertyBindings.ContainsKey(propertyName))
               this.PropertyBindings.Add(propertyName, new PropertyBinding(propertyName));
            return this.PropertyBindings[propertyName];
         }
      }

      public CommandBinding this[ICommand command]
      {
         get
         {
            if (!this.CommandBindings.ContainsKey(command))
               this.CommandBindings.Add(command, new CommandBinding(command));
            return this.CommandBindings[command];
         }
      }

      public string Error { get; protected set; }
      public Dictionary<ICommand, CommandBinding> CommandBindings { get; private set; }
      public Dictionary<string, PropertyBinding> PropertyBindings { get; private set; }
      public CancelEventHandler OnClosing = (o, e) => { };

      public TProperty Get<TProperty>(Expression<Func<TProperty>> expression, TProperty defaultValue = default(TProperty))
      {
         var propertyName = GetPropertyName(expression);
         if (!Values.ContainsKey(propertyName))
            Values.Add(propertyName, defaultValue);
         return (TProperty)Values[propertyName];
      }

      public void Set<TProperty>(Expression<Func<TProperty>> expression, TProperty value)
      {
         var propertyName = GetPropertyName(expression);
         RaisePropertyChanging(propertyName);
         if (!Values.ContainsKey(propertyName))
            Values.Add(propertyName, value);
         else Values[propertyName] = value;
         RaisePropertyChanged(propertyName);
      }

      public void RaisePropertyChanging<TProperty>(Expression<Func<TProperty>> expression)
      {
         var propertyName = GetPropertyName(expression);
         RaisePropertyChanging(propertyName);
      }

      public void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> expression)
      {
         var propertyName = GetPropertyName(expression);
         RaisePropertyChanged(propertyName);
      }

      [OnDeserializing]
      private void Initialize(StreamingContext context = default(StreamingContext))
      {
         this.CommandBindings = new Dictionary<ICommand, CommandBinding>();
         this.PropertyBindings = new Dictionary<string, PropertyBinding>();
         PropertyChanging += OnPropertyChanging;
         PropertyChanged += OnPropertyChanged;
      }

      private void OnPropertyChanging(object sender, PropertyChangingEventArgs e)
      {
         var propertyName = e.PropertyName;
         if (!this.PropertyBindings.ContainsKey(propertyName)) return;
         var binding = this.PropertyBindings[propertyName];
         if (binding != null) binding.InvokePropertyChanging(sender, e);
      }

      private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
      {
         var propertyName = e.PropertyName;
         if (!this.PropertyBindings.ContainsKey(propertyName)) return;
         var binding = this.PropertyBindings[propertyName];
         if (binding != null) binding.InvokePropertyChanged(sender, e);
      }
   }
}