using System.IO;

namespace QuikTrade.Utilities
{
   /// <summary>
   /// Каталог для журналов на диске.
   /// </summary>
   /// <version>1.0.7878.* : none</version>
   internal class LogPath
    {
      #region Properties

      /// <summary>
      /// Путь до каталога для журналов на диске.
      /// </summary>
      internal static string Name { get => $"{DebugExtension.GetAppPath()}\\Log\\"; }

      #endregion Properties

      #region Methods

      /// <summary>
      /// Проверяет наличие каталога для журналов на диске. 
      /// </summary>
      /// <returns>Возвращает <c>true</c> если каталог существует. В противном случае <c>false</c></returns>
      internal static bool Exists () => Directory.Exists(Name);

      /// <summary>
      /// Создает каталог для журналов на диске.
      /// </summary>
      internal static void Create()
      {
         Directory.CreateDirectory(Name);
      }

      #endregion Methods
   }
}
