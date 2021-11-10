using System.Runtime.Serialization;

namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Пример вкладки.
   /// </summary>
   /// <version>1.0.7983.* : 1.0.7900.*</version>
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

      #endregion Base Class Overrides
      #endregion Properties
   }
}
