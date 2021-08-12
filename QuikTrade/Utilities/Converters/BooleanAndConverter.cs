using System;
using System.Linq;
using System.Windows.Data;

namespace QuikTrade.Utilities
{
   /// <summary>
   /// Конвертор реализующий логическое умножение.
   /// </summary>
   /// <see href="https://askdev.ru/q/c-wpf-isenabled-s-ispolzovaniem-neskolkih-privyazok-76540/"/>
   /// <version>1.0..* : none</version>
   internal class BooleanAndConverter : IMultiValueConverter
   {
      #region Methods
      #region IMultiValueConverter Memebers

      /// <summary>
      /// Выполняет логическое умножение над элементами массива.
      /// </summary>
      /// <param name="values">Массив значений, создаваемый исходными привязками в System.Windows.Data.MultiBinding.</param>
      /// <param name="targetType">Тип целевого свойства привязки.</param>
      /// <param name="parameter">Используемый параметр преобразователя.</param>
      /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
      /// <returns>Результат логического умножения над элементами массива.</returns>
      public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         return values.OfType<IConvertible>().All(System.Convert.ToBoolean);
      }

      /// <summary>
      /// Обратное преобразование не предусмотрено.
      /// </summary>
      /// <param name="value">Значение, произведенное целевым объектом привязки.</param>
      /// <param name="targetTypes">Целевой массив байтов преобразования.</param>
      /// <param name="parameter">Используемый параметр преобразователя.</param>
      /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
      /// <returns>Вызывает исключение <see cref="NotSupportedException"/></returns>
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
      {
         throw new NotSupportedException();
      }

      #endregion IMultiValueConverter Memebers
      #endregion Methods
   }
}