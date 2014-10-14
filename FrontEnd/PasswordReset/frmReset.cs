using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.BackServices.Services;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.PasswordReset
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmReset : Form
	{
		private System.Windows.Forms.Label lblUsuario;
		private System.Windows.Forms.Label lblNewPass;
		private System.Windows.Forms.TextBox txtNewPass;
		private System.Windows.Forms.Label lblOtraVez;
		private System.Windows.Forms.TextBox txtOtraVez;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.ComboBox cmbUsuarios;
		private System.Windows.Forms.ErrorProvider epFrmReset;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public frmReset()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblUsuario = new System.Windows.Forms.Label();
			this.cmbUsuarios = new System.Windows.Forms.ComboBox();
			this.lblNewPass = new System.Windows.Forms.Label();
			this.txtNewPass = new System.Windows.Forms.TextBox();
			this.lblOtraVez = new System.Windows.Forms.Label();
			this.txtOtraVez = new System.Windows.Forms.TextBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.epFrmReset = new System.Windows.Forms.ErrorProvider();
			this.SuspendLayout();
			// 
			// lblUsuario
			// 
			this.lblUsuario.AutoSize = true;
			this.lblUsuario.Location = new System.Drawing.Point(8, 8);
			this.lblUsuario.Name = "lblUsuario";
			this.lblUsuario.Size = new System.Drawing.Size(54, 19);
			this.lblUsuario.TabIndex = 0;
			this.lblUsuario.Text = "Usuario:";
			// 
			// cmbUsuarios
			// 
			this.cmbUsuarios.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cmbUsuarios.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbUsuarios.Location = new System.Drawing.Point(8, 24);
			this.cmbUsuarios.Name = "cmbUsuarios";
			this.cmbUsuarios.Size = new System.Drawing.Size(280, 24);
			this.cmbUsuarios.TabIndex = 1;
			// 
			// lblNewPass
			// 
			this.lblNewPass.AutoSize = true;
			this.lblNewPass.Location = new System.Drawing.Point(8, 72);
			this.lblNewPass.Name = "lblNewPass";
			this.lblNewPass.Size = new System.Drawing.Size(107, 19);
			this.lblNewPass.TabIndex = 2;
			this.lblNewPass.Text = "Nuevo Password:";
			// 
			// txtNewPass
			// 
			this.txtNewPass.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNewPass.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.epFrmReset.SetIconAlignment(this.txtNewPass, System.Windows.Forms.ErrorIconAlignment.TopRight);
			this.txtNewPass.Location = new System.Drawing.Point(8, 88);
			this.txtNewPass.Name = "txtNewPass";
			this.txtNewPass.PasswordChar = '*';
			this.txtNewPass.Size = new System.Drawing.Size(272, 23);
			this.txtNewPass.TabIndex = 3;
			this.txtNewPass.Text = "";
			// 
			// lblOtraVez
			// 
			this.lblOtraVez.AutoSize = true;
			this.lblOtraVez.Location = new System.Drawing.Point(8, 120);
			this.lblOtraVez.Name = "lblOtraVez";
			this.lblOtraVez.Size = new System.Drawing.Size(59, 19);
			this.lblOtraVez.TabIndex = 4;
			this.lblOtraVez.Text = "Otra vez:";
			// 
			// txtOtraVez
			// 
			this.txtOtraVez.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtOtraVez.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtOtraVez.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.epFrmReset.SetIconAlignment(this.txtOtraVez, System.Windows.Forms.ErrorIconAlignment.TopRight);
			this.txtOtraVez.Location = new System.Drawing.Point(8, 136);
			this.txtOtraVez.Name = "txtOtraVez";
			this.txtOtraVez.PasswordChar = '*';
			this.txtOtraVez.Size = new System.Drawing.Size(272, 23);
			this.txtOtraVez.TabIndex = 5;
			this.txtOtraVez.Text = "";
			// 
			// btnReset
			// 
			this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReset.Location = new System.Drawing.Point(216, 184);
			this.btnReset.Name = "btnReset";
			this.btnReset.TabIndex = 6;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// epFrmReset
			// 
			this.epFrmReset.ContainerControl = this;
			// 
			// frmReset
			// 
			this.AcceptButton = this.btnReset;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(296, 222);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.txtOtraVez);
			this.Controls.Add(this.lblOtraVez);
			this.Controls.Add(this.txtNewPass);
			this.Controls.Add(this.lblNewPass);
			this.Controls.Add(this.cmbUsuarios);
			this.Controls.Add(this.lblUsuario);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "frmReset";
			this.Text = "Reset Password";
			this.Load += new System.EventHandler(this.frmReset_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmReset());
		}

		private void frmReset_Load(object sender, System.EventArgs e)
		{
			Usuario user = new Usuario();
			cmbUsuarios.DataSource = user.Listar("", false);
			cmbUsuarios.ValueMember = "LoginName";
			cmbUsuarios.DisplayMember = "LoginName";
			cmbUsuarios.Refresh();
		}

		public bool CambiarPassword(string lUserName, string lNewPass)
		{
			bool bolSalida = true;
			StringBuilder strSqlUpdate = new StringBuilder(128);
			strSqlUpdate.Append("Update Usuarios ");
			strSqlUpdate.Append(" Set Password = " + StaticDal.Traduce(Encriptador.HashPassword(lNewPass)));
			strSqlUpdate.Append(" Where LoginName = " + StaticDal.Traduce(lUserName));
			try
			{
				StaticDal.EjecutarComando(strSqlUpdate.ToString());
			}
			catch
			{
				bolSalida = false;
			}
			return bolSalida;
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			if (cmbUsuarios.SelectedItem != null)
			{
				if (txtNewPass.Text != txtOtraVez.Text)
				{
					epFrmReset.SetError(txtNewPass, "Las Passwords deben coincidir...");
					epFrmReset.SetError(txtOtraVez, "Las Passwords deben coincidir...");
				}
				else
				{
					epFrmReset.SetError(txtNewPass, "");
					epFrmReset.SetError(txtOtraVez, "");
					if (MessageBox.Show("Esta a punto de cambiar la password del usuario:" + Environment.NewLine + cmbUsuarios.SelectedValue.ToString(), "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
					{
						if (CambiarPassword(cmbUsuarios.SelectedValue.ToString(), txtNewPass.Text))
							MessageBox.Show("La nueva password fue guardada con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
						else
						{
							MessageBox.Show("No se pudo cambiar la password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							Cancelar();
						}
					}
					else
					{
						Cancelar();
					}
				}

			}
		}

		private void Cancelar()
		{
			txtNewPass.Text = "";
			txtOtraVez.Text = "";
			cmbUsuarios.SelectedIndex = -1;
		
		}

	}
}
