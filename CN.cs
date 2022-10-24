using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace JSCNSercurity
{
    public  class CN
    {
        
        /// <summary>
        /// Tính đơn Tăng/giảm giá theo %
        /// </summary>
        /// <param name="value">Giá hiện tại</param>
        /// <param name="percent">Số phần trăm</param>
        /// <returns></returns>
        public static float PricePercent(int value, int percent)
        {
            float per = value * percent / 100;

            return per;
        }
        /// <summary>
        /// Tinh phần trăm dựa vào giá trị &  tổng
        /// </summary>
        /// <param name="Value">Giá trị</param>
        /// <param name="Total">Tổng số</param>
        /// <returns></returns>
        public static float calcPercent(int Value, int Total)
        {
            return Value / Total * 100;
        }
       
        public static bool isNumber(string value)
        {
            int outNumber = 0;
            return int.TryParse(value, out outNumber);
        }

        public static bool isNull(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }
            return false;
        }
        public static bool isNotNull(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return true;
            }
            return false;
        }

        public static bool isNull(dynamic input)
        {
            if (input == null)
            {
                return true;
            }
            return false;
        }
        public static bool isNotNull(dynamic input)
        {
            if (input != null)
            {
                return true;
            }
            return false;
        }
        public static bool IsLastChar(string input, char charInput)
        {
            if (input.LastIndexOf(charInput) > 0)
            {
                return true;
            }
            return false;
        }
        public static bool IsFirstChar(string input, char charInput)
        {
            if (input.IndexOf(charInput) > 0)
            {
                return true;
            }
            return false;
        }
        public static bool isArrayNull(string[] ArrInput)
        {
            if (ArrInput.Length <= 0 || ArrInput == null)
            {
                return true;
            }
            return false;
        }
        public static bool isArrayNotNull(string[] ArrInput)
        {
            if (ArrInput.Length <= 0 || ArrInput == null)
            {
                return false;
            }
            return true;
        }
        public static decimal? CalcPerMoney(decimal? price, decimal? percent)
        {
            var calcs = price.Value * percent / 100;
            return calcs;
        }
       
    }
    public static class SCN
    {      public static bool lowerContain(this string input, string contain)
        {
            if (input.ToLower().Contains(contain.ToLower()))
            {
                return true;
            }
            return false;
        }
        public static bool lowerContains(this string input, string contain)
        {
            if (input.ToLower().Contains(contain.ToLower()))
            {
                return true;
            }
            return false;
        }
        public static bool upperContain(this string input, string contain)
        {
            if (input.ToUpper().Contains(contain.ToUpper()))
            {
                return true;
            }
            return false;
        }
        public static bool upperContains(this string input, string contain)
        {
            if (input.ToUpper().Contains(contain.ToUpper()))
            {
                return true;
            }
            return false;
        }
		//
        public static string ReplaceAt(this string str, int index, int length, string replace)
        {
            return str.Remove(index, Math.Min(length, str.Length - index))
                    .Insert(index, replace);
        }
        /// <summary>
        ///  kiểm tra sdt
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool isPhone(this string input)
        {
            // sdt check
            string Patt = @"(84|0[3|5|7|8|9])+([0-9]{8})\b";
            Regex rex = new Regex(Patt);

           
            if (rex.IsMatch(input))
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
     /// Kiểm tra xem có đúng định dạng email không 
     /// </summary>
     /// <param name="input"></param>
     /// <returns></returns>
        public static bool isEmail(this string input)
        {
            string Patt = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex rex = new Regex(Patt);


            if (rex.IsMatch(input))
            {
                return true;
            }
            return false;
        }
        public static bool isDomain(this string input)
        {
            string patt = @"(?:[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?\.)+[a-z0-9][a-z0-9-]{0,61}[a-z0-9]";
            Regex rex = new Regex(patt);

            if (rex.IsMatch(input))
            {
                return true;
            }
            return false;
        }
        public static bool isNull(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }
            return false;
        }
        public static bool isNotNull(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return true;
            }
            return false;
        }
        public static string HideInfo(this string input)
        {
            if (input.isNull()) return null;
            string str = null;
            if (input.isEmail())
            {
                var Astr = input.Split('@');
                if (Astr[0].Length > 3)
                {
                    str = Astr[0].ReplaceAt(2,Astr[0].Length - 1, "********") + "@" + Astr[1];
                }
                else
                {
                    str = Astr[0].ReplaceAt(1, Astr[0].Length - 1, "********") + "@" + Astr[1];
                }

            }
            else if(input.isPhone())
            {

                str = input.ReplaceAt(3,5,"********");
            }
            else
            {
                if (input.Length > 3)
                {
                    str = input.ReplaceAt(2, input.Length - 1, "********");
                }
                else
                {
                    str = input.ReplaceAt(1, input.Length - 1, "********");
                }
            }
           

            return str;
        }

        /// <summary>
        /// Xóa dấu tiếng việt
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveTV(this string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
            "đ",
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
            "í","ì","ỉ","ĩ","ị",
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "d",
            "e","e","e","e","e","e","e","e","e","e","e",
            "i","i","i","i","i",
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
            "u","u","u","u","u","u","u","u","u","u","u",
            "y","y","y","y","y",};


            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        /// <summary>
        /// Chuyển đổi tên sản phẩm sang URL
        /// </summary>
        /// <param name="input"></param>
        /// <param name="extension"></param>
        /// <param name="UpperLenght"></param>
        /// <param name="isRemoveSpace"></param>
        /// <returns></returns>
        public static string TitleConvert(this string input, string extension = "", int UpperLenght = 200, bool isRemoveSpace = true)
        {

            if (input.Length >= UpperLenght)
            {
                if (isRemoveSpace)
                {
                    return input.Substring(0, UpperLenght).RemoveTV().Replace(' ', '-') + extension;

                }
                return input.Substring(0, UpperLenght).RemoveTV() + extension;
            }
            if (isRemoveSpace)
            {
                return input.RemoveTV().Replace(' ', '-') + extension;

            }
            return input.RemoveTV() + extension;
        }
        /// <summary>
        /// Chuyển đổi tên sản phẩm sang URL
        /// </summary>
        /// <param name="input"></param>
        /// <param name="extension"></param>
        /// <param name="UpperLenght"></param>
        /// <param name="isRemoveSpace"></param>
        /// <returns></returns>
        public static string TitleConvert(this string input, int UpperLenght = 200, string extension = "", bool isRemoveSpace = true)
        {

            if (input.Length >= UpperLenght)
            {
                if (isRemoveSpace)
                {
                    return input.Substring(0, UpperLenght).RemoveTV().Replace(' ', '-') + extension;

                }
                return input.Substring(0, UpperLenght).RemoveTV() + extension;
            }
            if (isRemoveSpace)
            {
                return input.RemoveTV().Replace(' ', '-') + extension;

            }
            return input.RemoveTV() + extension;
        }


    }
    public static class NCN
    {
        public static bool isNumber(this string value)
        {
            int outNumber = 0;
            return int.TryParse(value, out outNumber);
        }

        #region int?
        public static bool isNull(this int? input)
        {
            if (input == null)
            {
                return true;
            }
            return false;
        }
        public static bool isNotNull(this int? input)
        {
            if (input == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region decimal?
        public static bool isNull(this decimal? input)
        {
            if (input == null)
            {
                return true;
            }
            return false;
        }
        public static bool isNotNull(this decimal? input)
        {
            if (input == null)
            {
                return false;
            }
            return true;
        }
        #endregion
        #region double?
        public static bool isNull(this double? input)
        {
            if (input == null)
            {
                return true;
            }
            return false;
        }
        public static bool isNotNull(this double? input)
        {
            if (input == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region bool?
        public static bool isNull(this bool? input)
        {
            if (input == null)
            {
                return true;
            }
            return false;
        }
        public static bool isNotNull(this bool? input)
        {
            if (input == null)
            {
                return false;
            }
            return true;
        }
        #endregion
   

        public static decimal? CalcPerMoney(this decimal? price, double? percent)
        {
            double calcs = (double)price - ((double)price.Value  / 100 * percent.Value);
            var res = Convert.ToDecimal(calcs);
            return res;
        }
    }

}