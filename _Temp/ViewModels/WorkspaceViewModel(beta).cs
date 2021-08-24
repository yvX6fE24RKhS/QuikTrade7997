using System;
using System.Runtime.Serialization;
using Foundation;

namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Модель представления рабочего пространства.
   /// </summary>
   /// <version>1.0..* : 1.0.7900.*</version>
   [DataContract]
   public class WorkspaceViewModel : ViewModel
   {
      #region Fields

      /// <summary>
      /// Заголовок рабочего пространства.
      /// </summary>
      private string _header;

      #endregion Fields

      #region Properties

      /// <summary>
      /// Идентификатор рабочего пространства.
      /// </summary>
      [DataMember]
      public Guid Uid { get; set; } = Guid.NewGuid();

      /// <summary>
      /// Указывает, вделено рабочее пространство или нет.
      /// </summary>
      [DataMember]
      public bool IsSelected { get; set; }

      /// <summary>
      /// Заголовок рабочего пространства.
      /// </summary>
      [DataMember]
      //public abstract string Header { get; set; }
      public string Header { get => _header; set => _header = value; }

      /// <summary>
      /// Контент рабочего пространства.
      /// </summary>
      [DataMember]
      public object Content
      {
         get { return Get(() => this.Content); }
         set { Set(() => this.Content, value); }
      }
      
      #endregion Properties

      #region Constructors

      /// <summary>
      /// Инициализирует новый экземпляр класса <see cref="WorkspaceViewModel"/>. 
      /// </summary>
      protected WorkspaceViewModel()
      {
      }

      #endregion Constructors
   }
}
