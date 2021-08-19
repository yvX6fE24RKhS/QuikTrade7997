﻿using System;
using Foundation;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Web.UI.WebControls;

namespace QuikTrade.ViewModels
{
   /// <summary>
   /// Модель представления рабочего пространства.
   /// </summary>
   /// <version>1.0.7900.* : 1.0.7898.*</version>
   [DataContract]
   public abstract class WorkspaceViewModel : ViewModel
   {
      #region Properties

      /// <summary>
      /// Идентификатор рабочего пространства.
      /// </summary>
      [DataMember]
      public Guid Uid { get; set; } = Guid.NewGuid();

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

      /// <summary>
      /// Контент рабочего пространства.
      /// </summary>
      [DataMember]
      public abstract object Content { get; set; } 

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
