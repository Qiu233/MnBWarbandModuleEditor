using System;
using System.Text;
using System.IO;

namespace MSCompiler.Lex
{
	public enum TK_TYPE
	{
		TK_FIRST = 128,

		TK_NEWLINE,

		TK_NAME,
		TK_NULL,
		TK_NUMBER,
		TK_STRING,




		TK_OP_LE,       //<=
		TK_OP_GE,       //>=
		TK_OP_EQ,       //==
		TK_OP_NE,       //!=
		TK_OP_L_AND,    //&&
		TK_OP_L_OR,     //||
		TK_OP_LSHIFT,   //<<
		TK_OP_RSHIFT,   //>>


		TK_DE_PLUS_EQ,      //+=
		TK_DE_MINUS_EQ,     //-=
		TK_DE_MUL_EQ,       //*=
		TK_DE_DIV_EQ,       ///=
		TK_DE_LSHIFT_EQ,    //<<=
		TK_DE_RSHIFT_EQ,    //>>=

		TK_KW_SCRIPT,     //script
		TK_KW_IN,           //in
		TK_KW_TO,           //to
		TK_KW_RETURN,       //return
		TK_KW_IF,           //if
		TK_KW_ELSEIF,           //elif
		TK_KW_ELSE,     //else
		TK_KW_FOR_RANGE,           //for_range
		TK_KW_FOR_RANGE_BACK,           //for_range_back
		TK_KW_FOR_PARTIES,           //for_parties
		TK_KW_FOR_AGENTS,           //for_agents
		TK_KW_FOR_PROP_INSTANCES,           //for_prop_instances
		TK_KW_FOR_PLAYERS,           //for_players




