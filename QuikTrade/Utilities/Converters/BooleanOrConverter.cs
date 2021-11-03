using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace QuikTrade.Utilities.Converters
{
   /// <summary>
   /// Конвертор реализующий логическое сложение.
   /// </summary>
   /// <see href="https://askdev.ru/q/c-wpf-isenabled-s-ispolzovaniem-neskolkih-privyazok-76540/"/>
   /// <version>1.0..* : none</version>
   internal class BooleanOrConverter : IMultiValueConverter
   {
      #region Methods
      #region IMultiValueConverter Memebers

      /// <summary>
      /// Выполняет логическое сложение над элементами массива.
      /// </summary>
      /// <param name="values">Массив значений, создаваемый исходными привязками в System.Windows.Data.MultiBinding.</param>
      /// <param name="targetType">Тип целевого свойства привязки.</param>
      /// <param name="parameter">Используемый параметр преобразователя.</param>
      /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
      /// <returns>Результат логического сложения над элементами массива.</returns>
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
         return values.OfType<IConvertible>().Any(System.Convert.ToBoolean);
      }

      /// <summary>
      /// Обратное преобразование не предусмотрено.
      /// </summary>
      /// <param name="value">Значение, произведенное целевым объектом привязки.</param>
      /// <param name="targetTypes">Целевой массив байтов преобразования.</param>
      /// <param name="parameter">Используемый параметр преобразователя.</param>
      /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
      /// <returns>Вызывает исключение <see cref="NotSupportedException"/></returns>
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
      {
         throw new NotSupportedException();
      }

      #endregion IMultiValueConverter Memebers
      #endregion Methods
   }
}