using System.Text.RegularExpressions;

namespace SimpleTest
{
    public static class MyTest
    {
        public static string CalculateTotal(string someInput)
        {            
            if (string.IsNullOrWhiteSpace(someInput))
            {
                throw new DataMisalignedException("data not correct");
            }

            var log = new ConsoleLogger();

            log.Log("start CalculateTotal");


            #region start algorithm

            // remove all (.,;') chars
            someInput = RemoveSpecialChars(someInput);

            // string to List
            List<string>? listSomeInput = someInput.Split(' ').ToList();

            // Sort each word Alphabetically
            listSomeInput.Sort(StringComparer.Ordinal);

            // Sort upper case to lower case
            listSomeInput.Sort(StringComparer.OrdinalIgnoreCase);

            #endregion end algorithm


            log.Log("end CalculateTotal");

            return listSomeInput.Aggregate((x, y) => x + " " + y); ;            
        }

        /// <summary>
        /// Remove (.,;') special chars from string
        /// </summary>
        /// <param name="someInput"></param>
        /// <returns></returns>
        private static string RemoveSpecialChars(string someInput)
        {
            return Regex.Replace(someInput, "[(.,;')]", "");
        }
    }    
}
