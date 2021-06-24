
namespace Juego_rol
{
    partial class formCrearPersonaje
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCrearPersonaje));
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApodo = new System.Windows.Forms.Label();
            this.labelTipo = new System.Windows.Forms.Label();
            this.labelNac = new System.Windows.Forms.Label();
            this.btRellenarRandom = new System.Windows.Forms.Button();
            this.btCrearPersonaje = new System.Windows.Forms.Button();
            this.dTPFechaNac = new System.Windows.Forms.DateTimePicker();
            this.labelCrearPersonaje = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApodo = new System.Windows.Forms.TextBox();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.BackColor = System.Drawing.Color.Transparent;
            this.labelNombre.Font = new System.Drawing.Font("Centaur", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(255)))), ((int)(((byte)(54)))));
            this.labelNombre.Location = new System.Drawing.Point(36, 75);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(69, 21);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "Nombre";
            // 
            // labelApodo
            // 
            this.labelApodo.AutoSize = true;
            this.labelApodo.BackColor = System.Drawing.Color.Transparent;
            this.labelApodo.Font = new System.Drawing.Font("Centaur", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelApodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(255)))), ((int)(((byte)(54)))));
            this.labelApodo.Location = new System.Drawing.Point(47, 108);
            this.labelApodo.Name = "labelApodo";
            this.labelApodo.Size = new System.Drawing.Size(58, 21);
            this.labelApodo.TabIndex = 1;
            this.labelApodo.Text = "Apodo";
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.BackColor = System.Drawing.Color.Transparent;
            this.labelTipo.Font = new System.Drawing.Font("Centaur", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(255)))), ((int)(((byte)(54)))));
            this.labelTipo.Location = new System.Drawing.Point(59, 150);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(46, 21);
            this.labelTipo.TabIndex = 2;
            this.labelTipo.Text = "Tipo";
            // 
            // labelNac
            // 
            this.labelNac.AutoSize = true;
            this.labelNac.BackColor = System.Drawing.Color.Transparent;
            this.labelNac.Font = new System.Drawing.Font("Centaur", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(255)))), ((int)(((byte)(54)))));
            this.labelNac.Location = new System.Drawing.Point(12, 192);
            this.labelNac.Name = "labelNac";
            this.labelNac.Size = new System.Drawing.Size(93, 21);
            this.labelNac.TabIndex = 3;
            this.labelNac.Text = "Nacimiento";
            // 
            // btRellenarRandom
            // 
            this.btRellenarRandom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(168)))), ((int)(((byte)(9)))));
            this.btRellenarRandom.Font = new System.Drawing.Font("Centaur", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btRellenarRandom.ForeColor = System.Drawing.Color.White;
            this.btRellenarRandom.Location = new System.Drawing.Point(227, 251);
            this.btRellenarRandom.Name = "btRellenarRandom";
            this.btRellenarRandom.Size = new System.Drawing.Size(112, 49);
            this.btRellenarRandom.TabIndex = 4;
            this.btRellenarRandom.Text = "Rellenar aleatorio";
            this.btRellenarRandom.UseVisualStyleBackColor = false;
            this.btRellenarRandom.Click += new System.EventHandler(this.btRellenarRandom_Click);
            // 
            // btCrearPersonaje
            // 
            this.btCrearPersonaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(168)))), ((int)(((byte)(9)))));
            this.btCrearPersonaje.Font = new System.Drawing.Font("Centaur", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btCrearPersonaje.ForeColor = System.Drawing.Color.White;
            this.btCrearPersonaje.Location = new System.Drawing.Point(97, 251);
            this.btCrearPersonaje.Name = "btCrearPersonaje";
            this.btCrearPersonaje.Size = new System.Drawing.Size(124, 49);
            this.btCrearPersonaje.TabIndex = 5;
            this.btCrearPersonaje.Text = "Crear personaje";
            this.btCrearPersonaje.UseVisualStyleBackColor = false;
            this.btCrearPersonaje.Click += new System.EventHandler(this.btCrearPersonaje_Click);
            // 
            // dTPFechaNac
            // 
            this.dTPFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPFechaNac.Location = new System.Drawing.Point(111, 190);
            this.dTPFechaNac.Name = "dTPFechaNac";
            this.dTPFechaNac.Size = new System.Drawing.Size(213, 23);
            this.dTPFechaNac.TabIndex = 6;
            this.dTPFechaNac.Value = new System.DateTime(2021, 6, 23, 0, 0, 0, 0);
            // 
            // labelCrearPersonaje
            // 
            this.labelCrearPersonaje.AutoSize = true;
            this.labelCrearPersonaje.BackColor = System.Drawing.Color.Transparent;
            this.labelCrearPersonaje.Font = new System.Drawing.Font("Euphorigenic", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCrearPersonaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(27)))), ((int)(((byte)(245)))));
            this.labelCrearPersonaje.Location = new System.Drawing.Point(12, 20);
            this.labelCrearPersonaje.Name = "labelCrearPersonaje";
            this.labelCrearPersonaje.Size = new System.Drawing.Size(221, 42);
            this.labelCrearPersonaje.TabIndex = 7;
            this.labelCrearPersonaje.Text = "Crear Personaje";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(111, 76);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(213, 23);
            this.txtNombre.TabIndex = 8;
            // 
            // txtApodo
            // 
            this.txtApodo.Location = new System.Drawing.Point(111, 109);
            this.txtApodo.Name = "txtApodo";
            this.txtApodo.Size = new System.Drawing.Size(213, 23);
            this.txtApodo.TabIndex = 9;
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Items.AddRange(new object[] {
            "Elfo",
            "Hada",
            "Humano",
            "Mago",
            "Orco"});
            this.comboBoxTipo.Location = new System.Drawing.Point(111, 148);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(213, 23);
            this.comboBoxTipo.TabIndex = 11;
            // 
            // formCrearPersonaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(341, 342);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.txtApodo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelCrearPersonaje);
            this.Controls.Add(this.dTPFechaNac);
            this.Controls.Add(this.btCrearPersonaje);
            this.Controls.Add(this.btRellenarRandom);
            this.Controls.Add(this.labelNac);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.labelApodo);
            this.Controls.Add(this.labelNombre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formCrearPersonaje";
            this.Text = "Personaje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApodo;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.Label labelNac;
        private System.Windows.Forms.Button btRellenarRandom;
        private System.Windows.Forms.Button btCrearPersonaje;
        private System.Windows.Forms.DateTimePicker dTPFechaNac;
        private System.Windows.Forms.Label labelCrearPersonaje;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApodo;
        private System.Windows.Forms.ComboBox comboBoxTipo;
    }
}

