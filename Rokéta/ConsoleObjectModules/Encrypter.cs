using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules
{
	public static class Encrypter
	{
		public static string Encrypt(string line)
		{
			//abc;def;ghj
			int len = line.Length;
			string[] segments = line.Split(';');
			len -= segments.Length - 1;
			string key = getKey(len);
			char splitKey = (char)(line.Length * 25);
			int index = 0;
			string newLine = string.Empty;
			for (int i = 0; i < segments.Length; i++)
			{
				for(int j = 0; j < segments[i].Length; j++)
				{
					if(j % 2 + i % 2 == 0)
					{
						newLine += (char)(segments[i][j] + key[index % key.Length]);
					}
					else
					{
						newLine += (char)(segments[i][j] - key[index % key.Length]);
					}
					index++;
				}
				if (i != segments.Length - 1) newLine += splitKey;


			}
			string outLine = string.Empty;
			for (int i = 0; i < newLine.Length; i++)
			{
				outLine += (char)((int)newLine[i] + i);
			}
			return outLine;
		}
		public static void test(string testString)
		{
			Debug.WriteLine(Encrypt(Decrypt(testString)));
		}
		public static string Decrypt(string line)
		{
			string startLine = string.Empty;
			for (int i = 0; i < line.Length; i++)
			{
				startLine += (char)((int)line[i] - i);
			}
			char splitKey = (char)(startLine.Length * 25);
			string[] segments = startLine.Split(splitKey);
			int len = startLine.Length;
			len -= segments.Length - 1;
           

            string key = getKey(len);
			string newLine = string.Empty;
			int index = 0;
			for (int i = 0; i < segments.Length; i++)
			{
				for (int j = 0; j < segments[i].Length; j++)
				{
					if (j % 2 + i % 2 == 0)
					{
						newLine += (char)(segments[i][j] - key[index%key.Length]);
					}
					else
					{
						newLine += (char)(segments[i][j] + key[index%key.Length]);
					}
					index++;
				}
				if (i != segments.Length - 1)
				{
					newLine += ';';
				}

			}
			return newLine;
		}
		private static string getKey(int length)
		{
			return getKeyExtra(getKeyNormal(length%50));
		}
		private static string getKeyNormal(int length)
		{
			BigInteger key = 1;
			while (key.ToString().Length != length)
			{
				if (key.ToString().Length < length) key *= key + 1;
				else if (key.ToString().Length > length) key /= 10;
				if (key.ToString().Length > length / 7)
				{
					if (length % key.ToString().Length == 0)
					{
						string outKey = key.ToString();
						for (int i = 0; i < length / key.ToString().Length - 1; i++) outKey += key.ToString();
						return outKey;
					}
				}

			}

			return key.ToString();
		}
		private static string getKeyExtra(string key)
		{
			string newKey = string.Empty;
			for(int i = 0;i < key.Length;i++)
			{
				newKey += (key[i] + i) % 10;
			}
			newKey.Reverse();
			return newKey;
		}
	}
}
