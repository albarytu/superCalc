using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
 * 
 * comando	= <operacion>
 *				
 * operacion =	<numero>
 *				<numero> <operador> <operacion>
 *				<variable>
 *				<variable> <operadorVariable> <operacion>
 *			   ( <operacion> )
 *			   ( <operacion> ) <operador> <operacion>
 * 
 * numero = <partedecimal>
 *			<partedecimal> , <partedecimal>
 *			<partedecimal> . <partedecimal>
 * 
 * variable = <letra>
 * 
 * partedecimal = <digitos>
 * 
 * operadorVariable = <operador>
 *					  '='
 * 
 * operador =	'+'
 *				'/'
 *				'-'
 *				'*'
 * 
 * */

namespace SuperCalc
{
	public partial class Form1 : Form
	{
		class NotValidObject : Exception
		{
		}
		class EndOfString: Exception
		{
		}

		public Form1()
		{
			InitializeComponent();
		}

		class TextoAParsear
		{
			public string texto;
			public TextoAParsear(string t)
			{
				texto = t.Replace(" ", "");
			}
			public char GetChar()
			{
				if (Vacio()) throw new EndOfString();
				return texto[0];
			}
			public void CharProcessed()
			{
				texto = texto.Substring(1);
			}
			public bool Vacio()
			{
				return (texto.Length == 0);
			}
		}

		class Operador
		{
			private char operando;
			public Operador(TextoAParsear t)
			{
				operando = ' ';
				try
				{
					if (t.Vacio()) throw new NotValidObject();
					char c = t.GetChar();
					switch (c)
					{
						case '+':
						case '-':
						case '/':
						case '*':
							operando = c;
							t.CharProcessed();
							return;
					}
					throw new NotValidObject();
				}
				catch (EndOfString eos)
				{
					throw new NotValidObject();
				}
			}
			public double Opera(double izq, double der)
			{
				if (operando == ' ') return izq;
				switch (operando)
				{
					case '+':
						return izq + der;
						break;
					case '-':
						return izq - der;
						break;
					case '/':
						return izq / der;
						break;
					case '*':
						return izq * der;
						break;
				}
				return izq;
			}
		}
		class OperadorVariable
		{
			private bool isAssignment;
			Operador op;
			public OperadorVariable(TextoAParsear t)
			{
				if (t.Vacio()) throw new NotValidObject();
				char c = t.GetChar();
				if (c=='=')
				{
					isAssignment = true;
					op = null;
					t.CharProcessed();
				} else {
					op = new Operador(t);
				}
			}
			public double Opera(Variable izq, double der)
			{
				if (!isAssignment)
				{
					double i = izq.Valor();
					return op.Opera(i, der);
				}
				else {
					izq.AsignarValor(der);
					return der;
				}
			}
		}
		class ParteDecimal
		{
			private string valor;
			public ParteDecimal()
			{
				valor = "";
			}
			public ParteDecimal(TextoAParsear t)
			{
				valor = "";
				try
				{
					while (true)
					{
						char c = t.GetChar();
						switch (c)
						{
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
								valor = valor + c;
								t.CharProcessed();
								break;
							default:
								return;
						}
					}
				}
				catch (EndOfString eos)
				{
					return;
				}
			}

			public string Valor()
			{
				return valor;
			}
		}
		class Numero
		{
			public ParteDecimal parteentera;
			public ParteDecimal partedecimal;
			public Numero(TextoAParsear t)
			{
				parteentera = new ParteDecimal();
				partedecimal = new ParteDecimal();
				try
				{
					parteentera = new ParteDecimal(t);
					char c = t.GetChar();
					if ((c == ',') || (c == '.'))
					{
						t.CharProcessed();
						partedecimal = new ParteDecimal(t);
					}
				}
				catch (EndOfString eos)
				{
					return;
				}
			}

			public double Valor()
			{
				string n = "0" + parteentera.Valor() + "," + partedecimal.Valor() + "0";
				return Convert.ToDouble(n);
			}
		}
		class Operacion
		{
			public Operacion OpIzquierda;
			
			public Numero NumIzquierda;

			public Variable VarIzquierda;

			public Operador operador;
			public OperadorVariable operadorv;
			public Operacion derecha;

