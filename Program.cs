using System;
using System.Linq;

namespace RemarcableBinaryNumbers {
	class Program {

		static string AskQuestion(string question, params string[] options) {
			Console.WriteLine(question);
			return PrintOptions(options);
		}

		static int GetPositiveNumberSafe(int? maxValue = null, int? minValue = 0) {
			while (true) {
				if (!uint.TryParse(Console.ReadLine(), out var input))
					continue;
				if (input > maxValue || input < minValue)
					continue;
				return (int) input;
			}
		}
		
		static string PrintOptions(params string[] options) {
			for (var i = 0; i < options.Length; i++) {
				var option = options[i];
				Console.WriteLine($"[{i+1}]: {option}");
			}

			return options[GetPositiveNumberSafe(options.Length)-1];
		}
		
		static void Main(string[] args) {
			while (true) {
				switch (AskQuestion("What would you like to learn about?", "Exponents", "Decimal Numbers", "Binary Numbers", "Unsigned Binary Bit Representation", "Signed Binary Bit Representation", "Quit")) {
					case "Exponents":
						Exponents();
						break;
					case "Decimal Numbers":
						DecimalNumbers();
						break;
					case "Binary Numbers":
						BinaryNumbers();
						break;
					case "Unsigned Binary Bit Representation":
						UnsignedBinary();
						break;
					case "Signed Binary Bit Representation":
						SignedBinary();
						break;
					case "Quit":
						return;
				}
			}
		}

		static void Exponents() {
			while (true) {
				switch (AskQuestion("Choose an exercise: ", "What's the result?", "What's the exponent?", "What's the base?", "What's the base and the exponent?", "Go Back")) {
					case "What's the result?":
						ExponentResult();
						break;
					case "What's the exponent?":
						ExponentExponent();
						break;
					case "What's the base?":
						ExponentBase();
						break;
					case "What's the base and the exponent?":
						ExponentBoth();
						break;
					case "Go Back":
						return;
				}
			}
		}

		static void ExponentBoth() {
			var @base = random.Next(1, 11);
			var exponent = random.Next(2, 4);
			var number = (int) Math.Pow(@base, exponent);
			Console.WriteLine($"What could be the base of {number}?");
			var responseBase = GetPositiveNumberSafe();
			Console.WriteLine($"What could be the exponent of {responseBase} to get {number}?");
			var responseExponent = GetPositiveNumberSafe(int.MaxValue, 2);
			if (number == (int)Math.Pow(responseBase, responseExponent)) {
				Console.WriteLine("Correct!");
				if (AskQuestion("Do you want to see the explanation?", "Yes", "No") == "No")
					return;
			} else {
				Console.WriteLine("Error!");
			}

			Console.WriteLine("If you want to guess both the base as well as the exponent of a number.");
			Console.WriteLine("You need to find a number that multiplied with itself enough times.");
			Console.WriteLine("Results in the number that was given to you.");
			Console.WriteLine("You can start by trying, what number your number is divisible by.");
			Console.WriteLine($"In this case, {number} is divisible by {@base}: {number}/{@base} = {number/@base}.");
			Console.WriteLine($"Now, we need to find out, how often it is divisible. In this case:");
			Console.WriteLine($"{exponent} times: {string.Join("x", Enumerable.Repeat(@base, exponent))}");
			Console.ReadKey();
		}

