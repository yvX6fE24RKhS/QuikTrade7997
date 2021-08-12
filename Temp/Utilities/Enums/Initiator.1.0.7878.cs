using System;
using System.Xml.Serialization;

namespace QuikTrade.Utilities
{
   /// <summary>
   /// Перечисление возможных инициаторов событий.
   /// </summary>
   /// <version>1.0.7878.* : none</version>
   public enum Initiator
   {
      /// <summary> Приложение. </summary>
      [XmlEnum(Name = "app")] 
      app,
      /// <summary> Торговая система. </summary>
      [XmlEnum(Name = "quik")] 
      quik,
      /// <summary> Пользователь. </summary>
      [XmlEnum(Name = "user")] 
      user
   }
}