using System;
using System.Windows;
using System.Windows.Controls;

namespace QuikTrade.Utilities
{
   /// <summary>
   /// Предоставляет способ выбрать System.Windows.DataTemplate на основе объекта данных и элемента с привязкой к данным.
   /// </summary>
   /// <version>1.0.7991.* : 1.0.7991.*</version>
   public class ControlPanelTemplateSelector : DataTemplateSelector
   {
      /// <summary>
      /// При переопределении в производном классе возвращает System.Windows.DataTemplate на основе пользовательской логики.
      /// </summary>
      /// <param name="item">Объект данных, для которого можно выбрать шаблон.</param>
      /// <param name="container">Объект с привязкой к данным.</param>
      /// <returns>Возвращает тип System.Windows.DataTemplate или null. Значение по умолчанию — null.</returns>
      public override DataTemplate SelectTemplate(object item, DependencyObject container)
      {
         if (container is FrameworkElement fe && item != null)
         {
            string resourceKey = item.GetType().Name.Replace("WorkspaceViewModel", "ControlPanel");
            return fe.TryFindResource(resourceKey) as DataTemplate;
         };
         return base.SelectTemplate(item, container);
      }
   }
}
