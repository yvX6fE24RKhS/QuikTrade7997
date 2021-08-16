using System;
using Foundation;
using System.Runtime.Serialization;

namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Модель представления рабочего пространства.
   /// </summary>
   /// <version>1.0.7898.* : none</version>
   [DataContract]
   public abstract class WorkspaceViewModel : ViewModel
   {
      #region Properties

      /// <summary>
      /// Идентификатор рабочего пространства.
      /// </summary>
      [DataMember]
      public Guid Uid { get; set; }

      /// <summary>
      /// Заголовок рабочего пространства.
      /// </summary>
      [DataMember]
      public abstract string Header { get; set; }

      /// <summary>
      /// Указывает, вделено рабочее пространство или нет.
      /// </summary>
      [DataMember]
      public bool IsSelected { get; set; }

      #endregion Properties

      #region Constructor

      /// <summary>
      /// Инициализирует новый экземпляр класса <see cref="WorkspaceViewModel"/>. 
      /// </summary>
      protected WorkspaceViewModel()
      {
      }

      #endregion Constructor
   }
}
