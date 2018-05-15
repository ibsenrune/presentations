using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			int? result = ReadAndAdd3();
			Console.WriteLine(result);
			
			Console.WriteLine("Press any key...");
			Console.ReadKey();
		}

		private static int? ReadAndAdd()
		{
			int? val1 = ReadInput();
			if (val1.HasValue)
			{
				int? val2 = ReadInput();
				if (val2.HasValue)
				{
					return val1.Value + val2.Value;
				}
				else
				{
					return null;
				}
			}
			else
			{
				return null;
			}
		}

		private static int? ReadAndAdd2()
		{
			int? val1 = ReadInput();
			if (val1.HasValue)
			{
				int? val2 = ReadInput();
				return Map<int, int>(x => x + val1.Value, val2);
			}
			else
			{
				return null;
			}
		}

		
		//In the case of the if-else above, we may want to return null, even if val1 has a value.
		//This means that we can't use Map below to remove the if-else above, because if the input value to Map is not null, it will
		//return something that is not null (see invariant below).
		//Instead, we introduce Bind

		private static int? ReadAndAdd3()
		{
			return Bind<int, int>(x => Map<int, int>(y => x + y, ReadInput()), ReadInput());
		}

		private static Nullable<U> Bind<T,U>(Func<T, Nullable<U>> func, Nullable<T> val) where T : struct
																						 where U : struct
		{
			//If we don't have a value of type T, there's not much interesting we can do
			if (!val.HasValue)
				return null;

			return func(val.Value);
		}

		//Invariant: When val is null, returns null. When val is not null, returns something that is not null
		private static Nullable<U> Map<T,U>(Func<T,U> mapFunc, Nullable<T> val) where T : struct
																				where U : struct 
		{
			if(!val.HasValue)
				return null;

			U result = mapFunc(val.Value);

			return result;
		}

		private static int? ReadInput()
		{
			string inputStr = Console.ReadLine();
			int readValue;
			return Int32.TryParse(inputStr, out readValue) ? (int?)readValue : null;
		}
	}
}
