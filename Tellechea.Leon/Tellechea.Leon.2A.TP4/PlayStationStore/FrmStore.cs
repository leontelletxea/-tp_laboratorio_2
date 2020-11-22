using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayStationStore
{
    public partial class FrmStore : Form
    {
        protected SqlDataAdapter da;
        protected DataTable dt;
        protected PlayStation psSeleccionado;
        protected delegate void Delegado(object sender, EventArgs e);
        protected event Delegado EventoVender;
        protected FrmGif frmGif;

        public FrmStore()
        {
            InitializeComponent();

            this.pictureBox1.Load("indexLogo.png");

            this.dt = new DataTable();
            this.dataGridView1.DataSource = this.dt;

            if (!this.ConfigurarDataAdapter())
            {
                MessageBox.Show("No se pudo configurar el DataAdapter");
                this.Close();
            }

            this.ConfigurarDataTable();

            try
            {
                this.da.Fill(this.dt);

                this.ConfigurarGrilla();

                this.dataGridView1.DataSource = this.dt;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private bool ConfigurarDataAdapter()
        {
            bool rta = false;

            try
            {
                SqlConnection cn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=PlayStationStore;Integrated Security=True");

                this.da = new SqlDataAdapter();

                this.da.SelectCommand = new SqlCommand("SELECT id, precio, almacenamiento, lanzamiento, modelo, peso FROM Store", cn);
                this.da.InsertCommand = new SqlCommand("INSERT INTO Store (precio, almacenamiento, lanzamiento, modelo, peso) VALUES (@precio, @almacenamiento, @lanzamiento, @modelo, @peso)", cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE Store SET precio=@precio, almacenamiento=@almacenamiento, lanzamiento=@lanzamiento, modelo=@modelo, peso=@peso WHERE id=@id", cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM Store WHERE id=@id", cn);

                this.da.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 15, "precio");
                this.da.InsertCommand.Parameters.Add("@almacenamiento", SqlDbType.VarChar, 50, "almacenamiento");
                this.da.InsertCommand.Parameters.Add("@lanzamiento", SqlDbType.VarChar, 50, "lanzamiento");
                this.da.InsertCommand.Parameters.Add("@modelo", SqlDbType.VarChar, 50, "modelo");
                this.da.InsertCommand.Parameters.Add("@peso", SqlDbType.Float, 15, "peso");

                this.da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 15, "precio");
                this.da.UpdateCommand.Parameters.Add("@almacenamiento", SqlDbType.VarChar, 50, "almacenamiento");
                this.da.UpdateCommand.Parameters.Add("@lanzamiento", SqlDbType.VarChar, 50, "lanzamiento");
                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
                this.da.UpdateCommand.Parameters.Add("@modelo", SqlDbType.VarChar, 50, "modelo");
                this.da.UpdateCommand.Parameters.Add("@peso", SqlDbType.Float, 15, "peso");

                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                rta = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return rta;
        }

        private void ConfigurarDataTable()
        {
            this.dt = new DataTable("Store");

            this.dt.Columns.Add("id", typeof(int));
            this.dt.Columns.Add("precio", typeof(float));
            this.dt.Columns.Add("almacenamiento", typeof(string));
            this.dt.Columns.Add("lanzamiento", typeof(string));
            this.dt.Columns.Add("modelo", typeof(string));
            this.dt.Columns.Add("peso", typeof(float));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;
        }

        private void ConfigurarGrilla()
        {
            // Coloco color de fondo para las filas
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Gray;

            // Alterno colores
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Color.FromArgb(138, 184, 187)

            // Pongo color de fondo a la grilla
            this.dataGridView1.BackgroundColor = Color.Blue;

            // Defino fuente para el encabezado y alineación del encabezado
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Regular);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Defino el color de las lineas de separación
            this.dataGridView1.GridColor = Color.Black;

            // La grilla será de sólo lectura
            this.dataGridView1.ReadOnly = false;

            // No permito la multiselección
            this.dataGridView1.MultiSelect = false;

            // Selecciono toda la fila a la vez
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Hago que las columnas ocupen todo el ancho del 'DataGrid'
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Indico el color de la fila seleccionada
            this.dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Lime;
            this.dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            // No permito modificar desde la grilla
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Saco los encabezados de las filas
            this.dataGridView1.RowHeadersVisible = false;
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.da.Update(this.dt);

                MessageBox.Show("Se ha sincronizado correctamente!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregarPs_Click(object sender, EventArgs e)
        {
            FrmPlayStation frm = new FrmPlayStation();
            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow fila = this.dt.NewRow();

                fila["precio"] = frm.PlayStation.Precio;
                fila["almacenamiento"] = frm.PlayStation.Almacenamiento;
                fila["lanzamiento"] = frm.PlayStation.Lanzamiento;
                fila["modelo"] = frm.PlayStation.Modelo;

                this.dt.Rows.Add(fila);
            }
        }

        private void btnAgregarVr_Click(object sender, EventArgs e)
        {
            FrmVR frm = new FrmVR();
            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow fila = this.dt.NewRow();

                fila["precio"] = frm.VR.Precio;
                fila["almacenamiento"] = frm.VR.Almacenamiento;
                fila["lanzamiento"] = frm.VR.Lanzamiento;
                fila["peso"] = frm.VR.Peso;

                this.dt.Rows.Add(fila);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int i = this.dataGridView1.SelectedRows[0].Index;

            DataRow fila = this.dt.Rows[i];

            try
            {
               int id = int.Parse(fila["id"].ToString());
                float precio = float.Parse(fila["precio"].ToString());
                string almacenamiento = fila["almacenamiento"].ToString();
                string lanzamiento = fila["lanzamiento"].ToString();

                if (fila["modelo"].ToString() != "")
                {
                    int modelo = int.Parse(fila["modelo"].ToString());

                    PlayStation p = new PlayStation(id, precio, almacenamiento, lanzamiento, modelo);

                    FrmPlayStation frm = new FrmPlayStation(p);

                    frm.StartPosition = FormStartPosition.CenterScreen;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        fila["precio"] = frm.PlayStation.Precio;
                        fila["almacenamiento"] = frm.PlayStation.Almacenamiento;
                        fila["lanzamiento"] = frm.PlayStation.Lanzamiento;
                        fila["modelo"] = frm.PlayStation.Modelo;
                    }
                }
                else
                {
                    float peso = float.Parse(fila["peso"].ToString());

                    VR v = new VR(id, precio, almacenamiento, lanzamiento, peso);

                    FrmVR frm = new FrmVR(v);

                    frm.StartPosition = FormStartPosition.CenterScreen;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        fila["precio"] = frm.VR.Precio;
                        fila["almacenamiento"] = frm.VR.Almacenamiento;
                        fila["lanzamiento"] = frm.VR.Lanzamiento;
                        fila["peso"] = frm.VR.Peso;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            DataRowView fila = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;

            try
            {
                int id = int.Parse(fila["id"].ToString());
                float precio = float.Parse(fila["precio"].ToString());
                string almacenamiento = fila["almacenamiento"].ToString();
                string lanzamiento = fila["lanzamiento"].ToString();

                if (fila["modelo"].ToString() != "")
                {
                    int modelo = int.Parse(fila["modelo"].ToString());
                    PlayStation p = new PlayStation(id, precio, almacenamiento, lanzamiento, modelo);
                    FrmPlayStation frm = new FrmPlayStation(p);

                    if (this.EventoVender != null)
                    {
                        this.EventoVender -= psSeleccionado_EventoVender;
                    }
                    this.psSeleccionado = p;
                    this.EventoVender += psSeleccionado_EventoVender;

                    frm.StartPosition = FormStartPosition.CenterScreen;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        fila.Delete();
                        this.EventoVender(this, EventArgs.Empty);
                    }
                }
                else
                {
                    float peso = float.Parse(fila["peso"].ToString());

                    VR v = new VR(id, precio, almacenamiento, lanzamiento, peso);

                    FrmVR frm = new FrmVR(v);

                    frm.StartPosition = FormStartPosition.CenterScreen;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        fila.Delete();
                        MessageBox.Show($"Venta de: {v}\nSe imprimio el ticket!");

                        Thread tarea = new Thread(CargarFormularioGif);
                        tarea.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CargarFormularioGif()
        {
            this.frmGif = new FrmGif();
        }

        private void psSeleccionado_EventoVender(object sender, EventArgs e)
        {
            Random random = new Random();
            int puntos = random.Next(1, 10000);
            bool todoOK = Tickets<PlayStation>.ImprimirTiket(this.psSeleccionado);

            if (todoOK)
            {
                MessageBox.Show($"Venta de: {this.psSeleccionado}\nSe imprimio el ticket!\nPUNTOS ACUMULADOS: {puntos}");
            }
            else
            {
                MessageBox.Show("No se pudo imprimir el ticket!!!");
            }
        }
    }
}