		static void ExponentBase() {
			var @base = random.Next(1, 11);
			var exponent = @base < 5 ? random.Next(1, 5) : random.Next(1, 4);
			var number = (int) Math.Pow(@base, exponent);
			Console.WriteLine($"What could be the base b for b^{exponent}={number}?");
			var responseBase = GetPositiveNumberSafe();
			if (responseBase == @base) {
				Console.WriteLine("Correct!");
				if (AskQuestion("Do you want to see the explanation?", "Yes", "No") == "No")
					return;
			} else {
				Console.WriteLine("Error!");
			}

			Console.WriteLine("If you want to find out the base of a number whose exponent you know.");
			Console.WriteLine("You need to try pretty hard.");
			Console.WriteLine("The most guaranteed way would be to separate the number into all its factors.");
			Console.WriteLine("16 for example would be 2 * 2 * 2 * 2");
			Console.WriteLine("Now, you can order them into as many equal groups as given by the exponent.");
			Console.WriteLine("If the exponent would be 1, it would be: (2*2*2*2) = 16^1");
			Console.WriteLine("If the exponent would be 2, it would be: (2*2) * (2*2) = 4 * 4 = 4^2");
			Console.WriteLine("If the exponent would be 4, it would be: (2)*(2)*(2)*(2) = 2^4");
			Console.WriteLine($"In this case, {number} can be written as: {@base}^{exponent}.");
			Console.WriteLine($"{number}={string.Join("x", Enumerable.Repeat(@base, exponent))}");
			Console.ReadKey();
		}

		static void ExponentExponent() {
			var @base = random.Next(1, 11);
			var exponent = @base < 5 ? random.Next(6) : random.Next(5);
			var number = (int) Math.Pow(@base, exponent);
			Console.WriteLine($"What could be the exponent e for {@base}^e={number}?");
			var responseExponent = GetPositiveNumberSafe();
			if (responseExponent == exponent) {
				Console.WriteLine("Correct!");
				if (AskQuestion("Do you want to see the explanation?", "Yes", "No") == "No")
					return;
			} else {
				Console.WriteLine("Error!");
			}

			Console.WriteLine("If you want to find out the exponent of a number whose base you know.");
			Console.WriteLine($"You simply need to find out, how often the resulting number {number}");
			Console.WriteLine($"Is divisible by {@base}.");
			Console.WriteLine($"In this case: {exponent} times:");
			for (var i = 0; i < exponent; i++) {
				Console.WriteLine($"{(int) Math.Pow(@base, exponent - i)}/{@base}={(int) Math.Pow(@base, exponent - i - 1)}");
			}
			Console.WriteLine($"Therefore, in this case, {number} can be written as: {@base}^{exponent}.");
			Console.WriteLine($"{number}={string.Join("x", Enumerable.Repeat(@base, exponent))}");
			Console.ReadKey();
		}

		static void ExponentResult() {
			var @base = random.Next(1, 11);
			var exponent = @base < 5 ? random.Next(6) : random.Next(4);
			var number = (int) Math.Pow(@base, exponent);
			Console.WriteLine($"What is the result of {@base}^{exponent}?");
			var responseNumber = GetPositiveNumberSafe();
			if (responseNumber == number) {
				Console.WriteLine("Correct!");
				if (AskQuestion("Do you want to see the explanation?", "Yes", "No") == "No")
					return;
			} else {
				Console.WriteLine("Error!");
			}

			Console.WriteLine("If you want to find out the result of an exponent.");
			Console.WriteLine($"You need to take the number 1 and multiply it The exponent times with the base.");
			Console.WriteLine($"For {@base}^{exponent}, {@base} is the base and {exponent} is the exponent.");
			Console.WriteLine($"1x{string.Join("x", Enumerable.Repeat(@base, exponent))}={number}");
			Console.ReadKey();
		}

		static void DecimalNumbers() {
			while (true) {
				switch (AskQuestion("Choose an exercise: ", "What's the max number?", "How many digits do you need?", "Go Back")) {
					case "What's the max number?":
						DecimalMaxNumber();
						break;
					case "How many digits do you need?":
						DecimalDigitCount();
						break;
					case "Go Back":
						return;
				}
			}
		}

		static Random random = new();

