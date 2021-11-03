using System;
using System.Windows;
using System.Windows.Controls;

namespace QuikTrade.Utilities
{
   /// <summary>
   /// Предоставляет способ выбрать System.Windows.DataTemplate на основе объекта данных и элемента с привязкой к данным.
   /// </summary>
   /// <remarks>>author: Роман Мейтес</remarks>
   /// <version>1.0..* : 1.0..*</version>
   public class DefaultTemplateSelector : DataTemplateSelector
   {
      /// <summary>
      /// При переопределении в производном классе возвращает System.Windows.DataTemplate на основе пользовательской логики.
      /// </summary>
      /// <param name="item">Объект данных, для которого можно выбрать шаблон.</param>
      /// <param name="container"></param>
      /// <returns></returns>
      public override DataTemplate SelectTemplate(object item, DependencyObject container)
      {
         if (container is FrameworkElement fe && item != null)
         {
            Type itemType = item.GetType();
            return fe.TryFindResource(itemType) as DataTemplate;
         };
         return base.SelectTemplate(item, container);
      }
   }
}
