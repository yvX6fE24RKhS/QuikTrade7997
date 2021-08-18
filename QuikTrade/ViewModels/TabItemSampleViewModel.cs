using System.Runtime.Serialization;
using System.Web.UI.WebControls;
using Foundation;
using System.Windows.Controls;

namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Пример вкладки
   /// </summary>
   /// <version>1.0..* : 1.0.7898.*</version>
   [DataContract]
   [KnownType(typeof(TabItemSampleViewModel))]
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

      /// <summary>
      /// Наполнение
      /// </summary>
      [DataMember]
      public override object Content
      {
         get { return Get(() => this.Content); }
         set { Set(() => this.Content, value); }
      }
#endregion Base Class Overrides
         #endregion Properties

         /// <summary>
         /// Инициализирует новый экземпляр класса<see cref= "WorkspaceViewModel" />.
         /// </summary>
      public TabItemSampleViewModel()
      {
         this.Content = this.Uid;
      }
   }
}