		static void DecimalMaxNumber() {
			var numberOfDigits = random.Next(3, 11);
			Console.WriteLine($"What's the largest Decimal Number that can be represented using {numberOfDigits} Digits?");
			var response = GetPositiveNumberSafe();
			if (response == (int)Math.Pow(10, numberOfDigits) - 1) {
				Console.WriteLine("Correct!");
				if (AskQuestion("Do you want to see the explanation?", "Yes", "No") == "No")
					return;
			} else {
				Console.WriteLine("Error!");
			}

			Console.WriteLine("The decimal system has 10 digits: 0,1,2,3,4,5,6,7,8,9");
			Console.WriteLine("The highest decimal digit is 9");
			Console.WriteLine("In order to get the highest possible number using X digits...");
			Console.WriteLine("...you need to write as many 9's as there are digits!");
			Console.ReadKey();
		}

		static void DecimalDigitCount() {
			var number = random.Next(1, 99999999);
			Console.WriteLine($"How many digits do you need to print {number}?");
			var response = GetPositiveNumberSafe();
			if (response == number.ToString().Length) {
				Console.WriteLine("Correct!");
				if (AskQuestion("Do you want to see the explanation?", "Yes", "No") == "No")
					return;
			} else {
				Console.WriteLine("Error!");
			}

			Console.WriteLine("In order to find out, how many digits are needed to print a decimal number.");
			Console.WriteLine("You just need to count the number of digits that you can see.");
			Console.WriteLine("We use the decimal system in our every-day life.");
			Console.WriteLine("Therefore, no conversion is necessary.");
			Console.ReadKey();
		}
		
		static void BinaryNumbers() {
			while (true) {
				switch (AskQuestion("Choose an exercise: ", "Decimal To Binary", "Binary To Decimal", "Adding Binary", "Subtracting Binary", "Go Back")) {
					case "Decimal To Binary":
						DecimalToBinary();
						break;
					case "Binary To Decimal":
						BinaryToDecimal();
						break;
					case "Adding Binary":
						AddingBinary();
						break;
					case "Subtracting Binary":
						SubtractingBinary();
						break;
					case "Go Back":
						return;
				}
			}
		}

