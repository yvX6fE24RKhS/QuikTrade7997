using System.Runtime.Serialization;

namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Пример вкладки.
   /// </summary>
   /// <version>1.0..* : 1.0.7900.*</version>
   [DataContract]
   public class TabItemSampleViewModel : WorkspaceViewModel
   {
      #region Constructors

      /// <summary>
      /// Инициализирует новый экземпляр класса<see cref= "TabItemSampleViewModel" />.
      /// </summary>
      public TabItemSampleViewModel()
      {
         this.Header = "SampleTab";
         this.Content = this.Uid;
      }

      #endregion Constructors
   }
}
