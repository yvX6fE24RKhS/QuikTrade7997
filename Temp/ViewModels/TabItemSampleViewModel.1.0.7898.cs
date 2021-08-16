using System.Runtime.Serialization;

namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Пример вкладки
   /// </summary>
   /// <version>1.0.7898.* : none</version>
   [DataContract]
   public class TabItemSampleViewModel : WorkspaceViewModel
   {
      #region Fields

      private string _header = "SampleTab";

      #endregion Fields

      #region Properties
      #region Base Class Overrides

      /// <summary>
      /// Заголовок
      /// </summary>
      [DataMember]
      public override string Header { get => _header; set => _header = value; }

      ///// <summary>
      ///// Наполнение
      ///// </summary>
      //[DataMember]
      //public override string Content { get => _content; set => _content = value; }

      #endregion Base Class Overrides
      #endregion Properties
   }
}
