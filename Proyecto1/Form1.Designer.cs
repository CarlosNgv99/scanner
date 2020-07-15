namespace Proyecto1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.btnGenerarPdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPaisSelec = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumHab = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbGrafica = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.acercaDeToolStripMenuItem,
            this.salirToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.nuevaPestañaToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            resources.ApplyResources(this.archivoToolStripMenuItem, "archivoToolStripMenuItem");
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            resources.ApplyResources(this.abrirToolStripMenuItem, "abrirToolStripMenuItem");
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.AbrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            resources.ApplyResources(this.guardarToolStripMenuItem, "guardarToolStripMenuItem");
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.GuardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            resources.ApplyResources(this.guardarComoToolStripMenuItem, "guardarComoToolStripMenuItem");
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.GuardarComoToolStripMenuItem_Click);
            // 
            // nuevaPestañaToolStripMenuItem
            // 
            this.nuevaPestañaToolStripMenuItem.Name = "nuevaPestañaToolStripMenuItem";
            resources.ApplyResources(this.nuevaPestañaToolStripMenuItem, "nuevaPestañaToolStripMenuItem");
            this.nuevaPestañaToolStripMenuItem.Click += new System.EventHandler(this.NuevaPestañaToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            resources.ApplyResources(this.acercaDeToolStripMenuItem, "acercaDeToolStripMenuItem");
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.AcercaDeToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // btnAnalizar
            // 
            resources.ApplyResources(this.btnAnalizar, "btnAnalizar");
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.UseMnemonic = false;
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.BtnAnalizar_Click);
            // 
            // btnGenerarPdf
            // 
            resources.ApplyResources(this.btnGenerarPdf, "btnGenerarPdf");
            this.btnGenerarPdf.Name = "btnGenerarPdf";
            this.btnGenerarPdf.UseVisualStyleBackColor = true;
            this.btnGenerarPdf.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // lblPaisSelec
            // 
            resources.ApplyResources(this.lblPaisSelec, "lblPaisSelec");
            this.lblPaisSelec.Name = "lblPaisSelec";
            this.lblPaisSelec.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblNumHab
            // 
            resources.ApplyResources(this.lblNumHab, "lblNumHab");
            this.lblNumHab.Name = "lblNumHab";
            this.lblNumHab.Click += new System.EventHandler(this.Label3_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // pbGrafica
            // 
            resources.ApplyResources(this.pbGrafica, "pbGrafica");
            this.pbGrafica.Name = "pbGrafica";
            this.pbGrafica.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbGrafica);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNumHab);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPaisSelec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerarPdf);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrafica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Button btnGenerarPdf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPaisSelec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumHab;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbGrafica;
    }
}

