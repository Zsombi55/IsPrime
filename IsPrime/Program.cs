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
using System.Text;

namespace IsPrime
{
	class Program
	{
		public static void Main(string[] args)
		{
			Program P = new Program();
			double number = -0053743045.100; // Test, length: 9.  Prime?: true | Deletable?: true, viable routes: 3.
			
/* - while testing.
			
  			Console.WriteLine("Enter number (valid symbols are the negative & decimal markers):");
			string data = Console.ReadLine();
			
			if(Double.TryParse(data, out number)) // Validity check; also removes unnecesary zeroes.
				Console.WriteLine("Is  {0}  a prime? {1}.\r\n", number, P.IsPrime(number));				
			else
				Console.WriteLine("'{0}' is not a valid number.", data);
*/
			Console.WriteLine("Is  {0}  a prime? {1}.\r\n", number, P.IsPrime(number)); // - Test.
			
			if (P.IsPrime(number)) {
				P.HowLong(number);
				Console.WriteLine("Is deletable? {0}", P.IsDeletable(number));
			}

			Console.ReadKey();
//			EndApp();
		}

		private void HowLong(double n) { // check 'data' instead after test !
			string sn = n.ToString();
			int length = sn.Length;
			if(sn.Contains("-")) length--;
			if(sn.Contains(",")) length--;
			if(sn.Contains(".")) length--;
			Console.WriteLine("Length: {0}", length);
		}
		
//TODO: either in HowLong or below : remove decimal & minus markers before truncating to make it easier
//			there is no Math done that would make a differnce in the outcome,
//			unless one wishes to display all viable route elements, then they would need to be put back..
//			or just skip them during truncating upon encountering them under the "target index" of the respective loop cycle ??

//TODO: so far it performs only "1st level" check.. the viable elements of it are not checked.
//			Each ok element has to be stored then later ran through the same check.. and so on
//			until there are no more viable routes OR all single digit ones have been checked.
//		It's basically like building a tree graph with the start node being the user given value and all child/leaf nodes the viable elements.
	
		private void TruncateLeft(string s) { // truncate sequence from left
			int le = s.Length;
			for (int i = 0; i < le; ++i) {
				StringBuilder sb = new StringBuilder(s);
				sb.Remove(i, 1);
				Console.WriteLine(sb);
			}
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
		
// ----- Is Deletable -----

		private bool IsDeletable(double n) {
			string s = n.ToString();
			bool d = true;
			
			TruncateLeft(s);

			if (!d) {
				d = false;
			}
			return d;
		}
	}
}