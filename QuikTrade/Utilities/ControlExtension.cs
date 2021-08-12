using System.Windows;
using System.Windows.Media;

namespace QuikTrade.Utilities
{
   internal class ControlExtension
   {
      /// <summary>
      /// Найти родительский элемент управления определенного типа.
      /// </summary>
      /// <typeparam name="T">Тип родительского элемента.</typeparam>
      /// <param name="child">Дочерний элемент.</param>
      /// <returns>Родительский элемент искомого типа.</returns>
      /// <remarks>author: Brian Lagunas</remarks>
      /// <see href="Https://www.infragistics.com/community/blogs/b/blagunas/posts/find-the-parent-control-of-a-specific-type-in-wpf-and-silverlight"/>
      /// <version>1.0..* : none</version>
      public static T FindParent<T>(DependencyObject child) where T : DependencyObject
      {
         // получить родительский элемент
         DependencyObject parentObject = VisualTreeHelper.GetParent(child);

         // мы достигли конца дерева не найдя родительский элемент искомомго типа
         if (parentObject == null)
            return null;

         // проверяем, соответствует ли родительский тип искомому типу
         if (parentObject is T parent)
            return parent;
         else
            return FindParent<T>(parentObject);
      }
   }
}
