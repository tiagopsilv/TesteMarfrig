using Newtonsoft.Json;
using SistemaCompraGado.Presentation.Negocios.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaCompraGado.Presentation
{
    /// <summary>
    /// Lógica interna para CompraGado.xaml
    /// </summary>
    public partial class CompraGado : Window
    {
        private string _host = @"https://localhost:44361";
        public List<Pecuarista> LstPecuarista;
        public List<Animal> LstAnimal;
        public List<AnimalGrid> LstAnimalGrid;
        public CompraGadoRep CompraGadoAtualiza;
        private bool _NovoItem;
        private bool _NovaCompra;

        public CompraGado(string host, long IDCompraGado)
        {
            InitializeComponent();
            Carrega(host);
            _NovaCompra = false;
            txtID.Text = IDCompraGado.ToString();
            txtID.IsReadOnly = true;
            CarregaAtualizar();

        }

        public CompraGado(string host)
        {
            InitializeComponent();
            Carrega(host);
            _NovaCompra = true;
            txtID.IsReadOnly = false;
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            _NovoItem = true;
            Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CarregaAtualizar()
        {
            var jsonString = JSONHelper.GetJSONString(_host + @"/api/CompraGado/GetListaCompraGadoByID/" + txtID.Text);

            CompraGadoAtualiza = JsonConvert.DeserializeObject<CompraGadoRep>(jsonString);

            txtDtEntrega.Text = CompraGadoAtualiza.DataEntrega.ToString("dd/MM/yyyy");
            cboPecuarista.SelectedValue = CompraGadoAtualiza.PecuaristaID;

            foreach (CompraGadoItem _CompraGadoItem in CompraGadoAtualiza.CompraDadoItem)
                LstAnimalGrid.Add(new AnimalGrid { DescricaoAnimal = LstAnimal.Where(T => T.ID == _CompraGadoItem.AnimalID).First().Descricao, IDGrid = LstAnimalGrid.Count() + 1, IndexCombo = Int32.Parse(_CompraGadoItem.AnimalID.ToString()), Itens = _CompraGadoItem, Preco = LstAnimal.Where(T => T.ID == _CompraGadoItem.AnimalID).First().Preco, Quantidade = _CompraGadoItem.Quantidade, ValorTotal = (decimal.Parse(LstAnimal.Where(T => T.ID == _CompraGadoItem.AnimalID).First().Preco.ToString()) * Int32.Parse(_CompraGadoItem.Quantidade)).ToString() });

            lblTotal.Content = "Total : " + LstAnimalGrid.Sum(g => decimal.Parse(g.ValorTotal)).ToString();

            grdItens.Items.Refresh();

        }

        private void Carrega(string host)
        {
            _host = host;
            LstAnimalGrid = new List<AnimalGrid>();

            Hidden();

            grdItens.ItemsSource = LstAnimalGrid;
            grdItens.DataContext = LstAnimalGrid;

            var jsonString = JSONHelper.GetJSONString(_host + @"/api/CompraGado/GetListaPecuaristas");

            LstPecuarista = JsonConvert.DeserializeObject<List<Pecuarista>>(jsonString);

            cboPecuarista.ItemsSource = LstPecuarista;

            jsonString = JSONHelper.GetJSONString(_host + @"/api/CompraGado/GetListaAnimal");

            LstAnimal = JsonConvert.DeserializeObject<List<Animal>>(jsonString);

            cboAnimal.ItemsSource = LstAnimal;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Hidden();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidaItens())
            {
                AnimalGrid _AnimalGrid = new AnimalGrid();
                CompraGadoItem _CompraGadoItem = new CompraGadoItem();
                Animal _Animal = LstAnimal.Where(T => T.ID == Int32.Parse(cboAnimal.SelectedValue.ToString())).First();

                _AnimalGrid.IndexCombo = Int32.Parse(cboAnimal.SelectedValue.ToString());
                _AnimalGrid.DescricaoAnimal = cboAnimal.Text;
                _AnimalGrid.Quantidade = txtQuantidade.Text;
                _AnimalGrid.Preco = _Animal.Preco;
                _AnimalGrid.ValorTotal = (decimal.Parse(_Animal.Preco.ToString()) * Int32.Parse(_AnimalGrid.Quantidade)).ToString();

                _CompraGadoItem.AnimalID = _Animal.ID;
                _CompraGadoItem.Quantidade = txtQuantidade.Text;

                _AnimalGrid.Itens = _CompraGadoItem;

                if (!(_NovoItem))
                    LstAnimalGrid.Remove(LstAnimalGrid.Where(w => w.IDGrid == ((AnimalGrid)grdItens.SelectedItem).IDGrid).First());

                _AnimalGrid.IDGrid = (LstAnimalGrid.Count() + 1);
                LstAnimalGrid.Add(_AnimalGrid);

                lblTotal.Content = "Total : " + LstAnimalGrid.Sum(g => decimal.Parse(g.ValorTotal)).ToString();

                grdItens.Items.Refresh();

                Hidden();
            }
        }

        private void Hidden()
        {
            lblModificar.Visibility = Visibility.Hidden;
            lblAnimal.Visibility = Visibility.Hidden;
            cboAnimal.Visibility = Visibility.Hidden;
            lblQuantidade.Visibility = Visibility.Hidden;
            txtQuantidade.Visibility = Visibility.Hidden;
            btnSalvar.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;
            btnGravarCompra.Visibility = Visibility.Visible;
            txtQuantidade.Text = "";
            cboAnimal.SelectedIndex = -1;
        }

        private void Show()
        {
            lblModificar.Visibility = Visibility.Visible;
            lblAnimal.Visibility = Visibility.Visible;
            cboAnimal.Visibility = Visibility.Visible;
            lblQuantidade.Visibility = Visibility.Visible;
            txtQuantidade.Visibility = Visibility.Visible;
            btnSalvar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;
            btnGravarCompra.Visibility = Visibility.Hidden;
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarIDGrid())
            {
                AnimalGrid _AnimalGrid = (AnimalGrid)grdItens.SelectedItem;
                LstAnimalGrid.Remove(_AnimalGrid);
                grdItens.Items.Refresh();
            }
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarIDGrid())
            {
                _NovoItem = false;
                Show();
                AnimalGrid _AnimalGrid = (AnimalGrid)grdItens.SelectedItem;
                cboAnimal.SelectedValue = _AnimalGrid.IndexCombo;
                txtQuantidade.Text = _AnimalGrid.Quantidade;
            }
        }

        private bool ValidarIDGrid()
        {
            bool Retorno = false;
            if ((AnimalGrid)grdItens.SelectedItem == null)
                MessageBox.Show("Selecione uma linha do Grid.",
                     "Preenchimeto Obrigatorio",
                     MessageBoxButton.OK,
                     MessageBoxImage.Error);
            else
                Retorno = true;

            return Retorno;
        }

        private void btnGravarCompra_Click(object sender, RoutedEventArgs e)
        {
            if (ValidaCompra())
            {
                CompraGadoRep _CompraGado = new CompraGadoRep { ID = Int32.Parse(txtID.Text), DataEntrega = DateTime.Parse(txtDtEntrega.Text), PecuaristaID = Int32.Parse(cboPecuarista.SelectedValue.ToString()) };
                List<CompraGadoItem> _LstCompraGadoItem = new List<CompraGadoItem>();

                foreach (AnimalGrid _AnimalGrid in LstAnimalGrid)
                    _LstCompraGadoItem.Add(new CompraGadoItem { AnimalID = _AnimalGrid.Itens.AnimalID, CompraGadoID = _CompraGado.ID, Quantidade = _AnimalGrid.Itens.Quantidade });

                _CompraGado.CompraDadoItem = _LstCompraGadoItem;

                var obj = JsonConvert.SerializeObject(_CompraGado);

                var url = _host + (_NovaCompra ? "/api/CompraGado/GravarCompraGado" : "/api/CompraGado/AlterarCompraGado");

                Retorno _Retorno = JSONHelper.Post(url, obj);

                if (_Retorno.Sucesso)
                {
                    MessageBox.Show("Compra Inserida com sucesso.",
                                 "Sucesso",
                                 MessageBoxButton.OK,
                                 MessageBoxImage.Information);

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            var jsonString = JSONHelper.GetJSONString(_host + @"/api/CompraGado/GetListaCompraGado");
                            (window as MainWindow)._LstPesquisarCompraGado = JsonConvert.DeserializeObject<List<PesquisarCompraGado>>(jsonString);
                            (window as MainWindow)._LstPesquisarCompraGadoFiltro = (window as MainWindow).AtualizarContador((window as MainWindow)._LstPesquisarCompraGado);
                            (window as MainWindow).grdConsultaCompraGado.ItemsSource = (window as MainWindow)._LstPesquisarCompraGadoFiltro.Where(T=> T.Count <= 10);
                            (window as MainWindow).grdConsultaCompraGado.DataContext = (window as MainWindow)._LstPesquisarCompraGadoFiltro.Where(T => T.Count <= 10);
                            (window as MainWindow).grdConsultaCompraGado.Items.Refresh();
                        }
                    }

                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show(_Retorno.Mensagem,
                                    "Erro",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        private bool ValidaItens()
        {

            bool Retorno = false;

            if (string.IsNullOrWhiteSpace(cboAnimal.Text))
                MessageBox.Show("O preenchimento do campo Animal é obrigatorio.",
                 "Preenchimeto Obrigatorio",
                 MessageBoxButton.OK,
                 MessageBoxImage.Error);
            else if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
                MessageBox.Show("O preenchimento do campo Quantidade é obrigatorio.",
                 "Preenchimeto Obrigatorio",
                 MessageBoxButton.OK,
                 MessageBoxImage.Error);
            else if (!(int.TryParse(txtQuantidade.Text, out int n)))
                MessageBox.Show("O preenchimento do campo Quantidade deve ser do tipo inteiro.",
                 "Tipo",
                 MessageBoxButton.OK,
                 MessageBoxImage.Error);
            else
                Retorno = true;

            return Retorno;

        }

        private bool ValidaCompra()
        {
            bool Retorno = false;
            if (string.IsNullOrWhiteSpace(txtID.Text))
                MessageBox.Show("O preenchimento do campo ID é obrigatorio.",
                 "Preenchimeto Obrigatorio",
                 MessageBoxButton.OK,
                 MessageBoxImage.Error);
            else if (!(int.TryParse(txtID.Text, out int n)))
                MessageBox.Show("O preenchimento do campo ID deve ser do tipo númerico.",
                 "Tipo",
                 MessageBoxButton.OK,
                 MessageBoxImage.Error);
            else if(string.IsNullOrWhiteSpace(txtDtEntrega.Text))
                MessageBox.Show("O preenchimento do campo Data Entrega é obrigatorio.",
                 "Preenchimeto Obrigatorio",
                 MessageBoxButton.OK,
                 MessageBoxImage.Error);
            else if (!(DateTime.TryParseExact(txtDtEntrega.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data)))
                MessageBox.Show("A data deve serguir o formato de dd/mm/aaaa.",
                                 "Tipo",
                                 MessageBoxButton.OK,
                                 MessageBoxImage.Error);
            else if (string.IsNullOrWhiteSpace(cboPecuarista.Text))
                MessageBox.Show("O preenchimento do campo Pecuarista é obrigatorio.",
                 "Preenchimeto Obrigatorio",
                 MessageBoxButton.OK,
                 MessageBoxImage.Error);
            else if(LstAnimalGrid.Count() == 0)
                MessageBox.Show("O preenchimento dos Itens é obrigatorio.",
                 "Preenchimeto Obrigatorio",
                 MessageBoxButton.OK,
                 MessageBoxImage.Error);
            else
                Retorno = true;
            return Retorno;
        }

    }
}
