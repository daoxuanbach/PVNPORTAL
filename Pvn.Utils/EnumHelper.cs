using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Pvn.Utils
{
    #region class EnumHelper
    /// <summary>
    /// Provides a static utility object of methods and properties to interact with enumerated types. 
    /// </summary>
    public static class EnumHelper
    {
        #region events

        #endregion

        #region class-wide fields

        #endregion

        #region private and internal properties and methods

        #region properties

        #endregion

        #region methods

        #endregion

        #endregion

        #region public properties and methods

        #region properties

        #endregion

        #region methods

        #region GetDescription
        /// <summary>
        /// Gets the <see cref="DescriptionAttribute"/> of an <see cref="Enum"/> type value.
        /// </summary>
        /// <param name="value">The <see cref="Enum"/> type value.</param>
        /// <returns>A string containing the text of the <see cref="DescriptionAttribute"/>.</returns>
        public static string GetDescription(this Enum value)
        {
            try
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                string description = value.ToString();
                FieldInfo fieldInfo = value.GetType().GetField(description);
                EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    description = attributes[0].Description;
                }
                return description;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EnumHelper", "GetDescription", ex.Message);
                return string.Empty;
            }

        }
       
        #endregion

        #region ToExtendedList
        /// <summary>
        ///  Converts the <see cref="Enum"/> type to an <see cref="IList"/> compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="IList"/> containing the enumerated type value and description.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "This is a more advanced use of the ToList function; providing a type parameter has no semantic meaning for this function and would actually make the calling syntax more complicated.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static IList ToExtendedList<T>(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (!type.IsEnum)
            {
                throw new ArgumentException(Resources.ArgumentExceptionMustBeEnum, "type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                
                list.Add(new KeyValueTriplet<Enum, T, string>(value, (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture), GetDescription(value)));
            }

            return list;
        }
        #endregion

        #region ToList

        #region ToList(this Type type)
        /// <summary>
        ///  Converts the <see cref="Enum"/> type to an <see cref="IList"/> compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="IList"/> containing the enumerated type value and description.</returns>
        public static IList ToList(this Type type)
        {
            
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (!type.IsEnum)
            {
                throw new ArgumentException(Resources.ArgumentExceptionMustBeEnum, "type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<int, string>(value.GetHashCode(), GetDescription(value)));
            }

            return list;
        }
        public static IList ToListInValue(this Type type, string stringValue )
        {
            try
            {
                if (type == null)
                {
                    throw new ArgumentNullException("type");
                }

                if (!type.IsEnum)
                {
                    throw new ArgumentException(Resources.ArgumentExceptionMustBeEnum, "type");
                }
                if (string.IsNullOrEmpty(stringValue))
                {
                    throw new ArgumentNullException("stringValue Null");
                }
                ArrayList list = new ArrayList();
                Array enumValues = Enum.GetValues(type);
                List<string> lstvalue = stringValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (Enum value in enumValues)
                {
                    if (lstvalue.Contains(value.GetHashCode().ToString()))
                    {
                        list.Add(new KeyValuePair<int, string>(value.GetHashCode(), GetDescription(value)));
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EnumHelper", "GetDescription", ex.Message);
                return null;
            }
            
        }
        #endregion

        #region ToList<T>(this Type type)
        /// <summary>
        ///  Converts the <see cref="Enum"/> type to an <see cref="IList"/> compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="IList"/> containing the enumerated type value and description.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "This is a more advanced use of the ToList function; providing a type parameter has no semantic meaning for this function and would actually make the calling syntax more complicated.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static IList ToList<T>(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (!type.IsEnum)
            {
                throw new ArgumentException(Resources.ArgumentExceptionMustBeEnum, "type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<T, string>((T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture), GetDescription(value)));
            }

            return list;
        }
        #endregion

        #endregion

        #endregion

        #endregion
    }
    #endregion
}
