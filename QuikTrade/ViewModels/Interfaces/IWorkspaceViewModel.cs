using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Интерфейс модели представления рабочего пространства.
   /// </summary>
   /// <version>1.0..* : 1.0..*</version>
   public interface IWorkspaceViewModel
   {
      #region Properties

      /// <summary>
      /// Идентификатор рабочего пространства.
      /// </summary>
      Guid Uid { get; }

      /// <summary>
      /// Заголовок рабочего пространства.
      /// </summary>
      string Header { get; set; }

      /// <summary>
      /// Указывает, вделено рабочее пространство или нет.
      /// </summary>
      bool IsSelected { get; set; }

      #endregion Properties
   }
}
