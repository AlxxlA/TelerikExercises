using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace _1.SecretNumeralSystem
{
    class SecretNumeralSystem
    {
        static void Main()
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> codes = new Dictionary<string, int>()
            {
                { "hristo", 0 },
                { "tosho",1 },
                { "pesho", 2},
                { "hristofor", 3},
                { "vlad", 4},
                { "haralampi", 5},
                { "zoro", 6},
                { "vladimir" ,7}
            };

            List<string> numbers = new List<string>();

            for (int i = 0; i < tokens.Length; i++)
            {
                StringBuilder number = new StringBuilder();
                StringBuilder name = new StringBuilder();
                string encodedNumber = tokens[i];
                for (int j = 0; j < encodedNumber.Length; j++)
                {
                    name.Append(encodedNumber[j]);
                    string nameStr = name.ToString();

                    if (codes.ContainsKey(nameStr))
                    {
                        if (nameStr == "vlad" && j < encodedNumber.Length - 1)
                        {
                            if (encodedNumber[j + 1] == 'i')
                            {
                                nameStr = "vladimir";
                                j += 4;
                            }
                        }
                        if (nameStr == "hristo" && j < encodedNumber.Length - 1)
                        {
                            if (encodedNumber[j + 1] == 'f')
                            {
                                nameStr = "hristofor";
                                j += 3;
                            }
                        }

                        number.Append(codes[nameStr]);
                        name.Clear();
                    }
                }

                numbers.Add(number.ToString());
            }

            //foreach (var num in numbers)
            //{
            //    Console.WriteLine(num);
            //}

            var decimalNumbers = OctalToDecimal(numbers);

            //foreach (var decNum in decimalNumbers)
            //{
            //    Console.WriteLine(decNum);
            //}

            BigInteger product = Product(decimalNumbers);

            Console.WriteLine(product);
        }

        private static BigInteger Product(ulong[] numbers)
        {
            
            BigInteger product = new BigInteger(1);
            for (int i = 0; i < numbers.Length; i++)
            {
                product = BigInteger.Multiply(product, numbers[i]);
                
            }

            return product;
        }

        static ulong[] OctalToDecimal(List<string> numbers)
        {
            ulong[] result = new ulong[numbers.Count];

            for (int i = 0; i < numbers.Count; i++)
            {
                ulong number = Convert.ToUInt64(numbers[i], 8);
                result[i] = number;
            }

            return result;
        }
    }
}