		TK_KW_P_INCLUDE,    //include
	};
	public class Tokenizer
	{
		private int Tab = 0;
		private TextReader tr;
		private char ch;
		public int line, inside_couples, inside_block;
		private Token token;
		public const int ERR_LEX_INVALID_CHARACTER = -1;
		public const int ERR_LEX_END_OF_FILE = -2;
		public const int ERR_LEX_UNAVAILABLE_ESC = -3;
		public Token Get()
		{
			return token;
		}
		public Tokenizer(TextReader tr)
		{
			this.tr = tr;
			inside_block = 0;
			inside_couples = 0;
			ch = (char)tr.Read();
		}
		private void Nextc()
		{
			ch = (char)tr.Read();
		}
		private int Get_Token_1(int eq, int n1, int n2)
		{
			int def = ch;
			Nextc();
			if (ch == '=')
			{
				Nextc();
				return eq;
			}
			else if (ch == def)
			{
				Nextc();
				if (ch == '=')
				{
					Nextc();
					return n2;
				}
				return n1;
			}
			return def;
		}
		private int Get_Token_2(int eq)
		{
			int def = ch;
			Nextc();
			if (ch == '=')
			{
				Nextc();
				return eq;
			}
			return def;
		}
		public int Next()
		{
			token = new Token();
			{
				while (ch == '#')//注释
				{
					Nextc();
					while (ch != -1 && ch != '\n')
						Nextc();
					Nextc();
					Tab = 0;
				}
			}
			#region 处理空白符，Token开头
			{
				bool flag = true;
				while (flag)
				{
					switch (ch)
					{
						case '\n':
							Nextc();
							line++;
							Tab = 0;
							break;
						case '\r':
							Nextc();
							break;
						case ' ':
						case '\t':
							Nextc();
							Tab++;
							break;
						default:
							flag = false;
							break;
					}
				}
			}
			token.Tab = Tab;
			#endregion
			#region 处理正常的Token
			{
				while (true)
				{
					if ((Int16)ch == -1)
					{
						token.Type = -1;
						return ERR_LEX_END_OF_FILE;
					}
					switch (ch)
					{
						case '(':
						case '[':
							token.Type = ch;
							Nextc();
							inside_couples++;
							return 0;
						case ')':
						case ']':
							token.Type = ch;
							Nextc();
							inside_couples--;
							return 0;
						case '{':
							token.Type = ch;
							Nextc();
							inside_block++;
							return 0;
						case '}':
							token.Type = ch;
							Nextc();
							inside_block--;
							return 0;

						case '&':
							Nextc();
							if (ch == '&')
							{
								token.Type = (int)TK_TYPE.TK_OP_L_AND;
								Nextc();
								return 0;
							}
							token.Type = '&';
							return 0;
						case '|':
							Nextc();
							if (ch == '|')
							{
								token.Type = (int)TK_TYPE.TK_OP_L_OR;
								Nextc();
								return 0;
							}
							token.Type = '|';
							return 0;
						case ',':
						case '.':
						case '^':
						case ';':
						case ':':
						case '?':
							token.Type = ch;
							Nextc();
							return 0;
						case '<':
							token.Type = Get_Token_1((int)TK_TYPE.TK_OP_LE, (int)TK_TYPE.TK_OP_LSHIFT, (int)TK_TYPE.TK_DE_LSHIFT_EQ);
							return 0;
						case '>':
							token.Type = Get_Token_1((int)TK_TYPE.TK_OP_GE, (int)TK_TYPE.TK_OP_RSHIFT, (int)TK_TYPE.TK_DE_RSHIFT_EQ);
							return 0;
						case '+':
							token.Type = Get_Token_2((int)TK_TYPE.TK_DE_PLUS_EQ);
							return 0;
						case '-':
							token.Type = Get_Token_2((int)TK_TYPE.TK_DE_MINUS_EQ);
							return 0;
						case '*':
							token.Type = Get_Token_2((int)TK_TYPE.TK_DE_MUL_EQ);
							return 0;
						case '/':
							Nextc();
							if (ch == '=')
							{
								Nextc();
								token.Type = ch;
								return 0;
							}
							else
							{
								token.Type = '/';
								return 0;
							}
						case '=':
							token.Type = Get_Token_2((int)TK_TYPE.TK_OP_EQ);
							return 0;
						case '!':
							Nextc();
							if (ch != '=') return ERR_LEX_INVALID_CHARACTER;
							Nextc();
							token.Type = (int)TK_TYPE.TK_OP_NE;
							return 0;
						case '0':
						case '1':
						case '2':
						case '3':
						case '4':
						case '5':
						case '6':
						case '7':
						case '8':
						case '9':
							{
								StringBuilder sb = new StringBuilder(50);
								do
								{
									sb.Append(ch);
									Nextc();
									if (ch == '.')
									{
										sb.Append('.');
										Nextc();
									}
								} while (char.IsDigit(ch));
								token.Type = (int)TK_TYPE.TK_NUMBER;
								token.Obj = sb.ToString();
								return 0;
							}
						case '\"':
							{
								Nextc();
								StringBuilder sb = new StringBuilder(1024);
								while (ch != '\"')
								{
									char c = ch;
									if (ch == '\\')
									{
										Nextc();
										switch (ch)
										{
											case 'n':
												c = '\n';
												break;
											case '\\':
												c = '\\';
												break;
											case 'r':
												c = '\r';
												break;
											case 't':
												c = '\t';
												break;
											case '\"':
												c = '\"';
												break;
											case '\'':
												c = '\'';
												break;
											default:
												return ERR_LEX_UNAVAILABLE_ESC;
										}
									}
									sb.Append(c);
									Nextc();
								}
								Nextc();//pass '\"'
								token.Type = (int)TK_TYPE.TK_STRING;
								token.Obj = sb.ToString();
								return 0;
							}
						default:
							if (char.IsLetter(ch))
							{
								StringBuilder sb = new StringBuilder(50);
								do
								{
									sb.Append(ch);
									Nextc();
								} while (char.IsLetter(ch) || char.IsDigit(ch) || ch == '_' || ch == '$');
								token.Obj = sb.ToString();
								switch ((string)token.Obj)
								{
									case "script":
										token.Type = (int)TK_TYPE.TK_KW_SCRIPT;
										break;
									case "in":
										token.Type = (int)TK_TYPE.TK_KW_IN;
										break;
									case "to":
										token.Type = (int)TK_TYPE.TK_KW_TO;
										break;
									case "return":
										token.Type = (int)TK_TYPE.TK_KW_RETURN;
										break;
									case "for_range":
										token.Type = (int)TK_TYPE.TK_KW_FOR_RANGE;
										break;
									case "for_range_back":
										token.Type = (int)TK_TYPE.TK_KW_FOR_RANGE_BACK;
										break;
									case "for_parties":
										token.Type = (int)TK_TYPE.TK_KW_FOR_PARTIES;
										break;
									case "for_agents":
										token.Type = (int)TK_TYPE.TK_KW_FOR_AGENTS;
										break;
									case "for_prop_instances":
										token.Type = (int)TK_TYPE.TK_KW_FOR_PROP_INSTANCES;
										break;
									case "for_players":
										token.Type = (int)TK_TYPE.TK_KW_FOR_PLAYERS;
										break;
									case "if":
										token.Type = (int)TK_TYPE.TK_KW_IF;
										break;
									case "elif":
										token.Type = (int)TK_TYPE.TK_KW_ELSEIF;
										break;
									case "else":
										token.Type = (int)TK_TYPE.TK_KW_ELSE;
										break;
									default:
										token.Type = (int)TK_TYPE.TK_NAME;
										break;
								}
								return 0;
							}
							return ERR_LEX_INVALID_CHARACTER;
					}
				}
			}
			#endregion
		}
	}
}

