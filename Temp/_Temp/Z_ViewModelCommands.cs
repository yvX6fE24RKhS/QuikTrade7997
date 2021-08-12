using System.Windows.Input;
using QuikTrade.ViewModels;

namespace QuikTrade.Commands
{
   /// <summary>
   /// Команды модели представления.
   /// </summary>
   public class ViewModelCommands
   {
      #region Properties

      /// <summary>
      /// Тестовая комманда.
      /// </summary>
      public static RoutedUICommand TestCommand { get; }

      #endregion Properties

      #region Constructors

      /// <summary>
      /// 
      /// </summary>
      static ViewModelCommands()
      {
         TestCommand = new RoutedUICommand("Run Test", "RunTest", typeof(ViewModelCommands));
      }

      #endregion Constructors

      #region Methods



      #endregion Methods
   }
}
