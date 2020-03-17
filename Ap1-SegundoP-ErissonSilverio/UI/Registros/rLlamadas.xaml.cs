using Ap1_SegundoP_ErissonSilverio.BLL;
using Ap1_SegundoP_ErissonSilverio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ap1_SegundoP_ErissonSilverio.UI.Registros
{
    /// <summary>
    /// Interaction logic for rAnonimus.xaml
    /// </summary>
    public partial class rAnonimus : Window
    {
        Llamadas llamadas = new Llamadas();
        public rAnonimus()
        {
            
            InitializeComponent();
            this.DataContext = llamadas;
            
            idTextBox.Text = "0";

        }

        private void LimpiarCampos()
        {
            descripcionTextBox.Text = string.Empty;
            problemaTextBox.Text = string.Empty;
            solucionTextBox.Text = string.Empty;
            idTextBox.Text = "0";

        }


        private bool ExisteEnLaBaseDatos()
        {
            Llamadas llamadas = LlamadasBLL.Buscar((int)Convert.ToInt32(idTextBox.Text));
                return (llamadas != null);
        }


        private bool ValidarCampos()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                MessageBox.Show("Campo Obligatorio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }

            //if (string.IsNullOrWhiteSpace(problemaTextBox.Text))
            //{
            //    MessageBox.Show("Campo Obligatorio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            //    paso = false;
            //}

            //if (string.IsNullOrWhiteSpace(solucionTextBox.Text))
            //{
            //    MessageBox.Show("Campo Obligatorio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            //    paso = false;
            //}

            return paso;
        }


        private void Llenar()
        {
            this.DataContext = null;
            this.DataContext = llamadas;
        }

        private void solucionTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }

        }

        private void problemaTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }

        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!ValidarCampos())
                return;

            if (idTextBox.Text == "0")
            paso = LlamadasBLL.Guardar(llamadas);

            else
            {
                if (!ExisteEnLaBaseDatos())
                {
                    MessageBox.Show("Llmada No Existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = LlamadasBLL.Modificar(llamadas);
            }

            if (paso)
            {
                MessageBox.Show("¡¡Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("¡¡No Guardado!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            Llamadas llamadalocal = LlamadasBLL.Buscar(llamadas.LlamadaId);

            if (llamadalocal != null)
            {
                llamadas = llamadalocal;
                Llenar();

            }
            else
            {
                LimpiarCampos();
                MessageBox.Show("Llamada no Encontrada!!");
                    
                
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (LlamadasBLL.Eliminar(llamadas.LlamadaId))
            {
                LimpiarCampos();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No Eliminado!!");
            }
        }

        private void removerButton_Click(object sender, RoutedEventArgs e)
        {
            if (detalleDataGrid.Columns.Count > 0 && detalleDataGrid.SelectedCells != null)
            {
                llamadas.LlamadasDetalles.RemoveAt(detalleDataGrid.SelectedIndex);
                Llenar();
            }
        }

        private void agregarTextBox_Click(object sender, RoutedEventArgs e)
        {
            llamadas.LlamadasDetalles.Add(new LlamadaDetalle(llamadas.LlamadaId, Convert.ToInt32(idTextBox.Text), problemaTextBox.Text, solucionTextBox.Text));
            Llenar();

            //descripcionTextBox.Clear();
            problemaTextBox.Clear();
            solucionTextBox.Clear();
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void idTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void descripcionTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }

        }

        

       
    }
}
