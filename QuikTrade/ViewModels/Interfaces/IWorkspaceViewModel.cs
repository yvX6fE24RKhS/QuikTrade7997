using System;

namespace QuikTrade.ViewModels.Interfaces
{
   /// <summary>
   /// Интерфейс модели представления рабочего пространства.
   /// </summary>
   /// <version>1.0.7983.* : 1.0.7983.*</version>
   public interface IWorkspaceViewModel : IViewModel
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