		static void SubtractingBinary() {
			var a = random.Next(64);
			var b = random.Next(64);
			if (a < b) {
				var c = a;
				a = b;
				b = c;
			}
			var aBinary = $"0b{Convert.ToString(a, 2).PadLeft(6, '0')}";
			var bBinary = $"0b{Convert.ToString(b, 2).PadLeft(6, '0')}";
			var result = $"0b{Convert.ToString(a-b, 2).PadLeft(6, '0')}";
			Console.WriteLine("Solve this addition (in binary with 0b1001000-Notation with 6 digits!):");
			Console.WriteLine($"  {aBinary}");
			Console.WriteLine($" -{bBinary}");
			Console.WriteLine($"----------");
			if (Console.ReadLine() == result) {
				Console.WriteLine("Correct!");
				if (AskQuestion("Do you want to see the explanation?", "Yes", "No") == "No")
					return;
			} else {
				Console.WriteLine("Error! Correct result: "+result);
			}

			Console.WriteLine("If you want to subtract two numbers in Binary.");
			Console.WriteLine("You go just the same as in Decimal:");
			Console.WriteLine("You go from right to left and add subtract digit one by one.");
			Console.WriteLine("If the 2nd number's digit is greater than the first one.");
			Console.WriteLine("You borrow one digit from the next digit.");
			Console.WriteLine("In Decimal, it looks like this:");
			Console.WriteLine(" 24");
			Console.WriteLine("- 7");
			Console.WriteLine("-     (borrowed digits)");
			Console.WriteLine("---");
			Console.ReadKey();
			Console.WriteLine("We can not subtract 7 from 4, so we need to borrow a 10 and subtract 7 from (4+10) instead:");
			Console.WriteLine(" 24");
			Console.WriteLine("- 7");
			Console.WriteLine("-1    (borrowed digits)");
			Console.WriteLine("---");
			Console.WriteLine("  7");
			Console.ReadKey();
			Console.WriteLine("Now, 2 - 0 - 1 equals 1:");
			Console.WriteLine(" 24");
			Console.WriteLine("- 7");
			Console.WriteLine("-1    (borrowed digits)");
			Console.WriteLine("---");
			Console.WriteLine(" 17");
			Console.ReadKey();
			Console.WriteLine("24 - 7 = 17.");
			Console.ReadKey();
			Console.WriteLine("In Binary, it basically looks the same:");
			Console.WriteLine(" 10");
			Console.WriteLine("- 1");
			Console.WriteLine("-     (borrowed digits)");
			Console.WriteLine("---");
			Console.ReadKey();
			Console.WriteLine("We can not subtract 1 from 0, so we need to borrow a 10 and subtract 1 from (0+10) instead:");
			Console.WriteLine(" 10");
			Console.WriteLine("- 1");
			Console.WriteLine("-1    (borrowed digits)");
			Console.WriteLine("---");
			Console.WriteLine("  1");
			Console.ReadKey();
			Console.WriteLine("Now, 1 - 0 - 1 equals 0:");
			Console.WriteLine(" 10");
			Console.WriteLine("- 1");
			Console.WriteLine("-1    (borrowed digits)");
			Console.WriteLine("---");
			Console.WriteLine("  1");
			Console.ReadKey();
			Console.WriteLine("10 - 1 = 1. (In Decimal: 2 - 1 = 1). Seems legit.");
			
			Console.ReadKey();
			var output = String.Empty;
			var remainder = false;
			var remainderString = " ";
			for (var i = 0; i < 6; i++) {
				var space = string.Concat(Enumerable.Repeat(' ', 6-i));

				var aCurrent = aBinary[^(i+1)];
				var bCurrent = bBinary[^(i+1)];
				var augend = int.Parse(aCurrent.ToString());
				string digitResult;
				var subtrahend = int.Parse(bCurrent.ToString()) + (remainder ? 1 : 0);
				Console.WriteLine($"The subtrahend is {bCurrent}(b){(remainder ? " - 1 (Borrowed)" : "")} = {Convert.ToString(subtrahend, 2)}");
				if (subtrahend > augend) {
					remainder = true;
					Console.WriteLine($"It is greater than the digit we are subtracting from ({augend}), therefore, we need to borrow one from the next digit.");
					augend += 2;
					Console.WriteLine($"{Convert.ToString(augend, 2)}-{Convert.ToString(subtrahend, 2)}={Convert.ToString(augend - subtrahend, 2)} (In Decimal this is: {augend}-{subtrahend}={augend-subtrahend}). This is this digit's result.");
					digitResult = Convert.ToString(augend - subtrahend, 2);
				} else if (subtrahend == augend) {
					remainder = false;
					Console.WriteLine($"It is the same size as the digit we are subtracting from ({augend}), therefore, the result is 0.");
					digitResult = "0";
				} else {
					remainder = false;
					Console.WriteLine($"1 - 0 = 1. Therefore, the result is 1.");
					digitResult = "1";
				}
				Console.WriteLine($"{digitResult} goes to the result. {(remainder ? "The borrowed digit (1) goes to the next digit." : "")}");
				output = digitResult[^1]+output;
				remainderString = (remainder ? "1" : " ") + remainderString;
				
				Console.WriteLine($"   {space}v");
				Console.WriteLine($"  {aBinary}");
				Console.WriteLine($" -{bBinary}");
				Console.WriteLine($" - {space}{remainderString}   (Remainder)");
				Console.WriteLine($"----------");
				Console.WriteLine($" 0b{space}{output}");
				Console.WriteLine($"   {space}^");
				Console.ReadKey();
			}
		}

