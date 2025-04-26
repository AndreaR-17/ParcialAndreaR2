using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegoMinecraf.Services;
using JuegoMinecraf.Utils;
using JuegoMinecraf.Models;
using Microsoft.Data.SqlClient;




namespace JuegoMinecraf
{
    public partial class Form1 : Form

    {
        private readonly JugadorService _jugadorService;
        private readonly BloqueService _bloqueService;
        private readonly InventarioService _inventarioService;
        // Fix for CS1061: Ensure _dbManager is of the correct type and has a GetConnection method.  
        // Update the declaration of _dbManager to use the correct type (DatabaseManager).  

        private readonly DatabaseManager _dbManager; // Change from 'object' to 'DatabaseManager'

        public Form1()
        {
            // Initialize _dbManager properly
            _dbManager = new DatabaseManager();
            if (!_dbManager.TestConnection())
            {
                MessageBox.Show("No se pudo conectar a la base de datos. Verifique la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _jugadorService = new JugadorService(_dbManager);
            _bloqueService = new BloqueService(_dbManager);
            _inventarioService = new InventarioService(_dbManager, _jugadorService, _bloqueService);

            InitializeComponent();
        }

        private void CargarJugadores()
        {
            // Obtener la lista de jugadores desde el servicio
            var jugadores = _jugadorService.ObtenerTodos();

            // Asignar los datos al DataGridView
            MostrarInventario.DataSource = jugadores.Select(j => new
            {
                j.Id,
                j.Nombre,
                j.Nivel,
                j.FechaCreacion
            }).ToList();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form1_Load se está ejecutando...");
            CargarJugadores(); // Cargar jugadores en el DataGridView
            CargarFiltros();   // Cargar los valores de Tipo y Rareza en el ComboBox
            pictureBox1.Image = Image.FromFile("C:\\PARCIAL 2\\JuegoMinecraf\\ImagenesParcial\\Logo.jpeg");
        }
        private void Agregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreJugador.Text))
            {
                MessageBox.Show("El nombre del jugador no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var jugador = new Jugador
            {
                Nombre = NombreJugador.Text,
                Nivel = (int)NivelJugador.Value
            };

            _jugadorService.Crear(jugador);
            MessageBox.Show("Jugador agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Actualizar la lista de jugadores
            CargarJugadores();
        }
        private void Actualizar_Click(object sender, EventArgs e)
        {
            // Configuración del ComboBox TipoBloque
            TipoBloque.FormattingEnabled = true;
            TipoBloque.Location = new Point(279, 605);
            TipoBloque.Name = "TipoBloque";
            TipoBloque.Size = new Size(151, 28);
            TipoBloque.TabIndex = 8;
            TipoBloque.DropDownStyle = ComboBoxStyle.DropDownList;
            if (MostrarInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un jugador para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var id = (int)MostrarInventario.SelectedRows[0].Cells["Id"].Value;
            var jugador = _jugadorService.ObtenerPorId(id);

            if (jugador != null)
            {
                jugador.Nombre = NombreJugador.Text;
                jugador.Nivel = (int)NivelJugador.Value;

                _jugadorService.Actualizar(jugador);
                MessageBox.Show("Jugador actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la lista de jugadores
                CargarJugadores();
            }
        }
        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (MostrarInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un jugador para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var id = (int)MostrarInventario.SelectedRows[0].Cells["Id"].Value;

            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este jugador?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                _jugadorService.Eliminar(id);
                MessageBox.Show("Jugador eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la lista de jugadores
                CargarJugadores();
            }
        }
        private void CargarFiltros()
        {
            Console.WriteLine("CargarFiltros se está ejecutando...");

            // Obtener todos los bloques desde el servicio
            var bloques = _bloqueService.ObtenerTodos();

            // Depuración: Verificar los datos obtenidos
            Console.WriteLine($"Cantidad de bloques obtenidos: {bloques.Count}");
            foreach (var bloque in bloques)
            {
                Console.WriteLine($"Id: {bloque.Id}, Nombre: {bloque.Nombre}, Tipo: {bloque.Tipo}, Rareza: {bloque.Rareza}");
            }

            // Verificar si hay bloques en la base de datos
            if (bloques == null || bloques.Count == 0)
            {
                MessageBox.Show("No se encontraron bloques en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener valores únicos para Tipo y Rareza
            var tipos = bloques.Select(b => b.Tipo)
                               .Where(valor => !string.IsNullOrEmpty(valor)) // Excluir valores nulos o vacíos
                               .Distinct() // Eliminar duplicados
                               .ToList();

            var rarezas = bloques.Select(b => b.Rareza)
                                 .Where(valor => !string.IsNullOrEmpty(valor)) // Excluir valores nulos o vacíos
                                 .Distinct() // Eliminar duplicados
                                 .ToList();

            // Depuración: Mostrar los valores obtenidos para los ComboBox
            Console.WriteLine("Valores cargados en el ComboBox Tipo:");
            foreach (var tipo in tipos)
            {
                Console.WriteLine(tipo);
            }

            Console.WriteLine("Valores cargados en el ComboBox Rareza:");
            foreach (var rareza in rarezas)
            {
                Console.WriteLine(rareza);
            }

            // Asignar los valores a los ComboBox
            TipoBloque.DataSource = tipos;
            RarezaBloque.DataSource = rarezas;
        }
        private void Filtro_Click(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados en los ComboBox
            var tipoSeleccionado = TipoBloque.SelectedItem?.ToString();
            var rarezaSeleccionada = RarezaBloque.SelectedItem?.ToString();

            // Validar que se haya seleccionado al menos un valor
            if (string.IsNullOrEmpty(tipoSeleccionado) && string.IsNullOrEmpty(rarezaSeleccionada))
            {
                MessageBox.Show("Seleccione un tipo o una rareza para filtrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener todos los bloques desde el servicio
            var bloques = _bloqueService.ObtenerTodos();

            // Filtrar los bloques por tipo y/o rareza
            var bloquesFiltrados = bloques.Where(b =>
                (string.IsNullOrEmpty(tipoSeleccionado) || b.Tipo == tipoSeleccionado) &&
                (string.IsNullOrEmpty(rarezaSeleccionada) || b.Rareza == rarezaSeleccionada)
            ).ToList();

            // Verificar si hay resultados
            if (bloquesFiltrados.Count == 0)
            {
                MessageBox.Show("No se encontraron bloques con los criterios seleccionados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Mostrar los bloques filtrados en el DataGridView
            MostrarInventario.DataSource = bloquesFiltrados.Select(b => new
            {
                b.Id,
                b.Nombre,
                b.Tipo,
                b.Rareza
            }).ToList();
        }
        public List<Bloque> ObtenerTodos()
        {
            var bloques = new List<Bloque>();
            try
            {
                using var connection = _dbManager.GetConnection();
                connection.Open();
                var command = new SqlCommand("SELECT Id, Nombre, Tipo, Rareza FROM Bloques", connection);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bloques.Add(new Bloque
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Tipo = reader.GetString(2),
                        Rareza = reader.GetString(3)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener bloques: {ex.Message}");
            }
            return bloques;
        }
        private void FiltrarBloques_Click(object sender, EventArgs e)
        {
            if (TipoBloque.SelectedItem != null)
            {
                MessageBox.Show($"Valor seleccionado: {TipoBloque.SelectedItem}");
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún valor en el ComboBox.");
            }
        }
        private void ExportarInventarioACSV()
        {
            try
            {
                // Obtener los datos del inventario
                var inventarios = _inventarioService.ObtenerTodos();

                if (inventarios == null || !inventarios.Any())
                {
                    MessageBox.Show("No hay datos en el inventario para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mostrar un cuadro de diálogo para guardar el archivo
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos CSV (.csv)|.csv";
                    saveFileDialog.Title = "Guardar Inventario como CSV";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Crear el archivo CSV
                        using (var writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            // Escribir encabezados
                            writer.WriteLine("Id,JugadorId,BloqueId,Cantidad,NombreJugador,NombreBloque");

                            // Escribir datos
                            foreach (var inventario in inventarios)
                            {
                                writer.WriteLine($"{inventario.Id},{inventario.JugadorId},{inventario.BloqueId},{inventario.Cantidad},{inventario.NombreJugador},{inventario.NombreBloque}");
                            }
                        }

                        MessageBox.Show("Inventario exportado correctamente a CSV.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar el inventario a CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportarInventarioAExcel()
        {
            try
            {
                // Obtener los datos del inventario
                var inventarios = _inventarioService.ObtenerTodos();

                if (inventarios == null || !inventarios.Any())
                {
                    MessageBox.Show("No hay datos en el inventario para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mostrar un cuadro de diálogo para guardar el archivo
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos Excel (.xlsx)|.xlsx";
                    saveFileDialog.Title = "Guardar Inventario como Excel";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Crear el archivo Excel
                        using (var package = new OfficeOpenXml.ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("Inventario");

                            // Escribir encabezados
                            worksheet.Cells[1, 1].Value = "Id";
                            worksheet.Cells[1, 2].Value = "JugadorId";
                            worksheet.Cells[1, 3].Value = "BloqueId";
                            worksheet.Cells[1, 4].Value = "Cantidad";
                            worksheet.Cells[1, 5].Value = "NombreJugador";
                            worksheet.Cells[1, 6].Value = "NombreBloque";

                            // Escribir datos
                            int row = 2;
                            foreach (var inventario in inventarios)
                            {
                                worksheet.Cells[row, 1].Value = inventario.Id;
                                worksheet.Cells[row, 2].Value = inventario.JugadorId;
                                worksheet.Cells[row, 3].Value = inventario.BloqueId;
                                worksheet.Cells[row, 4].Value = inventario.Cantidad;
                                worksheet.Cells[row, 5].Value = inventario.NombreJugador;
                                worksheet.Cells[row, 6].Value = inventario.NombreBloque;
                                row++;
                            }

                            // Guardar el archivo
                            package.SaveAs(new FileInfo(saveFileDialog.FileName));
                        }

                        MessageBox.Show("Inventario exportado correctamente a Excel.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar el inventario a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}

