using System;
using System.Diagnostics;

namespace QuikTrade.Utilities
{
   /// <summary>
   /// Методы применяемые при отладке.
   /// </summary>
   /// <version>1.0.7898.* : 1.0.7878.*</version>
   internal class DebugExtension
   {
      #region Methods

      /// <summary>
      /// Возвращает строковое представление версии сборки проекта.
      /// </summary>
      /// <returns></returns>
      internal static string GetAssemblyVersion()
      {
         return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
      }

      /// <summary>
      /// Возвращает имя свойства или метода вызывающего объект.
      /// </summary>
      /// <param name="obj">вызываемый объект.</param>
      /// <param name="memberName">имя свойства или метода вызывающего метод объекта.</param>
      /// <returns>Строка содержащая имя вызывающего объекта.</returns>
      internal static string GetCallerMemberName(object obj, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
      {
         return $"{obj.GetType()}.{memberName}";
      }

      /// <summary>
      /// Возвращает имя исполняемого файла приложения.
      /// </summary>
      /// <returns>Строка содержащая имя исполняемого файла приложения.</returns>
      internal static string GetAppName()
      {
         return AppDomain.CurrentDomain.FriendlyName;
      }

      /// <summary>
      /// Возвращает путь к исполняемому файлау приложения.
      /// </summary>
      /// <returns>Строка содержащая путь к исполняемому файлау приложения.</returns>
      internal static string GetAppPath()
      {
         return System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
      }

      /// <summary>
      /// Возвращает имя текщнго ползователя Windows.
      /// </summary>
      /// <returns></returns>
      internal static string GetUserName()
      {
         return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
      }
      
      #endregion Methods
   }
}