		static void AddingBinary() {
			var a = random.Next(64);
			var b = random.Next(64);
			var aBinary = $"0b{Convert.ToString(a, 2).PadLeft(6, '0')}";
			var bBinary = $"0b{Convert.ToString(b, 2).PadLeft(6, '0')}";
			var result = $"0b{Convert.ToString(a+b, 2).PadLeft(7, '0')}";
			Console.WriteLine("Solve this addition (in binary with 0b1001000-Notation with 7 digits!):");
			Console.WriteLine($"  {aBinary}");
			Console.WriteLine($" +{bBinary}");
			Console.WriteLine($"----------");
			if (Console.ReadLine() == result) {
				Console.WriteLine("Correct!");
				if (AskQuestion("Do you want to see the explanation?", "Yes", "No") == "No")
					return;
			} else {
				Console.WriteLine("Error! Correct result: "+result);
			}

			Console.WriteLine("If you want to add two numbers in Binary.");
			Console.WriteLine("You go just the same as in Decimal:");
			Console.WriteLine("You go from right to left and add each digit one by one.");
			Console.WriteLine("And if one overflows, you pass it on to the next digit.");
			Console.ReadKey();
			var output = String.Empty;
			var remainder = false;
			var remainderString = " ";
			for (var i = 0; i < 6; i++) {
				var space = string.Concat(Enumerable.Repeat(' ', 6-i));

				Console.WriteLine($"At digit #{i}, we have {(remainder ? "a" : "no")} remainder.");
				var aCurrent = aBinary[^(i+1)];
				var bCurrent = bBinary[^(i+1)];
				var digitResult = $"0b{Convert.ToString(int.Parse(aCurrent.ToString()) + int.Parse(bCurrent.ToString()) + (remainder ? 1 : 0), 2)}";
				Console.WriteLine($"The result of this addition is {aCurrent}(a) + {bCurrent}(b){(remainder ? " + 1 (Remainder)" : "")} = {digitResult}");
				Console.WriteLine($"{digitResult[^1]} goes to the result. {(digitResult.Length > 3 ? "The remainder (1) goes to the next digit." : "")}");
				output = digitResult[^1]+output;
				remainder = digitResult.Length > 3;
				remainderString = (remainder ? "1" : " ") + remainderString;
				
				Console.WriteLine($"   {space}v");
				Console.WriteLine($"  {aBinary}");
				Console.WriteLine($" +{bBinary}");
				Console.WriteLine($" + {space}{remainderString}   (Remainder)");
				Console.WriteLine($"----------");
				Console.WriteLine($" 0b{space}{output}");
				Console.WriteLine($"   {space}^");
				Console.ReadKey();
			}

			if (remainder) {
				Console.WriteLine("We have one more remainder that we need to add to the result: ");
				output = "1" + output;
			} else {
				Console.WriteLine("We have no remainder. But let's fill up that leading zero as requested by the exercise: ");
				output = "0" + output;
			}

			{
				var space = "";
				Console.WriteLine($"   {space}v");
				Console.WriteLine($"  {aBinary}");
				Console.WriteLine($" +{bBinary}");
				Console.WriteLine($" +  {space}{remainderString}   (Remainder)");
				Console.WriteLine($"----------");
				Console.WriteLine($" 0b{space}{output}");
				Console.WriteLine($"   {space}^");
				Console.ReadKey();
			}
		}

