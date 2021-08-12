using System;
using System.IO;
using System.Text;
using Foundation;

namespace QuikTrade.Utilities
{
   /// <summary>
   /// Методы свзанные с сериализацией.
   /// </summary>
   /// <version>1.0.7867.* : none</version>
   internal class SerializeExtention
   {
      #region Methods

      /// <summary>
      /// Определяет существует ли json файл хранилище свойств вью-модели.
      /// </summary>
      /// <param name="name">Строка, содержащая имя json файла.</param>
      /// <returns>
      /// Возвращает <c>true</c> если json файл с именем указанном в параметре <c>name</c> существует. В противном случае <c>false</c>.
      /// </returns>
      /// <remarks>
      /// Если параметр <c>name</c> содержит <c>null</c>, пустую строку или строку состоящую из символов разделителей, формируется исключение.
      /// </remarks>
      public static bool IsFileExsist(string name)
      {
         if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("message", nameof(name));

         return File.Exists(GetFile(name));
      }

      /// <summary>
      /// Создает пустой json файл под хранилище свойств вью-модели.
      /// </summary>
      /// <param name="name">Строка, содержащая имя json файла.</param>
      /// <remarks>Например, для хранения значений свойств MainViewModel при первом запуске., иначе метод MainViewModel.Initialize не выполняется.</remarks>
      /// <remarks>
      /// Если параметр <c>name</c> содержит <c>null</c>, пустую строку или строку состоящую из символов разделителей, формируется исключение.
      /// </remarks>
      public static void CreateFile(string name)
      {
         if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("message", nameof(name));

         try
         {
            using (StreamWriter sw = new StreamWriter(GetFile(name), append: false, encoding: Encoding.Default))
            {
               sw.WriteLine("{}");
            }
         }
         catch (Exception)
         {
            throw;
         }

#if DEBUG
         string msg = $"Отладка: JsonExtension.CreateFile({name}) executed.";

         System.Diagnostics.Debug.WriteLine(msg);
#endif
      }

      /// <summary>
      /// Добавляет расширение к имени файла.
      /// </summary>
      /// <param name="name">Строка, содержащая имя json файла.</param>
      /// <returns>Строка, содержащая имя файла с расширением.</returns>
      private static string GetFile(string name)
      {
         return name + Serializer.JsonExtension;
      }

      #endregion Methods
   }
}
