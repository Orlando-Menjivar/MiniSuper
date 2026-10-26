using MiniSuper.BusinessLogic;
using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Configuration;

namespace MiniSuper.Desktop
{
    public partial class Form1 : Form
    {
        readonly CategoriaRepository _categoriaRepository;
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Server=192.168.0.15,1433;Database=MinisuperDB;User Id=sa;Password=TuPasswordMuySeguro123!;TrustServerCertificate=True;";

            ConnectionFactory Factory = new ConnectionFactory(connectionString);

            _categoriaRepository = new CategoriaRepository(Factory);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }


        private void CargarGrid()
        {
            try
            {
                var ListaCategorias = _categoriaRepository.SelectAll();

                dataGridView1.DataSource = ListaCategorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                Categoria categoria = new Categoria
                {
                    NombreCategoria = textBox1.Text.Trim()
                };
                int result = _categoriaRepository.Insert(categoria);
                if (result > 0)
                {
                    MessageBox.Show("Registro insertado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
