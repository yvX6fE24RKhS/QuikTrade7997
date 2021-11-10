using System.Xml.Serialization;

namespace QuikTrade.DataTypes.Enums
{
   /// <summary>
   /// Перечисление уровней серьёзности событий.
   /// </summary>
   /// <version>1.0.7983.* : 1.0.7878.*</version>
   public enum Severity
   {
      /// <summary> Авария: система непригодна для использования. </summary>
      [XmlEnum(Name = "emergency")]
      emergency,
      /// <summary> Предупреждение: необходимо немедленно принять меры. </summary>
      [XmlEnum(Name = "alert")]
      alert,
      /// <summary> Критическое: критические условия. /// </summary>
      [XmlEnum(Name = "critical")]
      critical,
      /// <summary> Ошибка: условия ошибки. </summary>
      [XmlEnum(Name = "error")]
      error,
      /// <summary> Предупреждение: условия предупреждения. </summary>
      [XmlEnum(Name = "warning")]
      warning,
      /// <summary> Примечание: нормальное, но серьезное состояние. </summary>
      [XmlEnum(Name = "notice")]
      notice,
      /// <summary> Информаця: информационные сообщения. </summary>
      [XmlEnum(Name = "info")]
      info,
      /// <summary> Отладка: сообщения уровня отладки, полная трассировка. </summary>
      [XmlEnum(Name = "debug")]
      debug
   }
}