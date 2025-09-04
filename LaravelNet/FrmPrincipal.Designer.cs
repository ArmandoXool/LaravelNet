namespace LaravelNet
{
    partial class FrmPrincipal
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
            txtRutaBase = new TextBox();
            treeProyectos = new TreeView();
            btnExaminar = new Button();
            btnCargar = new Button();
            txtSalida = new RichTextBox();
            btnRutas = new Button();
            btnMigrar = new Button();
            btnEstadoMigraciones = new Button();
            txtProyectoActivo = new TextBox();
            SuspendLayout();
            // 
            // txtRutaBase
            // 
            txtRutaBase.Location = new Point(12, 27);
            txtRutaBase.Name = "txtRutaBase";
            txtRutaBase.Size = new Size(395, 23);
            txtRutaBase.TabIndex = 0;
            // 
            // treeProyectos
            // 
            treeProyectos.Location = new Point(12, 99);
            treeProyectos.Name = "treeProyectos";
            treeProyectos.Size = new Size(194, 455);
            treeProyectos.TabIndex = 1;
            treeProyectos.AfterSelect += treeProyectos_AfterSelect;
            treeProyectos.NodeMouseDoubleClick += treeProyectos_NodeMouseDoubleClick;
            // 
            // btnExaminar
            // 
            btnExaminar.Location = new Point(12, 56);
            btnExaminar.Name = "btnExaminar";
            btnExaminar.Size = new Size(96, 37);
            btnExaminar.TabIndex = 2;
            btnExaminar.Text = "Examinar";
            btnExaminar.UseVisualStyleBackColor = true;
            btnExaminar.Click += btnExaminar_Click;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(114, 56);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(91, 36);
            btnCargar.TabIndex = 3;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // txtSalida
            // 
            txtSalida.Location = new Point(212, 99);
            txtSalida.Name = "txtSalida";
            txtSalida.ReadOnly = true;
            txtSalida.Size = new Size(905, 150);
            txtSalida.TabIndex = 4;
            txtSalida.Text = "";
            // 
            // btnRutas
            // 
            btnRutas.Location = new Point(795, 56);
            btnRutas.Name = "btnRutas";
            btnRutas.Size = new Size(91, 36);
            btnRutas.TabIndex = 5;
            btnRutas.Text = "Rutas";
            btnRutas.UseVisualStyleBackColor = true;
            btnRutas.Click += btnRutas_Click;
            // 
            // btnMigrar
            // 
            btnMigrar.Location = new Point(892, 56);
            btnMigrar.Name = "btnMigrar";
            btnMigrar.Size = new Size(91, 36);
            btnMigrar.TabIndex = 6;
            btnMigrar.Text = "Migraciones";
            btnMigrar.UseVisualStyleBackColor = true;
            btnMigrar.Click += btnMigrar_Click;
            // 
            // btnEstadoMigraciones
            // 
            btnEstadoMigraciones.Location = new Point(989, 56);
            btnEstadoMigraciones.Name = "btnEstadoMigraciones";
            btnEstadoMigraciones.Size = new Size(128, 36);
            btnEstadoMigraciones.TabIndex = 7;
            btnEstadoMigraciones.Text = "Estado Migraciones";
            btnEstadoMigraciones.UseVisualStyleBackColor = true;
            btnEstadoMigraciones.Click += btnEstadoMigraciones_Click;
            // 
            // txtProyectoActivo
            // 
            txtProyectoActivo.Location = new Point(212, 64);
            txtProyectoActivo.Name = "txtProyectoActivo";
            txtProyectoActivo.Size = new Size(395, 23);
            txtProyectoActivo.TabIndex = 8;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1127, 571);
            Controls.Add(txtProyectoActivo);
            Controls.Add(btnEstadoMigraciones);
            Controls.Add(btnMigrar);
            Controls.Add(btnRutas);
            Controls.Add(txtSalida);
            Controls.Add(btnCargar);
            Controls.Add(btnExaminar);
            Controls.Add(treeProyectos);
            Controls.Add(txtRutaBase);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proyectos Laravel";
            FormClosing += FrmPrincipal_FormClosing;
            Load += FrmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRutaBase;
        private TreeView treeProyectos;
        private Button btnExaminar;
        private Button btnCargar;
        private RichTextBox txtSalida;
        private Button btnRutas;
        private Button btnMigrar;
        private Button btnEstadoMigraciones;
        private TextBox txtProyectoActivo;
    }
}
