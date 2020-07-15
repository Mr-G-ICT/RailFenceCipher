using System;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading;

namespace RailFenceCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringToEncode = "WEAREDISCOVEREDFLEEATONCE";
            string encodedString = "";
            string decodedString = "";

            Console.WriteLine("enter your string");
            stringToEncode = Console.ReadLine();

            encodedString = railfenceEncode("THISISASECRETMESSAGE", 4);
           decodedString = railfenceDecode(encodedString, 4);
            Console.WriteLine(decodedString);
        }

        

        public static string railfenceEncode(string StringToEncode, int NumberOfRails)
        {
            string encodedString = "";

            char[] splitWordUp = StringToEncode.ToCharArray();

            //CALCULATES THE POWER OF THE FIRST ROW (2,4,6,8 ETC) and counts down
            int power = 2 * (NumberOfRails - 1);


            //row 1 is the power that is required.
            for (int count = 0; count < splitWordUp.Length; count = count + power)
            {
                Console.Write(splitWordUp[count]);
                encodedString = encodedString + splitWordUp[count];
            }

            int railCount = 2;  //the row we are working on
            int secondpower = 0;  //this is for the second part of the breakup, goes 2,4,6,8 and counts up
            int secondCount = 0;//secondcount is just a counter that rolls through the loop
            int positionInString = 0; //tracks the position in the string
            while (railCount <= NumberOfRails - 1)
            {
                secondpower = secondpower + 2;

                power = power - 2;
                secondCount = 1;  //this is the row number tey are on
                positionInString = railCount - 1;   //this works out the start position in the string.
                Console.WriteLine("secondpower" + secondpower);
                //row 2 you have to alternate the string between power and 2
                while(positionInString < splitWordUp.Length )
                {
                    if (secondCount % 2 != 0)
                    {
                        Console.WriteLine("odd" + power);
                        encodedString = encodedString + splitWordUp[positionInString];
                        positionInString = positionInString + power;
                    }
                    else
                    {
                        Console.WriteLine("even");
                        encodedString = encodedString + splitWordUp[positionInString];
                        positionInString = positionInString + secondpower;
                    }

                    Console.WriteLine(encodedString);
                    secondCount++;
                }
                railCount++;
            }

            //last line is the same as the first line in code form, it's just the starting place that changes
            //row 1 is the power that is required.
            power = 2 * (NumberOfRails - 1);
            for (int count = NumberOfRails-1; count < splitWordUp.Length; count = count + power)
            {
                Console.Write(splitWordUp[count]);
                encodedString = encodedString + splitWordUp[count];
            }

            return encodedString;
        }

        public static string railfenceDecode(string StringToDecode, int NumberOfRails)
        {
            
            char[] splitWordUp = StringToDecode.ToCharArray();
            char[] decodedArray = new char[splitWordUp.Length];
            int power = 2 * (NumberOfRails - 1);

            //fill the array with spaces, testing purposes
            for (int i = 0; i < decodedArray.Length; i++)
            {
                decodedArray[i] = ' ';            }

            //do the first row
            int encodedCount = 0;
            for (int count1 = 0; count1 < splitWordUp.Length; count1 = count1 + power)
            {
                Console.WriteLine(splitWordUp[count1]);
                decodedArray[count1] = splitWordUp[encodedCount];
                encodedCount++;
            }
            Console.WriteLine(new string(decodedArray));

            //do the second row
            int positionInString = 0; //tracks the position in the string
            int secondpower = 0;  //this is for the second part of the breakup, goes 2,4,6,8 and counts up
            int secondCount = 0;//secondcount is just a counter that rolls through the loop

            //work out how many letters there are in row 2
            int railCount = 2;  //the row we are working on

            while (railCount <= NumberOfRails - 1)
            {

                secondpower = secondpower + 2;
                power = power - 2;
                positionInString = railCount - 1;
                secondCount = 1;

                while (positionInString < decodedArray.Length)
                {
                    if (secondCount % 2 != 0)
                    {
                        Console.WriteLine("odd" + positionInString);
                        decodedArray[positionInString] = splitWordUp[encodedCount];
                        positionInString = positionInString + power;
                    }
                    else
                    {
                        Console.WriteLine("even" + positionInString);
                        decodedArray[positionInString] = splitWordUp[encodedCount];
                        positionInString = positionInString + secondpower;
                    }
                    encodedCount++;
                    secondCount++;
                    Console.WriteLine(new string(decodedArray));
                }
                railCount++;
            }


            //last line is the same as the first line in code form, it's just the starting place that changes
            //row 1 is the power that is required.
            power = 2 * (NumberOfRails - 1);
            for (int count = NumberOfRails - 1; count < decodedArray.Length; count = count + power)
            {
                Console.WriteLine(count + " " + splitWordUp[encodedCount]);
                decodedArray[count] = splitWordUp[encodedCount];
                encodedCount++;
                Console.WriteLine(new string(decodedArray));
            }
            Console.WriteLine(new string(decodedArray));

            return new string(decodedArray);
}
    }
}