		static void BinaryToDecimal() {
			var randomNumber = random.Next(64);
			var binary = $"0b{Convert.ToString(randomNumber, 2)}";
			Console.WriteLine($"What's {binary} in decimal? Do not add any unnecessary zeros.");
			if (Console.ReadLine() == randomNumber.ToString()) {
				Console.WriteLine("Correct!");
				if (AskQuestion("Do you want to see the explanation?", "Yes", "No") == "No")
					return;
			} else {
				Console.WriteLine("Error!");
			}

			Console.WriteLine("In order to convert a binary number to a decimal.");
			Console.WriteLine("We start with 0 and walk down every digit from right to left and add its value to our number.");
			Console.WriteLine("A binary number's digit's value doubles from right to left:");
			var binaryLeftPart = binary;
			char current;
			var binaryRightPart = string.Empty;
			int result = 0;
			Console.WriteLine("                                 Result: 0");
			Console.ReadKey();
			for (var i = 0; i < binary.Length-2; i++) {
				current = binaryLeftPart[^1];
				binaryLeftPart = binaryLeftPart.Substring(0, binaryLeftPart.Length - 1);
				Console.WriteLine($"Digit #{i} of {binaryLeftPart}({current}){binaryRightPart} is: 2^{i}={(int)Math.Pow(2, i)}");
				switch (current) {
					case '0':
						Console.WriteLine($"The Digit is 0, though, so we add 0*{(int)Math.Pow(2, i)} = 0 = nothing to our result.");
						break;
					case '1':
						Console.WriteLine($"The Digit is 1, so we add 1*{(int)Math.Pow(2, i)} = {(int)Math.Pow(2, i)} to our result: {result}+{(int)Math.Pow(2, i)}={result+((int)Math.Pow(2, i))}");
						result += (int) Math.Pow(2, i);
						break;
				}
				binaryRightPart = current + binaryRightPart;
				Console.WriteLine($"                                 Result: {result}");
				Console.ReadKey();
			}

			Console.WriteLine("That's it!");
			Console.ReadKey();
		}

		static void DecimalToBinary() {
			var randomNumber = random.Next(64);
			Console.WriteLine($"What's {randomNumber} in binary? Use the 0b100 notation. Do not add any unnecessary zeros.");
			if (Console.ReadLine() == $"0b{Convert.ToString(randomNumber, 2)}") {
				Console.WriteLine("Correct!");
				if (AskQuestion("Do you want to see the explanation?", "Yes", "No") == "No")
					return;
			} else {
				Console.WriteLine("Error!");
			}

			Console.WriteLine("There is two main ways for learning, how to convert a decimal number to a binary number.");
			switch (AskQuestion("Which one do you want to learn about?", "From Large to Small", "From Small to Large", "None")) {
				case "From Large to Small":
					Console.WriteLine("For this method, you start at the largest bit that fits into the number and make your way down.");
					var result = "0b";
					for (var i = 5; i >= 0; i--) {
						var current = (int) Math.Pow(2, i);
						Console.WriteLine($"Does 2^{i}={current} fit in {randomNumber}?");
						Console.ReadKey();
						if (current <= randomNumber) {
							result += "1";
							Console.WriteLine($"                                         Yes! Add a 1 to our result. And subtract {current} from {randomNumber}: {randomNumber}-{current}={randomNumber-current}.");
							randomNumber -= current;
						} else {
							if (result.Length > 2) {
								result += "0";
								Console.WriteLine($"                                         No! Let's add a 0 to our binary number to show, that {current} does not fit in {randomNumber}.");
							} else {
								Console.WriteLine("                                         No! Since we have not found any bits yet, we do not have to add a zero, yet.");
							}
						}
						Console.WriteLine($"Binary number: {result}[...] Remainder: {randomNumber}");
						Console.ReadKey();
					}
					break;
				case "From Small to Large":
					Console.WriteLine("For this method, you continuously divide the number that you want to fit by 2 and put the remainder into the binary number.");
					result = "";
					while (randomNumber > 0) {
						Console.WriteLine($"If we divide {randomNumber} by 2, the result is {randomNumber / 2} and the remainder        {randomNumber % 2}.");
						result = randomNumber % 2 + result;
						Console.WriteLine($"The remainder ({randomNumber % 2}) goes to our binary number:                  0b[...]{result}.");
						randomNumber /= 2;
						Console.ReadKey();
					}
					Console.WriteLine($"The result is 0 now, so we can take a look at our final binary number: 0b{result}.");
					break;
				case "None":
					return;
			}

			Console.ReadKey();
		}

		static void UnsignedBinary() {
			Console.WriteLine("Not implemented, yet.");
		}

		static void SignedBinary() {
			Console.WriteLine("Not implemented, yet.");
		}
	}
}