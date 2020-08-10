using System.IO;
using System.Text;

namespace Code_Validator
{
	public class Validator
	{
		public static bool CheckParanthesis(string code)
		{
			int openParens = 0;

			code = StripComments(code);
			foreach(var c in code)
			{
				if(c == '(')
				{
					openParens++;
				}
				else if(c == ')')
				{
					if(openParens > 0)
					{
						openParens--;
					}
					else
					{
						// Closing paren found before opening paren
						return false;
					}
				}
			}

			return openParens == 0;
		}

		public static string StripComments(string code)
		{
			StringBuilder sb = new StringBuilder();
			using (StringReader sr = new StringReader(code))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					if(!line.Trim().StartsWith(";;"))
					{
						sb.AppendLine(line);
					}
				}
			}

			return sb.ToString();
		}
	}
}
