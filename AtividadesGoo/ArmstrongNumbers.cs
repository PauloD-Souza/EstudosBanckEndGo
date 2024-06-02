namespace AtividadesGoo;

public static class ArmstrongNumbers
{
     public static bool IsArmstrong(this int number)
        {
            string numberStr = number.ToString();
            int numberOfDigits = numberStr.Length;
            int sum = numberStr.Sum(digitChar => (int)Math.Pow(char.GetNumericValue(digitChar), numberOfDigits));
            return sum == number;
        }
}
