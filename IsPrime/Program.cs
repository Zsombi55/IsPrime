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
			double n = 537430451; // Prime?: true | Deletable?: true, 3.
			
			Console.WriteLine("Is prime? {0}", P.IsPrime(n));
			
			if (P.IsPrime(n)) {
				Console.WriteLine("Is deletable? ", P.IsDeletable(n));
			}

			Console.ReadLine();
		}
		
// ----- Is Prime -----
		private bool IsPrime(double n) {
			double sqrtN = Math.Floor(Math.Sqrt(n));   // no decimals
			bool p = n != 1;     // boolean
			for(int i = 2; i < sqrtN + 1; i++) {
				if(n % i == 0) {
					p = false;
					break;
				}
			}
			return p;
		}
		
// ----- Is Deletable -----
		private bool IsDeletable(double n){
			string s = n.ToString();
			bool d = true;
			
			TruncateLeft(s);
			TruncateRight(s);
			
			if (!d) {
				d = false;
				break; // this worked fine in JS :(
			}
			return d;
		}
		
		private void TruncateLeft(string s) { // truncate sequence from left
			int le = s.Length;

			for (int i = 0 ; i < le; i++) {
				string tl = s.Slice(i, le); // clearly the C# method/syntax is something else for cutting up strings.
				if (IsPrime(tl)) {
					Console.WriteLine(tl);
				}
			}
		}

		private void TruncateRight(string s) { // truncate sequence from right
			int le = s.Length;

			for (int i = 0 ; i < le; i++) {
				string tr = s.Slice(0, le - i); // clearly the C# method/syntax is something else for cutting up strings.
				if (IsPrime(tr)) {
					Console.WriteLine(tr);
				}
			}
		}
	}
}