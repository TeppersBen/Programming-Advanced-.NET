using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {

        #region NOTES
        /**
         * string.IsNullOrEmpty(string), checks whether string is empty or null.
         * string.join(string, string), turns the second string with the first string within each second string.
         */
        #endregion

        private int _value;
        public int Add(string numbers)
        {
            if (numbers != "")
            {
                if (numbers.Contains("\n"))
                    numbers = numbers.Replace("\n", ",");

                if (numbers.Contains(","))
                {
                    try
                    {
                        String[] segments = numbers.Split(',');
                        for (int index = 0; index < segments.Length; index++)
                        {
                            _value += int.Parse(segments[index]);
                        }
                    }
                    catch (FormatException ex)
                    {
                        throw new Exception("Invalid Number");
                    }
                }
                else
                {
                    _value = int.Parse(numbers);
                }
            }
            return _value;
        }
    }
}
