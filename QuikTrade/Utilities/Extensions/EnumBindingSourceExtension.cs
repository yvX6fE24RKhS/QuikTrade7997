using System;
using System.Windows.Markup;

namespace QuikTrade.Utilities.Extensions
{
   /// <summary>
   /// Расширение разметки для связывания списка значений перечисления и элемента управления.
   /// </summary>
   /// <remarks>>author: Brian Logunas</remarks>
   /// <version>1.0..* : 1.0..*</version>
   public class EnumBindingSourceExtension : MarkupExtension
   {
      #region Fields

      private Type _enumType;

      #endregion Fields

      #region Properties

      /// <summary>
      /// Тип перечисления.
      /// </summary>
      public Type EnumType
      {
         get { return _enumType; }
         set
         {
            if (value != _enumType)
            {
               if (null != value)
               {
                  Type enumType = Nullable.GetUnderlyingType(value) ?? value;

                  if (!enumType.IsEnum)
                     throw new ArgumentException("Type must be for an Enum.");
               }

               _enumType = value;
            }
         }
      }

      #endregion Properties

      #region Constructors

      /// <summary>
      /// Инициализирует новый экземпляр <see cref="EnumBindingSourceExtension"/>
      /// </summary>
      public EnumBindingSourceExtension() { }

      /// <summary>
      /// Инициализирует новый экземпляр <see cref="EnumBindingSourceExtension"/> класса для заданного типа.
      /// </summary>
      /// <param name="enumType"><see cref="Type"/> Тип перечисления.</param>
      public EnumBindingSourceExtension(Type enumType) => EnumType = enumType;

      #endregion Constructors

      #region Methods

      /// <summary>
      /// Возвращает список значений перечисления, предоставляемый как значение целевого свойства для данного расширения разметки.
      /// </summary>
      /// <param name="serviceProvider">Вспомогательный объект поставщика служб, способный предоставлять службы для расширения разметки.</param>
      /// <returns>Список значений перечисления.</returns>
      public override object ProvideValue(IServiceProvider serviceProvider)
      {
         if (null == _enumType)
            throw new InvalidOperationException("The EnumType must be specified.");

         Type actualEnumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;
         Array enumValues = Enum.GetValues(actualEnumType);

         if (actualEnumType == _enumType)
            return enumValues;

         Array tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
         enumValues.CopyTo(tempArray, 1);
         return tempArray;
      }

      #endregion Methods
   }
}
