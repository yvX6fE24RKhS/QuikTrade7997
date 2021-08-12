using System.Diagnostics;
using System.Windows;
using Foundation;
using QuikTrade.Models;
using QuikTrade.Utilities;

namespace QuikTrade
{
   /// <summary>
   /// Логика взаимодействия для App.xaml
   /// </summary>
   /// <version>1.0.7878.* : 1.0.7867.*</version>
   public partial class App : Application
   {
      #region Properties

      /// <summary>
      /// Журнал текущей сессии.
      /// </summary>
      internal static Log Log { get; set; }

      #endregion Properties

      #region Constructors

      /// <summary>
      /// Инициализирует новый экземпляр класса <see cref="App"/>.
      /// </summary>
      public App()
      {
         Log = new Log();

         this.Startup += (sender, args) => Log.Append(
            this, 
            new EventInfo(
               init: Initiator.user,
               evnt: "Startup",
               msg: $"Пользователь запустил приложение {DebugExtension.GetAppName()}."
            )
         );
         this.Exit += (sender, args) => App_OnExit(sender, args);
         this.Exit += (sender, args) => Log.Append(
            this, 
            new EventInfo(
               evnt: "Exit",
               msg: $"Работа приложения {DebugExtension.GetAppName()} завершилась с кодом {args.ApplicationExitCode}."
            )
         );

         this.Exit += (sender, args) => Log.WriteXML();
      }
      #endregion Constructors

      #region Event Handlers

      /// <summary>
      /// Вызывается при возникновении события Run() объекта Application.
      /// </summary>
      /// <param name="sender">Объект, создавший событие.</param>
      /// <param name="e">Данные события.</param>
      private void App_OnStartup(object sender, StartupEventArgs e)
      {
         // Создаем файл для хранения значений свойств MainViewModel при первом запуске.
         // В противном случае метод MainViewModel.Initialize не выполняется.
         if (!SerializeExtention.IsFileExsist("MainViewModel"))
            SerializeExtention.CreateFile("MainViewModel");

#if DEBUG
         Debug.WriteLine(message: $"Отладка: {DebugExtension.GetCallerMemberName(this)} executed.");
#endif
      }

      /// <summary>
      /// Вызывается перед тем, как приложение завершает работу.
      /// </summary>
      /// <param name="sender">Объект, создавший событие.</param>
      /// <param name="e">Данные события.</param>
      private void App_OnExit(object sender, ExitEventArgs e)
      {
#if DEBUG
         Debug.WriteLine(message: $"Отладка: {DebugExtension.GetCallerMemberName(this)} executing.");
#endif

         // Журналирование
         Log.Append(
            this, 
            new EventInfo(
               init: Initiator.app,
               evnt: "Exit",
               msg: "Началась сериализация свойств объектов приложения."
            )
         );

         // Сериализация свойств объектов.
         Store.Snapshot();

         // Журналирование
         Log.Append(
            this,
            new EventInfo(
               init: Initiator.app,
               evnt: "Exit",
               msg: "Сериализация свойств объектов приложения завершена."
            )
         );
      }

      #endregion Event Handlers
   }
}
