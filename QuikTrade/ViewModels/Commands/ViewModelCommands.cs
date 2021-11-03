using QuikTrade;
using System.Windows.Input;

namespace QuikTrade.ViewModels.Commands
{
   /// <summary>
   /// Команды модели представления.
   /// </summary>
   /// <version>1.0.7898.* : 1.0.7871.*</version>
   public partial class ViewModelCommands 
   {
      #region Properties

      /// <summary>
      /// Тестовая команда.
      /// </summary>
      public static RoutedUICommand TestCommand { get; }

      /// <summary>
      /// Команда отображения журнала.
      /// </summary>
      public static RoutedUICommand LogShowCommand { get; }

      /// <summary>
      /// Команда открытия тестовой вкладки.
      /// </summary>
      public static RoutedUICommand CreateTabSampleCommand { get; }

      /// <summary>
      /// Команда закрытия всех вкладок.
      /// </summary>
      public static RoutedUICommand CloseAllTabsCommand { get; }

      /// <summary>
      /// Команда закрытия вкладки.
      /// </summary>
      public static RoutedUICommand CloseTabCommand { get; }

      /// <summary>
      /// Команда закрывает другие вкладки подобного типа.
      /// </summary>
      public static RoutedUICommand CloseOtherSameTabsCommand { get; }

      /// <summary>
      /// Команда закрывает другие вкладки.
      /// </summary>
      public static RoutedUICommand CloseOtherTabsCommand { get; }

      /// <summary>
      /// Команда закрывает все подобные вкладки.
      /// </summary>
      public static RoutedUICommand CloseAllSameTabsCommand { get; }

      #endregion Properties

      #region Constructors

      /// <summary>
      /// Статический конструктор.
      /// </summary>
      static ViewModelCommands()
      {
         System.Type ownerType = typeof(ViewModelCommands);
         TestCommand = new RoutedUICommand("Run Test", "RunTest", ownerType);
         LogShowCommand = new RoutedUICommand("Log Show", "LogShow", ownerType);
         CreateTabSampleCommand = new RoutedUICommand("Create Tab Sample", "CreateTabSample", ownerType);
         CloseAllTabsCommand = new RoutedUICommand("Close All Tabs", "CloseAllTabs", ownerType);
         CloseTabCommand = new RoutedUICommand("Close Tab", "CloseTab", ownerType);
         CloseOtherSameTabsCommand = new RoutedUICommand("Close Other Same Tabs", "CloseOtherSameTabs", ownerType);
         CloseAllSameTabsCommand = new RoutedUICommand("Close All Same Tabs", "CloseAllSameTabs", ownerType);
         CloseOtherTabsCommand = new RoutedUICommand("Close Other Tabs", "CloseOtherTabs", ownerType);
      }

      #endregion Constructors
   }
}
