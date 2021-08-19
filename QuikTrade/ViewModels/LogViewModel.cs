using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using QuikTrade.Models;
using System.Runtime.Serialization;

namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Модель представления журнала.
   /// </summary>
   [DataContract]
   internal class LogViewModel : ViewModel
   {
      /// <summary>
      /// Журнал.
      /// </summary>
      /// <version>1.0..* : 1.0..*</version>
      /// [DataContract]
      private Log Log { get; set; }

      /// <summary>
      /// Указывает, является ли журнал журналом текущей сессии.
      /// </summary>
      [DataMember]
      internal bool IsCurrentSession { get; set; } = true;

      /// <summary>
      /// Дата журнала.
      /// </summary>
      [DataMember]
      internal DateTime LogDate { get; set; }

      /// <summary>
      /// Перечисление возможных форматов файлов с архивами журнала.
      /// </summary>
      internal enum ArchiveFormat { json, xml};

      /// <summary>
      ///  Формат файла с архивом журнала.
      /// </summary>
      [DataMember] 
      internal ArchiveFormat LogFormat { get; set; } = ArchiveFormat.json;

      public LogViewModel() => this.Log = App.Log;


   }
}
