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
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 571);
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
    }
}
