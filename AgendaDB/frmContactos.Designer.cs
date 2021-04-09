
namespace AgendaDB
{
    partial class frmContactos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProbarConexion = new System.Windows.Forms.Button();
            this.dtvContactos = new System.Windows.Forms.DataGridView();
            this.btnConsutaContactos = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarContacto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtvContactos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProbarConexion
            // 
            this.btnProbarConexion.Location = new System.Drawing.Point(12, 15);
            this.btnProbarConexion.Name = "btnProbarConexion";
            this.btnProbarConexion.Size = new System.Drawing.Size(132, 23);
            this.btnProbarConexion.TabIndex = 0;
            this.btnProbarConexion.Text = "Probar conexión";
            this.btnProbarConexion.UseVisualStyleBackColor = true;
            this.btnProbarConexion.Click += new System.EventHandler(this.btnProbarConexion_Click);
            // 
            // dtvContactos
            // 
            this.dtvContactos.AllowUserToAddRows = false;
            this.dtvContactos.AllowUserToDeleteRows = false;
            this.dtvContactos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvContactos.Location = new System.Drawing.Point(12, 62);
            this.dtvContactos.Name = "dtvContactos";
            this.dtvContactos.ReadOnly = true;
            this.dtvContactos.Size = new System.Drawing.Size(810, 394);
            this.dtvContactos.TabIndex = 1;
            this.dtvContactos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtvContactos_CellDoubleClick);
            // 
            // btnConsutaContactos
            // 
            this.btnConsutaContactos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsutaContactos.Location = new System.Drawing.Point(597, 462);
            this.btnConsutaContactos.Name = "btnConsutaContactos";
            this.btnConsutaContactos.Size = new System.Drawing.Size(225, 23);
            this.btnConsutaContactos.TabIndex = 2;
            this.btnConsutaContactos.Text = "Consultar contactos inactivos";
            this.btnConsutaContactos.UseVisualStyleBackColor = true;
            this.btnConsutaContactos.Click += new System.EventHandler(this.btnConsutaContactos_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(540, 15);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(213, 16);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(321, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre";
            // 
            // btnAgregarContacto
            // 
            this.btnAgregarContacto.Location = new System.Drawing.Point(697, 15);
            this.btnAgregarContacto.Name = "btnAgregarContacto";
            this.btnAgregarContacto.Size = new System.Drawing.Size(125, 23);
            this.btnAgregarContacto.TabIndex = 6;
            this.btnAgregarContacto.Text = "Agregar contacto";
            this.btnAgregarContacto.UseVisualStyleBackColor = true;
            this.btnAgregarContacto.Click += new System.EventHandler(this.btnAgregarContacto_Click);
            // 
            // frmContactos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 513);
            this.Controls.Add(this.btnAgregarContacto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnConsutaContactos);
            this.Controls.Add(this.dtvContactos);
            this.Controls.Add(this.btnProbarConexion);
            this.Name = "frmContactos";
            this.Text = "Contactos";
            ((System.ComponentModel.ISupportInitialize)(this.dtvContactos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProbarConexion;
        private System.Windows.Forms.DataGridView dtvContactos;
        private System.Windows.Forms.Button btnConsutaContactos;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarContacto;
    }
}