			public Operacion(TextoAParsear t)
			{
				VarIzquierda = null;
				OpIzquierda = null;
				NumIzquierda = null;

				operador = null;
				operadorv = null;

				derecha = null;

				try
				{
					char c = t.GetChar();
					if (c == '(')
					{
						t.CharProcessed();
						OpIzquierda = new Operacion(t);
						c = t.GetChar();
						if (c == ')')
						{
							t.CharProcessed();
						}
					}
					else
					{
						try
						{
							VarIzquierda = new Variable(t);
						} catch ( NotValidObject )
						{
							NumIzquierda = new Numero(t);
						}
					}
					if (VarIzquierda == null)
					{
						operador = new Operador(t);
					}
					else {
						operadorv = new OperadorVariable(t);
					}
					derecha = new Operacion(t);
				}
				catch (EndOfString eos)
				{
					return;
				}
				catch (NotValidObject nvo)
				{
					return;
				}
			}
			public double Evalua()
			{
				double izq = 0;
				double der = 0;
				
				if (derecha != null)
				{
					der = derecha.Evalua();
				}

				if (VarIzquierda != null)
				{
					if (operadorv != null)
					{
						return operadorv.Opera(VarIzquierda, der);
					} else {
						return VarIzquierda.Valor();
					}
				} else if (OpIzquierda != null)
				{
					izq = OpIzquierda.Evalua();
				} else if (NumIzquierda != null)
				{
					izq = NumIzquierda.Valor();
				} 

				if (operador != null)
				{
					return operador.Opera(izq, der);
				}
				else {
					return izq;
				}
			}
		}

		class VarValue
		{
			public static List<VarValue> lista = new List<VarValue>();			

			public char nombre;
			public double value;

			private VarValue(char n, double v)
			{
				nombre = n;
				value = v;
			}
			public static VarValue FindVar(char n)
			{
				foreach (VarValue v in lista)
				{
					if (v.nombre == n)
					{
						return v;
					}
				}
				VarValue w = new VarValue(n, 0);
				lista.Add(w);
				return w;
			}

		}
		class Variable
		{
			public VarValue ValueObject;

			public Variable(TextoAParsear t)
			{
				char c = t.GetChar();
				switch (c)
				{
					case 'a':
					case 'b':
					case 'c':
					case 'd':
					case 'e':
					case 'f':
					case 'g':
					case 'h':
					case 'i':
					case 'j':
					case 'k':
					case 'l':
					case 'm':
					case 'n':
					case 'o':
					case 'p':
					case 'q':
					case 'r':
					case 's':
					case 't':
					case 'v':
					case 'w':
					case 'x':
					case 'y':
					case 'z':
						t.CharProcessed();

						ValueObject = VarValue.FindVar(c);

						return;
				}
				throw new NotValidObject();
			}
			public string Nombre()
			{
				return ValueObject.nombre.ToString();
			}
			public double Valor()
			{
				return ValueObject.value;
			}
			public void AsignarValor(double v)
			{
				ValueObject.value = v;
			}
		}

		

		private void run_Click(object sender, EventArgs e)
		{
			string ope = operacion.Text;

			if (ope == "clean")
			{
				log.Text = "";
				operacion.Text = "";
				VarValue.lista.Clear();
				listaVariables.Text = "";
				return;
			}
			
			log.Text += ope + " = ";

			string result;
			try
			{
				TextoAParsear tmp = new TextoAParsear(ope);
				Operacion op = new Operacion(tmp);
				if (!tmp.Vacio())
				{
					throw new Exception("Error de sintaxis");
				}
				result = op.Evalua().ToString();


				log.Text += result + "\r\n";

				log.SelectionStart = log.Text.Length;
				log.SelectionLength = 0;
				log.ScrollToCaret();
				log.SelectAll();

				operacion.Text = "(" + result + ")";
				operacion.SelectionStart = operacion.Text.Length;
				operacion.SelectionLength = 0;

				listaVariables.Clear();
				foreach (VarValue val in VarValue.lista)
				{
					listaVariables.Text += val.nombre.ToString() + ": " + val.value.ToString() + "\r\n";
				}
			}
			catch (Exception ex)
			{
				log.Text += "\r\n" + ex.Message + "\r\n\r\n";
			}
			operacion.Focus();
		}

		private void clear_Click(object sender, EventArgs e)
		{
			operacion.Text = "";
			operacion.Focus();
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F12)
			{
				calc();
			}
		}

		private void calc()
		{
			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			proc.EnableRaisingEvents = false;
			proc.StartInfo.FileName = "calc";
			proc.Start();
			operacion.Focus();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			calc();
			operacion.Focus();
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			operacion.Focus();
		}

	}
}