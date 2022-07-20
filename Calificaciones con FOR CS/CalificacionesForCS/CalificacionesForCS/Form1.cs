using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace CalificacionesForCS
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}



		private int numCantidad;
		private double numInput;
		private double numProm;
		private string numEntrada;


		private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((txtCantidad.Text ?? "") == (string.Empty ?? ""))
			{
				e.Handled = !char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar) & !(Conversions.ToString(e.KeyChar) == ".") & !(Conversions.ToString(e.KeyChar) == "-");
			}
			else if (!txtCantidad.Text.Contains("."))
			{
				e.Handled = !char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar) & !(Conversions.ToString(e.KeyChar) == ".");
			}
			else if (!txtCantidad.Text.Contains("-"))
			{
				e.Handled = !char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar) & !(Conversions.ToString(e.KeyChar) == "-");
			}
			else if (txtCantidad.Text.Contains(".") & txtCantidad.Text.Contains("-"))
			{
				e.Handled = !char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{

			if ((!string.IsNullOrEmpty(txtCantidad.Text)) && (!string.IsNullOrEmpty(txtCantidad.Text)))
			{

				if (LikeOperator.LikeString(txtCantidad.Text, "*.*-*", CompareMethod.Binary) | LikeOperator.LikeString(txtCantidad.Text, "0", CompareMethod.Binary) | LikeOperator.LikeString(txtCantidad.Text, "*-*", CompareMethod.Binary) | LikeOperator.LikeString(txtCantidad.Text, "*.*", CompareMethod.Binary) | LikeOperator.LikeString(txtCantidad.Text, "-", CompareMethod.Binary) | LikeOperator.LikeString(txtCantidad.Text, "-.", CompareMethod.Binary))
				{
					MessageBox.Show("Valor invalido");
					return;
				}


				numInput = 0;
				var notas = new string[(int)(Conversion.Val(txtCantidad.Text) - 1) + 1];
				numCantidad = Convert.ToInt32(txtCantidad.Text);


				foreach (var nota in notas)
				{
					numEntrada = Interaction.InputBox("Calificacion (base 10)" + ": ");
					numInput = Conversion.Val(numEntrada);
					if (Information.IsNumeric(numEntrada))
					{
						if (Conversions.ToDouble(numEntrada) > 10)
						{
							MessageBox.Show("Valores invalidos");
							return;
						}

						notas[Convert.ToInt32(nota)] = Convert.ToString(numInput);
					}
					else
					{
						MessageBox.Show("Valores invalidos");
						return;
					}

					numProm += Conversions.ToDouble(notas[Convert.ToInt32(nota)]);



					
				}

				numProm = numProm / numCantidad;
				MessageBox.Show(Convert.ToString(numProm));
				var switchExpr = numProm;
				switch (switchExpr)
				{
					case 10:
						{
							MessageBox.Show("AU");
							break;
						}

					case object _ when 9 <= switchExpr && switchExpr <= 10:
						{
							MessageBox.Show("DE");
							break;
						}

					case object _ when 8 <= switchExpr && switchExpr <= 9:
						{
							MessageBox.Show("SA");
							break;
						}

					default:
						{
							MessageBox.Show("NA");
							break;
						}
				}

				
			}
			numProm = 0;
		}
	}
}
