﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.239
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderSystem.Resources.Shared {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorRes {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorRes() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OrderSystem.Resources.Shared.ErrorRes", typeof(ErrorRes).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Confirm Password is not equal to Password.
        /// </summary>
        internal static string ConfirmPasswordIsNotEqual {
            get {
                return ResourceManager.GetString("ConfirmPasswordIsNotEqual", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {0} cannot contain numbers.
        /// </summary>
        internal static string FieldContainNumbers {
            get {
                return ResourceManager.GetString("FieldContainNumbers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {0} cannot contain spaces.
        /// </summary>
        internal static string FieldContainSpaces {
            get {
                return ResourceManager.GetString("FieldContainSpaces", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {0} field cannot be shorter then {2} and longer then {1} characters.
        /// </summary>
        internal static string FieldIsLimited {
            get {
                return ResourceManager.GetString("FieldIsLimited", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {0} cannot be blank.
        /// </summary>
        internal static string FieldIsRequired {
            get {
                return ResourceManager.GetString("FieldIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {0} is too long.
        /// </summary>
        internal static string FieldIsTooLong {
            get {
                return ResourceManager.GetString("FieldIsTooLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Incorrect format of {0}.
        /// </summary>
        internal static string IncorrectFormatOfField {
            get {
                return ResourceManager.GetString("IncorrectFormatOfField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Login Name already exists.
        /// </summary>
        internal static string LoginExistsInDB {
            get {
                return ResourceManager.GetString("LoginExistsInDB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The value provided for the password does not meet required complexity.
        /// </summary>
        internal static string PasswordIsWeak {
            get {
                return ResourceManager.GetString("PasswordIsWeak", resourceCulture);
            }
        }
    }
}
