using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesExamples
{
    class NamingStyles
    {
        public enum CamelCase
        {
            AssemblyNames,
            NamespaceNames,
            ClassNames,
            StructNames,
            EnumNames,
            PropertyNames,
            MethodNames,
            Constants,

            //То есть каждое новое слово пишется с большой буквы без пробелов
            EveryWordWithUpperLetter,

            //аббривиатуры пишутся в следующем стиле:

            XmlAbbreviations
        }

        public enum pascalCase
        {
            fieldNames,
            argumentsNames,
            localVariables,

            //То есть первое слово с маленькой буквы, каждое новое слово пишется с большой буквы без пробелов
            everyWordWithUpperLetterExeptFirstOne,
        }


        public enum lowercase
        {
            pythonvariables
        }

        public enum lowercase_with_underscores
        {
            python_variables,
            old_c_style
        }

        public enum UPPERCASE
        {
            CPP_CONSTANTS,
            PYTHON_CONSTANTS
        }

        /// <summary>
        /// Устарело, не используйте
        /// </summary>
        [Obsolete]
        public enum hungarian_Notation
        {
            i_Age, // i for int
            d_Radius, // d for double
            PhoneString, // при изменении типа со стринг на PhoneNumber нужно поменять и имя переменной 
        }

    }
}
