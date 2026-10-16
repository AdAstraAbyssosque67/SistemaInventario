using FontAwesome.Sharp;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Modelos;

namespace SistemaInventario.Presentacion.Vistas
{
    // Papelera: muestra los registros eliminados y permite restaurarlos.
    public class VistaPapelera : UserControl
    {
        // Un tipo de registro: cómo cargar sus eliminados y cómo restaurarlos.
        private record Origen(string Texto,
                              Func<Resultado<List<ElementoPapelera>>> Cargar,
                              Func<int, Resultado<bool>> Restaurar);

        private readonly FabricaServicios _fabrica;
        private readonly TextBox _txtBuscar = new() { PlaceholderText = "Buscar en la papelera...", Width = 320 };
        private readonly DataGridView _grid = new();
        private readonly List<Origen> _origenes;
        private Origen _origenActual;
        private List<ElementoPapelera> _elementos = new();

        public VistaPapelera(FabricaServicios fabrica)
        {
            _fabrica = fabrica;
            _origenes = new List<Origen>
            {
                new("Productos",
                    () => Convertir(_fabrica.Productos.ObtenerEliminados(),
                        p => new ElementoPapelera(p.Id, p.Nombre, $"Precio: RD$ {p.Precio:N2}", p.FechaModificacion)),
                    id => _fabrica.Productos.Restaurar(id)),

                new("Categorías",
                    () => Convertir(_fabrica.Categorias.ObtenerEliminadas(),
                        c => new ElementoPapelera(c.Id, c.Nombre, c.Descripcion, c.FechaModificacion)),
                    id => _fabrica.Categorias.Restaurar(id)),

                new("Suplidores",
                    () => Convertir(_fabrica.Suplidores.ObtenerEliminados(),
                        s => new ElementoPapelera(s.Id, s.NombreEmpresa, $"{s.NombreContacto} · {s.Telefono}", s.FechaModificacion)),
                    id => _fabrica.Suplidores.Restaurar(id))
            };
            _origenActual = _origenes[0];

            Construir();
        }

        // Método genérico: convierte el resultado de cualquier servicio en filas de la papelera.
        private static Resultado<List<ElementoPapelera>> Convertir<T>(
            Resultado<List<T>> origen, Func<T, ElementoPapelera> mapa) =>
            origen.Exito
                ? Resultado<List<ElementoPapelera>>.Ok(origen.Valor!.Select(mapa).ToList())
                : Resultado<List<ElementoPapelera>>.Falla(origen.Mensaje);

        private void Construir()
        {
            Dock = DockStyle.Fill;
            BackColor = Tema.Fondo;
            Padding = new Padding(24);

            // Fila 1: búsqueda y botón Restaurar
            var btnRestaurar = Estilo.BotonPrimario("Restaurar", IconChar.Undo, 130);
            btnRestaurar.Click += (_, _) => Restaurar();

            var acciones = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,
                Padding = new Padding(0, 9, 0, 0)
            };
            acciones.Controls.Add(btnRestaurar);

            _txtBuscar.Location = new Point(0, 13);
            _txtBuscar.TextChanged += (_, _) => AplicarFiltro();

            var barra = new Panel { Dock = DockStyle.Top, Height = 56 };
            barra.Controls.Add(acciones);
            barra.Controls.Add(_txtBuscar);

            // Fila 2: botones tipo pestaña
            var selector = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 50, WrapContents = false };
            foreach (var origen in _origenes)
            {
                var radio = new RadioButton
                {
                    Text = origen.Texto,
                    Appearance = Appearance.Button,
                    FlatStyle = FlatStyle.Flat,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(120, 38),
                    Margin = new Padding(0, 0, 8, 0),
                    BackColor = Color.White,
                    ForeColor = Tema.Texto,
                    Cursor = Cursors.Hand
                };
                radio.FlatAppearance.BorderColor = Tema.Borde;
                radio.FlatAppearance.CheckedBackColor = Tema.Primario;
                radio.CheckedChanged += (_, _) =>
                {
                    radio.ForeColor = radio.Checked ? Color.White : Tema.Texto;
                    if (!radio.Checked) return;
                    _origenActual = origen;
                    Recargar();
                };
                selector.Controls.Add(radio);
            }

            // Tabla
            Estilo.AplicarTabla(_grid);
            _grid.Columns.AddRange(
                Estilo.Columna("Nombre", nameof(ElementoPapelera.Nombre), 30),
                Estilo.Columna("Detalle", nameof(ElementoPapelera.Detalle), 45),
                Estilo.Columna("Eliminado", nameof(ElementoPapelera.Eliminado), 25, "dd/MM/yyyy HH:mm"));

            var tarjeta = new Panel { Dock = DockStyle.Fill, BackColor = Tema.Borde, Padding = new Padding(1) };
            tarjeta.Controls.Add(_grid);

            Controls.Add(tarjeta);
            Controls.Add(selector);
            Controls.Add(barra);

            ((RadioButton)selector.Controls[0]).Checked = true;   // muestra Productos al abrir
        }

        private void Recargar()
        {
            var resultado = _origenActual.Cargar();
            if (!resultado.Exito)
            {
                Dialogos.Error(resultado.Mensaje);
                return;
            }
            _elementos = resultado.Valor!;
            AplicarFiltro();
        }

        // LINQ: búsqueda parcial por nombre o detalle, ignorando mayúsculas.
        private void AplicarFiltro()
        {
            string texto = _txtBuscar.Text.Trim();
            _grid.DataSource = _elementos
                .Where(e => texto.Length == 0
                         || e.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)
                         || e.Detalle.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        private void Restaurar()
        {
            if (_grid.CurrentRow?.DataBoundItem is not ElementoPapelera elemento)
            {
                Dialogos.Info("Seleccione un elemento de la lista.");
                return;
            }

            var resultado = _origenActual.Restaurar(elemento.Id);
            if (!resultado.Exito)
            {
                Dialogos.Error(resultado.Mensaje);   // por ejemplo: su categoría sigue en la papelera
                return;
            }
            Recargar();
        }
    }
}