/*
 * Created by SharpDevelop.
 * User: Zsombor
 * Date: 2020-11-23
 * Time: 09:56
 * 
 * Primes are numbers that can only be divided cleanly by 1 or themselves.
 *  If removing any single digit still results in a prime, and if shrinking it down to one digit
 * it still remains a prime, then the "original" was a deletable prime.
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
			int n = 537430451;
			
			Console.WriteLine("Is prime?" + P.isPrime(int n));
			
//			if (isPrime(n)) {Console.WriteLine("Is deletable? " + isDeletable(n));}

			Console.ReadLine();
		}
		
		private bool isPrime(int n) {
			int sqrtN=Math.floor(Math.sqrt(n));   // no decimals
			bool p = n != 1;     // boolean
			for(int i = 2; i < sqrtN + 1; i++) {
				if(n % i == 0) {
					p = false;
					break;
				}
			}
			return p;
		}
	}
}