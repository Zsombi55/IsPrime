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
 */
using System;

namespace IsPrime
{
	class Program
	{
		public static void Main(string[] args)
		{
			Program P = new Program();
			double number = 537430451; // for quick testing.  Prime?: true | Deletable?: true, viable routes: 3.
			
/* - while testing.
			
  			Console.WriteLine("Enter number:");
			string data = Console.ReadLine();
			
			if(Double.TryParse(data, out number)) // Validity check.
				Console.WriteLine("Is  {0}  a prime? {1}.", number, P.IsPrime(number));				
			else
				Console.WriteLine("'{0}' is not a valid number.", data);
*/			
			Console.WriteLine("Is  {0}  a prime? {1}.", number, P.IsPrime(number));
			
//			if (P.IsPrime(n)) {
//				Console.WriteLine("Is deletable? ", P.IsDeletable(n));
//			}

			Console.ReadKey();
//			EndApp();
		}

// ----- Is Prime -----
		private bool IsPrime(double n) {
			double sqrtN = Math.Floor(Math.Sqrt(n));   // no decimals
			bool p = (n != 1);     // boolean
			for(int i = 2; i < sqrtN + 1; i++) {
				if(n % i == 0) {
					p = false;
					break;
				}
			}
			return p;
		}
		
// ----- Is Deletable ----- // clearly there are C# method/syntax differences from JS.

// some misc temp code
//		private bool IsDeletable(double n) {
//			string s = n.ToString();
//			bool d = true;
//			
//			TruncateLeft(s);
//			TruncateRight(s);
//			
//			if (!d) {
//				d = false;
//				break;
//			}
//			return d;
//		}
//		
//		private void TruncateLeft(string s) { // truncate sequence from left
//			int le = s.Length;
//
//			for (int i = 0 ; i < le; i++) {
//				string tl = s.Slice(i, le);
//				if (IsPrime(string tl)) {
//					Console.WriteLine(tl);
//				}
//			}
//		}
//
//		private void TruncateRight(string s) { // truncate sequence from right
//			int le = s.Length;
//
//			for (int i = 0 ; i < le; i++) {
//				string tr = s.Slice(0, le - i);
//				if (IsPrime(string tr)) {
//					Console.WriteLine(tr);
//				}
//			}
//		}
	}
}