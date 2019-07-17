using MSCompiler.Lex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSCompiler.Parse
{
	public class Parser
	{
		private int Tab = 0;
		public Tokenizer Tokenizer
		{
			get;
		}
		private Token Token => Tokenizer.Get();
		public Parser(Tokenizer tk)
		{
			Tokenizer = tk;
		}
		private int NextToken()
		{
			return Tokenizer.Next();
		}
		private bool Match(int type)
		{
			if (Token.Type == type)
				return true;
			return false;
		}
		private bool Match(TK_TYPE type)
		{
			return Match((int)type);
		}
		private void Accept(int type)
		{
			if (Token.Type == type)
				NextToken();
			else
				throw new Exception("Faild to match token:" + type);
		}
		private void Accept(TK_TYPE type)
		{
			Accept((int)type);
		}
		private string AcceptName()
		{
			object o = Token.Obj;
			if (Token.Type == (int)TK_TYPE.TK_NAME)
				NextToken();
			else
				throw new Exception("Faild to match TK_NAME");
			return (string)o;
		}
		public void Parse()
		{
			NextToken();
			var fs = GetFunctions();
		}
		private List<Function> GetFunctions()
		{
			List<Function> f = new List<Function>();
			while (Tokenizer.Get().Type != -1)
			{
				f.Add(GetFunction());
			}
			return f;
		}
		private Function GetFunction()
		{
			Accept(TK_TYPE.TK_KW_SCRIPT);
			Function f = new Function(AcceptName());
			Accept('(');
			var nList = GetNameList();
			Accept(')');
			Accept(':');
			Stmt_Block();
			return f;
		}
		private List<string> GetNameList()
		{
			List<string> s = new List<string>();
			if (Match(TK_TYPE.TK_NAME))
			{
				s.Add(AcceptName());
				while (Match(','))
				{
					Accept(',');
					s.Add(AcceptName());
				}
			}
			return s;
		}
		private List<Expression> GetActualArguments()
		{
			List<Expression> s = new List<Expression>();
			Accept('(');
			if (!Match(')'))
			{
				s.Add(E());
				while (Match(','))
				{
					Accept(',');
					s.Add(E());
				}
			}
			Accept(')');
			return s;
		}
		private List<Statement> Stmt_Block()
		{
			List<Statement> s = new List<Statement>();
			Tab++;
			while (true)
			{
				var m = GetStatement();
				if (m == null)
					break;
				s.Add(m);
			}
			Tab--;
			if (s.Count == 0)
			{
				throw new Exception("No statements");
			}
			return s;
		}
		private Statement GetStatement()
		{
			Statement s = null;
			if (Token.Type == -1 || Token.Tab != Tab)
				return null;
			if (Match(TK_TYPE.TK_NAME))
			{
				string Name = AcceptName();
				if (Match('='))
				{
					Accept('=');
					s = new Stmt_Assign()
					{
						Value = E(),
						Name = Name
					};
				}
				else if (Match('('))
				{
					s = new Stmt_Call()
					{
						Args = GetActualArguments(),
						Name = Name
					};
				}
			}
			else if (Match(TK_TYPE.TK_KW_IF))
			{
				return GetIF();
			}
			else if (Match(TK_TYPE.TK_KW_FOR_RANGE))
			{
				return GetForRange();
			}
			else if (Match(TK_TYPE.TK_KW_FOR_RANGE_BACK))
			{
				return GetForRange_Back();
			}
			return s;
		}

		private Stmt_ForRange GetForRange()
		{
			Stmt_ForRange s = new Stmt_ForRange();
			Accept(TK_TYPE.TK_KW_FOR_RANGE);
			string indexer = AcceptName();
			Accept(TK_TYPE.TK_KW_IN);
			s.Lower_Bound = E();
			Accept(TK_TYPE.TK_KW_TO);
			s.Upper_Bound = E();
			Accept(':');
			s.Body = Stmt_Block();
			return s;
		}

		private Stmt_ForRange_Back GetForRange_Back()
		{
			Stmt_ForRange_Back s = new Stmt_ForRange_Back();
			Accept(TK_TYPE.TK_KW_FOR_RANGE_BACK);
			string indexer = AcceptName();
			Accept(TK_TYPE.TK_KW_IN);
			s.Lower_Bound = E();
			Accept(TK_TYPE.TK_KW_TO);
			s.Upper_Bound = E();
			Accept(':');
			s.Body = Stmt_Block();
			return s;
		}

		private Stmt_IF GetIF()
		{
			Stmt_IF s = new Stmt_IF();
			s.IF = new List<Stmt_IF.IFStructure>();
			Accept(TK_TYPE.TK_KW_IF);
			Expression con = E();
			Accept(':');
			List<Statement> b = Stmt_Block();
			s.IF.Add(new Stmt_IF.IFStructure(con, b));

			while (Match(TK_TYPE.TK_KW_ELSEIF))
			{
				Accept(TK_TYPE.TK_KW_ELSEIF);
				Expression con1 = E();
				Accept(':');
				List<Statement> b1 = Stmt_Block();
				s.IF.Add(new Stmt_IF.IFStructure(con1, b1));
			}
			if (Match(TK_TYPE.TK_KW_ELSE))
			{
				Accept(TK_TYPE.TK_KW_ELSE);
				Accept(':');
				s.Else = Stmt_Block();
			}
			return s;
		}


		private Expression E()
		{
			Expression left = D();
			Expr_Binary eb = E1(left);
			return eb == null ? left : eb;
		}

		private Expr_Binary E1(Expression left)
		{
			if (Match((int)TK_TYPE.TK_OP_L_AND))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = D();
				eb.Operator = "&&";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = E1(eb);
				return eb1 == null ? eb : eb1;
			}
			else if (Match((int)TK_TYPE.TK_OP_L_OR))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = D();
				eb.Operator = "||";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = E1(eb);
				return eb1 == null ? eb : eb1;
			}
			return null;
		}

		private Expression D()
		{
			Expression left = R();
			Expr_Binary eb = D1(left);
			return eb ?? left;
		}

		private Expr_Binary D1(Expression left)
		{
			if (Match((int)TK_TYPE.TK_OP_EQ))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = R();
				eb.Operator = "==";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = D1(eb);
				return eb1 ?? eb;
			}
			else if (Match((int)TK_TYPE.TK_OP_GE))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = R();
				eb.Operator = ">=";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = D1(eb);
				return eb1 ?? eb;
			}
			else if (Match((int)TK_TYPE.TK_OP_LE))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = R();
				eb.Operator = "<=";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = D1(eb);
				return eb1 ?? eb;
			}
			else if (Match('>'))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = R();
				eb.Operator = ">";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = D1(eb);
				return eb1 ?? eb;
			}
			else if (Match('<'))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = R();
				eb.Operator = "<";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = D1(eb);
				return eb1 ?? eb;
			}
			return null;
		}

		private Expression R()
		{
			Expression left = T();
			Expr_Binary eb = R1(left);
			return eb ?? left;
		}

		private Expr_Binary R1(Expression left)
		{
			if (Match('+'))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = W();
				eb.Operator = "+";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = R1(eb);
				return eb1 ?? eb;
			}
			else if (Match('-'))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = W();
				eb.Operator = "-";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = R1(eb);
				return eb1 ?? eb;
			}
			return null;
		}



		private Expression W()
		{
			Expression left = T();
			Expr_Binary eb = W1(left);
			return eb ?? left;
		}


		private Expr_Binary W1(Expression left)
		{
			if (Match('|'))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = T();
				eb.Operator = "|";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = W1(eb);
				return eb1 ?? eb;
			}
			else if (Match('&'))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = T();
				eb.Operator = "&";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = W1(eb);
				return eb1 ?? eb;
			}
			return null;
		}


		private Expression T()
		{
			Expression left = F();
			Expr_Binary eb = T1(left);
			return eb ?? left;
		}


		private Expr_Binary T1(Expression left)
		{
			if (Match('*'))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = F();
				eb.Operator = "*";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = T1(eb);
				return eb1 ?? eb;
			}
			else if (Match('/'))
			{
				Token t = Token;
				NextToken();
				Expr_Binary eb = new Expr_Binary();
				Expression right = F();
				eb.Operator = "/";
				eb.Left = left;
				eb.Right = right;
				Expr_Binary eb1 = T1(eb);
				return eb1 ?? eb;
			}
			return null;
		}
		private Expression F()//operand
		{
			if (Match('('))
			{
				NextToken();//(
				Expression e = E();
				Accept(')');
				return e;
			}
			else if (Match('-'))
			{
				NextToken();//-
				Expression e = T();//lowest
				Expr_Binary eb = new Expr_Binary();
				eb.Operator = "*";
				eb.Left = e;
				Expr_Value ev = new Expr_Value();
				ev.Value = "-1";
				eb.Right = ev;
				return eb;
			}
			else if (Match((int)TK_TYPE.TK_NUMBER))
			{
				Expr_Value ev = new Expr_Value();
				ev.Value = (string)Token.Obj;
				NextToken();
				return ev;
			}
			else if (Match((int)TK_TYPE.TK_NAME))
			{
				object name = (string)Token.Obj;
				NextToken();//name
				if (Match('('))
				{
					Expr_ValueList eas = new Expr_ValueList();
					eas.ValueList = new List<Expression>();
					return CallFunction((string)name, GetActualArguments());
				}
				else
				{
					Expr_Variable ev = new Expr_Variable();
					ev.Name = (string)name;
					return ev;
				}
			}
			return null;
		}

		private Expr_Call CallFunction(string name, List<Expression> arg)
		{
			return new Expr_Call() { Name = name, Arguments = arg };
		}

		private string ToASMCode()
		{
			StringBuilder code = new StringBuilder();
			return code.ToString();
		}
	}
}
