using System.Diagnostics;

namespace LaravelNet
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Ruta base por defecto
            //txtRutaBase.Text = @"C:\WebPHP744\htdocs";
            txtRutaBase.Text = Properties.Settings.Default.RutaBase;
        }

        private void EjecutarArtisan(string rutaProyecto, string comando)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c php artisan {comando}",
                    WorkingDirectory = rutaProyecto,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process proceso = new Process())
                {
                    proceso.StartInfo = psi;
                    proceso.Start();

                    string salida = proceso.StandardOutput.ReadToEnd();
                    string error = proceso.StandardError.ReadToEnd();

                    proceso.WaitForExit();

                    txtSalida.AppendText($">>> php artisan {comando}\n");
                    txtSalida.AppendText(salida + "\n");
                    if (!string.IsNullOrWhiteSpace(error))
                        txtSalida.AppendText("ERROR: " + error + "\n");
                    txtSalida.AppendText("---------------------------------------------------\n");
                }
            }
            catch (Exception ex)
            {
                txtSalida.AppendText("Excepción: " + ex.Message + "\n");
            }
        }
        
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona la ruta base de Laravel";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.RutaBase = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    txtRutaBase.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string rutaBase = txtRutaBase.Text;

            if (!Directory.Exists(rutaBase))
            {
                MessageBox.Show("La ruta no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            treeProyectos.Nodes.Clear();

            var proyectos = Directory.GetDirectories(rutaBase)
                .Where(dir => File.Exists(Path.Combine(dir, "artisan")) &&
                              File.Exists(Path.Combine(dir, "composer.json")))
                .ToList();

            foreach (var proyecto in proyectos)
            {
                var nombreProyecto = Path.GetFileName(proyecto);
                TreeNode nodoProyecto = new TreeNode(nombreProyecto) { Tag = proyecto };

                // Subcarpetas básicas de Laravel
                AgregarNodoSiExiste(nodoProyecto, proyecto, "app");
                AgregarNodoSiExiste(nodoProyecto, proyecto, Path.Combine("resources", "views"));
                AgregarNodoSiExiste(nodoProyecto, proyecto, "routes");
                AgregarNodoSiExiste(nodoProyecto, proyecto, Path.Combine("database", "migrations"));
                AgregarNodoSiExiste(nodoProyecto, proyecto, "config");

                treeProyectos.Nodes.Add(nodoProyecto);
            }

            if (proyectos.Count == 0)
                MessageBox.Show("No se encontraron proyectos Laravel en la ruta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AgregarNodoSiExiste(TreeNode nodoPadre, string rutaBase, string subCarpeta)
        {
            string ruta = Path.Combine(rutaBase, subCarpeta);

            if (Directory.Exists(ruta))
            {
                var nodo = new TreeNode(Path.GetFileName(subCarpeta)) { Tag = ruta };
                nodoPadre.Nodes.Add(nodo);

                // Agregar subcarpetas
                foreach (var dir in Directory.GetDirectories(ruta))
                {
                    var subNodo = new TreeNode(Path.GetFileName(dir)) { Tag = dir };
                    nodo.Nodes.Add(subNodo);
                }

                // Agregar archivos
                foreach (var file in Directory.GetFiles(ruta))
                {
                    string ext = Path.GetExtension(file).ToLower();
                    if (ext == ".php" || ext == ".blade.php" || ext == ".json" || Path.GetFileName(file) == ".env")
                    {
                        var subNodo = new TreeNode(Path.GetFileName(file)) { Tag = file };
                        nodo.Nodes.Add(subNodo);
                    }
                }
            }
        }
        private void treeProyectos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string? ruta = e.Node.Tag?.ToString();
            if (ruta != null)
            {
                if (Directory.Exists(ruta))
                    System.Diagnostics.Process.Start("cmd.exe", $"/c code \"{ruta}\"");
                else if (File.Exists(ruta))
                    System.Diagnostics.Process.Start("cmd.exe", $"/c code \"{ruta}\"");
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.RutaBase = txtRutaBase.Text;
            Properties.Settings.Default.Save();
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProyectoActivo.Text) || txtProyectoActivo.Tag == null)
            {
                MessageBox.Show("Selecciona un proyecto primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rutaProyecto = txtProyectoActivo.Tag.ToString();
            EjecutarArtisan(rutaProyecto, "route:list");
        }
        private void btnMigrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProyectoActivo.Text) || txtProyectoActivo.Tag == null)
            {
                MessageBox.Show("Selecciona un proyecto primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rutaProyecto = txtProyectoActivo.Tag.ToString();
            EjecutarArtisan(rutaProyecto, "migrate");
        }

        private void btnEstadoMigraciones_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProyectoActivo.Text) || txtProyectoActivo.Tag == null)
            {
                MessageBox.Show("Selecciona un proyecto primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rutaProyecto = txtProyectoActivo.Tag.ToString();
            EjecutarArtisan(rutaProyecto, "migrate:status");
        }

        private void treeProyectos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string ruta = e.Node.Tag?.ToString();

            if (ruta != null)
            {
                // Buscar la raíz del proyecto (donde está artisan)
                string rutaProyecto = ruta;
                while (!File.Exists(Path.Combine(rutaProyecto, "artisan")) && Directory.Exists(rutaProyecto))
                {
                    rutaProyecto = Directory.GetParent(rutaProyecto)?.FullName;
                    if (rutaProyecto == null) return;
                }

                txtProyectoActivo.Text = Path.GetFileName(rutaProyecto);
                txtProyectoActivo.Tag = rutaProyecto; // guardamos la ruta completa en Tag
            }
        }
    }
}
