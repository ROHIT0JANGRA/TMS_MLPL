﻿//  
// Type: StringFunctions
//  
//  
//  

using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class StringFunctions
{
  public static string Reverse(string input)
  {
    if (string.IsNullOrEmpty(input))
      return string.Empty;
    char[] charArray = input.ToCharArray();
    Array.Reverse((Array) charArray);
    return new string(charArray);
  }

  public static string InsertSeparator(string input, string separator)
  {
    if (string.IsNullOrEmpty(input))
      return string.Empty;
    List<char> charList = new List<char>((IEnumerable<char>) input.ToCharArray());
    char[] charArray = separator.ToCharArray();
    for (int index = 1; index < charList.Count; index += 1 + separator.Length)
    {
      if (index != charList.Count)
        charList.InsertRange(index, (IEnumerable<char>) charArray);
    }
    return new string(charList.ToArray());
  }

  public static string InsertSeparator(string input, string separator, int interval)
  {
    if (string.IsNullOrEmpty(input))
      return string.Empty;
    List<char> charList = new List<char>((IEnumerable<char>) input.ToCharArray());
    char[] charArray = separator.ToCharArray();
    for (int index = interval; index < charList.Count; index += interval + separator.Length)
    {
      if (index != charList.Count)
        charList.InsertRange(index, (IEnumerable<char>) charArray);
    }
    return new string(charList.ToArray());
  }

  public static string RemoveVowels(string input)
  {
    if (string.IsNullOrEmpty(input))
      return string.Empty;
    List<char> charList = new List<char>((IEnumerable<char>) input.ToCharArray());
    for (int index = charList.Count - 1; index >= 0; --index)
    {
      if (charList[index] == 'a' || charList[index] == 'A' || (charList[index] == 'e' || charList[index] == 'E') || (charList[index] == 'i' || charList[index] == 'I' || (charList[index] == 'o' || charList[index] == 'O')) || charList[index] == 'u' || charList[index] == 'U')
        charList.RemoveAt(index);
    }
    return new string(charList.ToArray());
  }

  public static string KeepVowels(string input)
  {
    if (string.IsNullOrEmpty(input))
      return string.Empty;
    List<char> charList = new List<char>((IEnumerable<char>) input.ToCharArray());
    for (int index = charList.Count - 1; index >= 0; --index)
    {
      if (charList[index] != 'a' && charList[index] != 'A' && (charList[index] != 'e' && charList[index] != 'E') && (charList[index] != 'i' && charList[index] != 'I' && (charList[index] != 'o' && charList[index] != 'O')) && charList[index] != 'u' && charList[index] != 'U')
        charList.RemoveAt(index);
    }
    return new string(charList.ToArray());
  }

  public static string AlternateCases(string input)
  {
    if (string.IsNullOrEmpty(input))
      return string.Empty;
    if (input.Length == 1)
      return input;
    char[] charArray = input.ToCharArray();
    bool flag = !char.IsUpper(charArray[0]);
    for (int index = 1; index < charArray.Length; ++index)
    {
      charArray[index] = !flag ? char.ToLower(charArray[index]) : char.ToUpper(charArray[index]);
      flag = !flag;
    }
    return new string(charArray);
  }

  public static string SwapCases(string input)
  {
    if (string.IsNullOrEmpty(input))
      return string.Empty;
    char[] charArray = input.ToCharArray();
    for (int index = 0; index < charArray.Length; ++index)
      charArray[index] = !char.IsUpper(charArray[index]) ? char.ToUpper(charArray[index]) : char.ToLower(charArray[index]);
    return new string(charArray);
  }

  public static string Capitalize(string input)
  {
    if (string.IsNullOrEmpty(input))
      return string.Empty;
    if (input.Length == 1)
      return input.ToUpper();
    return input[0].ToString().ToUpper() + input.Substring(1);
  }

  public static string GetInitials(
    string input,
    bool capitalizeInitials,
    bool preserveSpaces,
    bool includePeriod)
  {

        string empty;
        char upper;
        if (!string.IsNullOrEmpty(input))
        {
            string[] str = input.Split(new char[] { ' ' });
            for (int i = 0; i < (int)str.Length; i++)
            {
                if (str[i].Length > 0)
                {
                    if (!capitalizeInitials)
                    {
                        upper = str[i][0];
                        str[i] = upper.ToString();
                    }
                    else
                    {
                        upper = char.ToUpper(str[i][0]);
                        str[i] = upper.ToString();
                    }
                    if (includePeriod)
                    {
                        string[] strArrays = str;
                        string[] strArrays1 = strArrays;
                        int num = i;
                        strArrays[num] = string.Concat(strArrays1[num], ".");
                    }
                }
            }
            empty = (!preserveSpaces ? string.Join("", str) : string.Join(" ", str));
        }
        else
        {
            empty = string.Empty;
        }
        return empty;
    }

    public static string GetInitials(
    string input,
    string separator,
    bool capitalizeInitials,
    bool preserveSeparator,
    bool includePeriod)
  {
        string empty;
        char upper;
        if (!string.IsNullOrEmpty(input))
        {
            string[] str = input.Split(separator.ToCharArray());
            for (int i = 0; i < (int)str.Length; i++)
            {
                if (str[i].Length > 0)
                {
                    if (!capitalizeInitials)
                    {
                        upper = str[i][0];
                        str[i] = upper.ToString();
                    }
                    else
                    {
                        upper = char.ToUpper(str[i][0]);
                        str[i] = upper.ToString();
                    }
                    if (includePeriod)
                    {
                        string[] strArrays = str;
                        string[] strArrays1 = strArrays;
                        int num = i;
                        strArrays[num] = string.Concat(strArrays1[num], ".");
                    }
                }
            }
            empty = (!preserveSeparator ? string.Join("", str) : string.Join(separator, str));
        }
        else
        {
            empty = string.Empty;
        }
        return empty;
    }

    public static string GetTitle(string input)
  {
    if (string.IsNullOrEmpty(input))
      return string.Empty;
    string[] strArray = input.Split(' ');
    for (int index = 0; index < strArray.Length; ++index)
    {
      if (strArray[index].Length > 0)
        strArray[index] = char.ToUpper(strArray[index][0]).ToString() + strArray[index].Substring(1);
    }
    return string.Join(" ", strArray);
  }

  public static string GetTitle(string input, string separator)
  {
    if (string.IsNullOrEmpty(input))
      return string.Empty;
    string[] strArray = input.Split(separator.ToCharArray());
    for (int index = 0; index < strArray.Length; ++index)
    {
      if (strArray[index].Length > 0)
        strArray[index] = char.ToUpper(strArray[index][0]).ToString() + strArray[index].Substring(1);
    }
    return string.Join(separator, strArray);
  }

  public static string SubstringEnd(string input, int start, int end)
  {
    if (string.IsNullOrEmpty(input) || start == end)
      return string.Empty;
    if (start == 0 && end == input.Length)
      return input;
    if (start < 0)
      throw new IndexOutOfRangeException("start index cannot be less than zero.");
    if (start > input.Length)
      throw new IndexOutOfRangeException("start index cannot be greater than the length of the string.");
    if (end < 0)
      throw new IndexOutOfRangeException("end index cannot be less than zero.");
    if (end > input.Length)
      throw new IndexOutOfRangeException("end index cannot be greater than the length of the string.");
    if (start > end)
      throw new IndexOutOfRangeException("start index cannot be greater than the end index.");
    return input.Substring(start, end - start);
  }

  public static char CharRight(string input, int index)
  {
    if (string.IsNullOrEmpty(input))
      return char.MinValue;
    if (input.Length - index - 1 >= input.Length)
      throw new IndexOutOfRangeException("Index cannot be less than zero.");
    if (input.Length - index - 1 < 0)
      throw new IndexOutOfRangeException("Index cannot be larger than the length of the string");
    return input[input.Length - index - 1];
  }

  public static char CharMid(string input, int startingIndex, int count)
  {
    if (string.IsNullOrEmpty(input))
      return char.MinValue;
    if (startingIndex < 0)
      throw new IndexOutOfRangeException("startingIndex cannot be less than zero.");
    if (startingIndex >= input.Length)
      throw new IndexOutOfRangeException("startingIndex cannot be greater than the length of the string.");
    if (startingIndex + count < 0)
      throw new IndexOutOfRangeException("startingIndex + count cannot be less than zero.");
    if (startingIndex + count >= input.Length)
      throw new IndexOutOfRangeException("startingIndex + count cannot be greater than the length of the string.");
    return input[startingIndex + count];
  }

  public static int CountString(string input, string sequence, bool ignoreCase)
  {
    if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(sequence))
      return 0;
    int num = 0;
    for (int startIndex = 0; startIndex < input.Length && startIndex + sequence.Length <= input.Length; ++startIndex)
    {
      if (string.Compare(input.Substring(startIndex, sequence.Length), sequence, ignoreCase) == 0)
        ++num;
    }
    return num;
  }

  public static int[] IndexOfAll(string input, string sequence, bool ignoreCase)
  {
    if (string.IsNullOrEmpty(input))
      return new int[0];
    List<int> intList = new List<int>();
    for (int startIndex = 0; startIndex < input.Length && startIndex + sequence.Length <= input.Length; ++startIndex)
    {
      if (string.Compare(input.Substring(startIndex, sequence.Length), sequence, ignoreCase) == 0)
        intList.Add(startIndex);
    }
    int[] array = intList.ToArray();
    intList.Clear();
    return array;
  }

  public static int[] IndexOfAll(string input, string sequence, int startIndex, bool ignoreCase)
  {
    if (string.IsNullOrEmpty(input))
      return new int[0];
    List<int> intList = new List<int>();
    for (int startIndex1 = startIndex; startIndex1 < input.Length && startIndex1 + sequence.Length <= input.Length; ++startIndex1)
    {
      if (string.Compare(input.Substring(startIndex1, sequence.Length), sequence, ignoreCase) == 0)
        intList.Add(startIndex1);
    }
    int[] array = intList.ToArray();
    intList.Clear();
    return array;
  }

  public static bool IsAlternateCases(string input)
  {
    if (string.IsNullOrEmpty(input) || input.Length == 1)
      return false;
    bool flag = char.IsUpper(input[0]);
    for (int index = 1; index < input.Length; ++index)
    {
      if (flag)
      {
        if (char.IsUpper(input[index]))
          return false;
      }
      else if (char.IsLower(input[index]))
        return false;
      flag = !flag;
    }
    return true;
  }

  public static bool IsCapitalized(string input)
  {
    if (string.IsNullOrEmpty(input))
      return false;
    return char.IsUpper(input[0]);
  }

  public static bool IsLowerCase(string input)
  {
    if (string.IsNullOrEmpty(input))
      return false;
    for (int index = 0; index < input.Length; ++index)
    {
      if (!char.IsLower(input[index]) && char.IsLetter(input[index]))
        return false;
    }
    return true;
  }

  public static bool IsUpperCase(string input)
  {
    if (string.IsNullOrEmpty(input))
      return false;
    for (int index = 0; index < input.Length; ++index)
    {
      if (!char.IsUpper(input[index]) && char.IsLetter(input[index]))
        return false;
    }
    return true;
  }

  public static bool HasVowels(string input)
  {
    if (string.IsNullOrEmpty(input))
      return false;
    for (int index = 0; index < input.Length; ++index)
    {
      if (input[index] == 'a' || input[index] == 'A' || (input[index] == 'e' || input[index] == 'E') || (input[index] == 'i' || input[index] == 'I' || (input[index] == 'o' || input[index] == 'O')) || input[index] == 'u' || input[index] == 'U')
        return true;
    }
    return false;
  }

  public static bool IsSpaces(string input)
  {
    return string.IsNullOrEmpty(input) || input.Replace(" ", "").Length == 0;
  }

  public static bool IsRepeatedChar(string input)
  {
    return string.IsNullOrEmpty(input) || input.Replace(input[0].ToString(), "").Length == 0;
  }

  public static bool IsNumeric(string input)
  {
    if (string.IsNullOrEmpty(input))
      return false;
    for (int index = 0; index < input.Length; ++index)
    {
      if (!char.IsNumber(input[index]))
        return false;
    }
    return true;
  }

  public static bool HasNumeric(string input)
  {
    if (string.IsNullOrEmpty(input))
      return false;
    for (int index = 0; index < input.Length; ++index)
    {
      if (char.IsNumber(input[index]))
        return true;
    }
    return false;
  }

  public static bool IsAlphaNumeric(string input)
  {
    if (string.IsNullOrEmpty(input))
      return false;
    for (int index = 0; index < input.Length; ++index)
    {
      if (!char.IsLetter(input[index]) && !char.IsNumber(input[index]))
        return false;
    }
    return true;
  }

  public static bool IsLetters(string input)
  {
    if (string.IsNullOrEmpty(input))
      return false;
    for (int index = 0; index < input.Length; ++index)
    {
      if (!char.IsLetter(input[index]))
        return false;
    }
    return true;
  }

  public static bool IsTitle(string input)
  {
    if (string.IsNullOrEmpty(input))
      return false;
    string[] strArray = input.Split(' ');
    for (int index = 0; index < strArray.Length; ++index)
    {
      if (strArray[index].Length > 0 && !char.IsUpper(strArray[index][0]))
        return false;
    }
    return true;
  }

  public static bool IsTitle(string input, string separator)
  {
    if (string.IsNullOrEmpty(input))
      return false;
    string[] strArray = input.Split(separator.ToCharArray());
    for (int index = 0; index < strArray.Length; ++index)
    {
      if (strArray[index].Length > 0 && !char.IsUpper(strArray[index][0]))
        return false;
    }
    return true;
  }

  public static bool IsEmailAddress(string input)
  {
    return !string.IsNullOrEmpty(input) && (input.IndexOf('@') != -1 && input.Length >= 5 && input.LastIndexOf('.') > input.IndexOf('@'));
  }

  public static string NextKeyCode(string KeyCode)
  {
    byte[] bytes = Encoding.ASCII.GetBytes(KeyCode);
    KeyCode = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
    int length = bytes.Length;
    bool flag1 = true;
    bool flag2 = true;
    for (int index = 0; index < length - 1; ++index)
    {
      if (bytes[index] != (byte) 90)
      {
        flag1 = false;
        break;
      }
    }
    if (flag1 && bytes[length - 1] == (byte) 57)
      bytes[length - 1] = (byte) 64;
    for (int index = 0; index < length; ++index)
    {
      if (bytes[index] != (byte) 57)
      {
        flag2 = false;
        break;
      }
    }
    if (flag2)
    {
      bytes[length - 1] = (byte) 47;
      bytes[0] = (byte) 65;
      for (int index = 1; index < length - 1; ++index)
        bytes[index] = (byte) 48;
    }
    for (int index = length; index > 0; --index)
    {
      if (index - length == 0)
        ++bytes[index - 1];
      if (bytes[index - 1] == (byte) 58)
      {
        bytes[index - 1] = (byte) 48;
        if (index - 2 != -1)
          ++bytes[index - 2];
        else
          break;
      }
      else if (bytes[index - 1] == (byte) 91)
      {
        bytes[index - 1] = (byte) 65;
        if (index - 2 != -1)
          ++bytes[index - 2];
        else
          break;
      }
      else
        break;
    }
    KeyCode = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
    return KeyCode;
  }
    public static string PreviousKeyCode(string KeyCode)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(KeyCode);
        int length = bytes.Length;
        bool allAtSymbols = true;
        bool allZeros = true;

        for (int index = 0; index < length - 1; ++index)
        {
            if (bytes[index] != (byte)64)
            {
                allAtSymbols = false;
                break;
            }
        }

        if (allAtSymbols && bytes[length - 1] == (byte)64)
        {
            bytes[length - 1] = (byte)58;
        }

        for (int index = 0; index < length; ++index)
        {
            if (bytes[index] != (byte)48)
            {
                allZeros = false;
                break;
            }
        }

        if (!allZeros)
        {
            for (int index = length; index > 0; --index)
            {
                if (index - length == 0)
                    --bytes[index - 1];

                if (bytes[index - 1] == (byte)48)
                {
                    bytes[index - 1] = (byte)57;
                    if (index - 2 != -1)
                        --bytes[index - 2];
                    else
                        break;
                }
                else if (bytes[index - 1] == (byte)91)
                {
                    bytes[index - 1] = (byte)65;
                    if (index - 2 != -1)
                        --bytes[index - 2];
                    else
                        break;
                }
                else
                    break;
            }
        }

        KeyCode = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
        return KeyCode;
    }

    //public static string PreviousKeyCode(string KeyCode)
    //{
    //  byte[] bytes = Encoding.ASCII.GetBytes(KeyCode);
    //  int length = bytes.Length;
    //  bool flag1 = true;
    //  bool flag2 = true;
    //  for (int index = 0; index < length - 1; ++index)
    //  {
    //    if (bytes[index] != (byte) 64)
    //    {
    //      flag1 = false;
    //      break;
    //    }
    //  }
    //  if (flag1 && bytes[length - 1] == (byte) 64)
    //    bytes[length - 1] = (byte) 58;
    //  for (int index = 0; index < length; ++index)
    //  {
    //    if (bytes[index] != (byte) 48)
    //    {
    //      flag2 = false;
    //      break;
    //    }
    //  }
    //  if (!flag2)
    //        ;
    //  for (int index = length; index > 0; --index)
    //  {
    //    if (index - length == 0)
    //      --bytes[index - 1];
    //    if (bytes[index - 1] == (byte) 48)
    //    {
    //      bytes[index - 1] = (byte) 57;
    //      if (index - 2 != -1)
    //        --bytes[index - 2];
    //      else
    //        break;
    //    }
    //    else if (bytes[index - 1] == (byte) 91)
    //    {
    //      bytes[index - 1] = (byte) 65;
    //      if (index - 2 != -1)
    //        --bytes[index - 2];
    //      else
    //        break;
    //    }
    //    else
    //      break;
    //  }
    //  KeyCode = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
    //  return KeyCode;
    //}

    public static string NextKeyCode(string KeyCode, int IncreaseBy)
  {
    string KeyCode1 = KeyCode;
    for (int index = 0; index < IncreaseBy; ++index)
      KeyCode1 = StringFunctions.NextKeyCode(KeyCode1);
    return KeyCode1;
  }

  public static double GetDiff(string strFrom, string strTo)
  {
    double num1 = -1.0;
    if (strFrom.Length <= strTo.Length)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      foreach (char c in strFrom.ToCharArray())
      {
        if (char.IsLetter(c))
          stringBuilder3.Append(c);
        if (char.IsNumber(c))
          break;
      }
      foreach (char c in strFrom.Remove(0, stringBuilder3.ToString().Length).ToCharArray())
      {
        if (char.IsNumber(c))
          stringBuilder1.Append(c);
      }
      foreach (char c in strTo.Remove(0, stringBuilder3.ToString().Length).ToCharArray())
      {
        if (char.IsNumber(c))
          stringBuilder2.Append(c);
      }
      double num2 = Convert.ToDouble(stringBuilder1.ToString());
      num1 = Convert.ToDouble(stringBuilder2.ToString()) - num2 + 1.0;
    }
    return num1;
  }

  public static bool IsBetween(string input, string strFrom, string strTo)
  {
    bool flag = false;
    double diff = StringFunctions.GetDiff(strFrom, strTo);
    if (diff == 0.0)
      flag = input == strFrom;
    else if (diff > 0.0)
    {
      string KeyCode = strFrom;
      List<string> stringList = new List<string>();
      for (int index = 0; (double) index < diff; ++index)
      {
        if (input == KeyCode)
        {
          flag = true;
          break;
        }
        KeyCode = StringFunctions.NextKeyCode(KeyCode);
      }
    }
    return flag;
  }

  public static DateTime GetDate(string strDate_ddmmyyyy)
  {
    if (strDate_ddmmyyyy == "")
      return DateTime.MinValue;
    string str = strDate_ddmmyyyy;
    string[] strArray1 = new string[3];
    char[] chArray = new char[1]{ '/' };
    string[] strArray2 = str.Split(chArray);
    string s = "";
    int month = 0;
    int year = 0;
    for (int index = 0; index < strArray2.Length; ++index)
    {
      s = strArray2[0].ToString().Trim();
      month = int.Parse(strArray2[1]);
      year = int.Parse(strArray2[2]);
    }
    return new DateTime(year, month, int.Parse(s));
  }

  public class StringProcessing
  {
    public static string ArrayToString(IList array)
    {
      if (array == null || array.Count == 0)
        return string.Empty;
      string empty = string.Empty;
      for (int index = 0; index < array.Count; ++index)
      {
        empty += array[index].ToString();
        if (index != array.Count - 1)
          empty += Environment.NewLine;
      }
      return empty;
    }

    public static string ArrayToString(IList array, string separator)
    {
      if (array == null || array.Count == 0)
        return string.Empty;
      string empty = string.Empty;
      for (int index = 0; index < array.Count; ++index)
      {
        empty += array[index].ToString();
        if (index != array.Count - 1)
          empty += separator;
      }
      return empty;
    }
  }

  public class StringBuilderProcessing
  {
    public static string ArrayToString(IList array)
    {
      if (array == null || array.Count == 0)
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder(array.Count * 2);
      for (int index = 0; index < array.Count; ++index)
      {
        stringBuilder.Append(array[index].ToString());
        if (index != array.Count - 1)
          stringBuilder.Append(Environment.NewLine);
      }
      return stringBuilder.ToString();
    }

    public static string ArrayToString(IList array, string separator)
    {
      if (array == null || array.Count == 0)
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder(array.Count * 2);
      for (int index = 0; index < array.Count; ++index)
      {
        stringBuilder.Append(array[index].ToString());
        if (index != array.Count - 1)
          stringBuilder.Append(separator);
      }
      return stringBuilder.ToString();
    }
  }
}
