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
            txtRutaBase.Text = @"C:\WebPHP744\htdocs";
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtRutaBase.Text = folderDialog.SelectedPath;
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
                var nodo = new TreeNode(subCarpeta) { Tag = ruta };
                nodoPadre.Nodes.Add(nodo);
            }
        }
    }
}
