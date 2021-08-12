using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuikTrade.Utilities;
using QuikTrade.Models;


namespace QuikTrade.Commands
{
   /// <summary>
   /// Команды модели представления.
   /// </summary>
   /// <version>1.0.7871.* : none</version>
   public partial class ViewModelCommands
   {
      #region Properties

      /// <summary>
      /// Тестовая команда.
      /// </summary>
      public static RoutedUICommand TestCommand { get; }

      #endregion Properties

      #region Constructors

      /// <summary>
      /// Статический конструктор.
      /// </summary>
      static ViewModelCommands()
      {
         TestCommand = new RoutedUICommand("Run Test", "RunTest", typeof(ViewModelCommands));
      }

      #endregion Constructors
   }
}
