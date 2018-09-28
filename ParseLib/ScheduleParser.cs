using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ParseLib.Models;

namespace ParseLib
{
    public static class ScheduleParser
    {
        public static ValuePair GetValuePair(string text)
        {
            ValuePair valuePair = new ValuePair
            {
                Value = text,
                Type = GetItemType(text)
            };
            return valuePair;
        }

        public static IList<ITypeValue> Parse(string inputString)
        {
            string[] resultArray = inputString.Split('\n');

            if (resultArray.Length == 0) throw new NullReferenceException();

            List<ITypeValue> valuePairs = new List<ITypeValue>(resultArray.Length);

            foreach (var text in resultArray)
            {
                valuePairs.Add(ParseString(text));
            }

            return valuePairs;
        }

        private static ITypeValue ParseString(string text)
        {
            if (text.IsWeek())
            {
                return new ValuePair("week", text);
            }
            if (text.IsTime())
            {
                return new ValuePair("time", text);
            }
            if (text.IsTeacher())
            {
                return new ValuePair("teacher", text);
            }
            if (text.IsPlace())
            {
                return new ValuePair("place", text);
            }
            if (!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
            {
                return new ValuePair("discipline", text);
            }
            return new ValuePair("error", text);
        }

        public static string GetItemType(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return "error";
            }
            if (text.IsWeek())
            {
                return "week";
            }
            if (text.IsTime())
            {
                return "time";
            }
            if (text.IsTeacher())
            {
                return "teacher";
            }
            if (text.IsPlace())
            {
                return "place";
            }
            if (!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
            {
                return "discipline";
            }
            return "error";
        }

        public static IList<IDiscipline> GetDisciplines(string inputString)
        {
            IList<ITypeValue> typeValues = Parse(inputString);
            throw new NotImplementedException();
        }
    }

    public static class RegexExtenstion
    {
        public static bool IsTime(this string text)
        {
            Regex regex = new Regex(@"^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])(:[0-5][0-9])?");
            return regex.IsMatch(text);
        }

        public static bool IsPlace(this string text)
        {
            Regex regex = new Regex(@"^([а-я]*\Dа.*([а-яА-Я]*))");
            return regex.IsMatch(text);
        }
        public static bool IsTeacher(this string text)
        {
            Regex normal = new Regex(@"^([А-я]* [А-Я].[А-Я].)");
            Regex group = new Regex(@"^([А-я]\D*-){1,3}");

            return normal.IsMatch(text) || group.IsMatch(text) ;
        }
        public static bool IsWeek(this string text)
        {
            Regex regex = new Regex(@"^(по\D\d\D\S*)");
            return regex.IsMatch(text);
        }
    }
}
