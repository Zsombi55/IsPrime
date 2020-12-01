/*
 * Created by SharpDevelop.
 * User: Zsombor
 * Date: 2020-11-23
 * Time: 09:56
 * 
 * Primes are numbers that can only be divided cleanly by 1 or themselves.
 *  If removing any single digit still results in a prime, and if shrinking it down to one digit it still remains a prime,
 * then the "original" was a Deletable Prime; if also true, the number of viable "routes" are to be noted, eg.:
 * 4125673:12, 41256793:21, 537430451:3, 200899998:0, 537499093:8, 2147483059:8
 * 
 * THIS IS INCOMPLETE. Have not figured out how to code the Deletable check.
 * 
 * =>> Input -> Validation (numbers only) -> Useless character removal (symbols, pre- & post-useful_nr zeroes) if user disregards instructions..
 *			-> Check IF input IsPrime ~~>> else there is no use continuing.
 * -->> A. make backup -> B. remove digit -> C. IsPrime(rest) ? ~~> FALSE: return to B. now removing a different digit now (4567 _567 -> _467)..
 * 			~~> TRUE: save result somewhere -> return to B. using this result (467 _67) ->[..]-> if result is 1 digit long & IsPrime -> routes 0 += 1
 * This is to be repeated on all viable results, counting all routes.
 */
using System;
using System.Text;

namespace IsPrime
{
	class Program
	{
		public static void Main(string[] args)
		{
			Program P = new Program();
//			Console.WriteLine("Use positive whole numbers! Enter number:"); string inputData = Console.ReadLine();
			string inputData = "-s001086,70"; // Test, (useful) length: 5.  Prime?: true | Deletable?: true, viable routes: 4.
//			string inputData = "-004056,70"; // Prime?: false.

			string data = P.IsValid(inputData); // Check if input is prime else no reason to continue.
			if(data == "0") { Console.WriteLine("\n{0}  is not a valid number.", inputData); Console.ReadKey(); }
			else {
				Console.WriteLine("Work data: {0}", data);
				Console.WriteLine("\nIs  {0}  a prime? {1}.\r\n", P.NoZero(inputData), P.IsPrime(data)); Console.ReadKey();
			}
		}

// ----- Helper Functions -----
		private double NoZero(string inputData) { // remove useless zeroes.
			double d; Double.TryParse(inputData, out d);
			return d;
		}

		private string IsValid(string inputData) { // check 'data' instead after test !
			try {
				string dt = NoZero(inputData).ToString(); // d.ToString();
				Console.WriteLine("double: {0}", NoZero(inputData));
				Console.WriteLine("0-less string : {0}", dt);
					// apparently bad but won't get into Regex now.
				if(dt.Contains("-")) { dt = dt.Replace("-", ""); }
				if(dt.Contains(",")) { dt = dt.Replace(",", ""); }
				if(dt.Contains(".")) { dt = dt.Replace(".", ""); }
				
				Console.WriteLine("cleared string {0}", dt);
				return dt;
			}
			catch {
				return "0";
			}
		}
	
		private void RemoveCharacter(string s) { // truncate sequence from left TODO doesn't work as intended; put into list, array, file or smt. ?
			int le = s.Length;
			for (int i = 0; i < le; ++i) {
				StringBuilder sb = new StringBuilder(s);
				sb.Remove(i, 1);
				Console.WriteLine(sb);
			}
		}
		
// ----- Is Prime -----
		private bool IsPrime(string data) {
			int n; Int32.TryParse(data, out n);
			double sqrtN = Math.Sqrt(n);
			bool b = (n != 1);     // boolean
			for(int i = 2; i < sqrtN + 1; i++) {
				if(n % i == 0) {
					b = false;
					break;
				}
			}
			return b;
		}
		
// ----- Is Deletable -----TODO

//		private int IsDeletable(string data) {
//			int n; Int32.TryParse(data, out n);
//			int le = n.ToString().Length;
//			int r = 0;
//			
//			for (int i = 0; i < le; i++)
//			{
//				no = n.ToString().Length;
//				string dt = RemoveCharacter(string s);
//
//				if (IsPrime(dt))
//				{
//					if ( dt / 10 == 0 ) { p++; }
//					else { IsDeletable(le, dt, r ); }
//				}
//			}
//			return r;
//		}
	}
}