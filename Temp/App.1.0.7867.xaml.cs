using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

/// <version>1.0.7867.* : none</version>
namespace QuikTrade
{
   /// Логика взаимодействия для App.xaml
   public partial class App : Application
   {
      #region Event Handlers

      /// Вызывается при возникновении события Run() объекта Application.
      private void App_OnStartup(object sender, StartupEventArgs e)
      {
         // Создаем файл для хранения значений свойств MainViewModel при первом запуске.
         // В противном случае метод MainViewModel.Initialize не выполняется.

         if (!SerializeExtention.IsFileExsist("MainViewModel"))
            SerializeExtention.CreateFile("MainViewModel");
      }

      /// Вызывается перед тем, как приложение завершает работу.
      private void App_OnExit(object sender, ExitEventArgs e)
      {
         // Сериализация свойств объектов.
         Store.Snapshot();
      }

      #endregion Event Handlers
   }

}
