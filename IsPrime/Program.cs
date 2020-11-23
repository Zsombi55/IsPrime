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
 * THIS IS INCOMPLETE. I wanted to upload this code anyway, as proof that I have tried to code it.
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
			
//			if (isPrime(n)) {Console.WriteLine("Is deletable? " + isDeletable(n));}

			Console.ReadLine();
		}
		
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
		
		private bool IsDeletable(double n){}
	}
}