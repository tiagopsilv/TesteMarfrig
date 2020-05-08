using Newtonsoft.Json;
using SistemaCompraGado.Presentation.Negocios.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace SistemaCompraGado.Presentation
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Pecuarista> _LstPecuarista;
        public List<PesquisarCompraGado> _LstPesquisarCompraGado;
        public List<PesquisarCompraGado> _LstPesquisarCompraGadoFiltro = new List<PesquisarCompraGado>();
        private List<long> Imprimiu;
        int Paginacao = 10;

        public object ConfigurationManager { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Carrega();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            CompraGado win2 = new CompraGado(txtHost.Text);
            win2.Show();
        }
        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarIDGrid() && ValidarImprimir())
            {
                CompraGado win2 = new CompraGado(txtHost.Text, ((PesquisarCompraGado)grdConsultaCompraGado.SelectedItem).ID);
                win2.Show();
            }
        }

        private bool ValidarIDGrid()
        {
            bool Retorno = false;
            if ((PesquisarCompraGado)grdConsultaCompraGado.SelectedItem == null)
                MessageBox.Show("Selecione uma linha do Grid.",
                     "Preenchimeto Obrigatorio",
                     MessageBoxButton.OK,
                     MessageBoxImage.Error);
            else
                Retorno = true;

            return Retorno;
        }

        private bool ValidarImprimir()
        {
            bool Retorno = false;

            if (Imprimiu.Contains(((PesquisarCompraGado)grdConsultaCompraGado.SelectedItem).ID))
                MessageBox.Show("Essa Compra já foi impressa, não é possível executar essa ação.",
                                 "Compra já foi impressas",
                                 MessageBoxButton.OK,
                                 MessageBoxImage.Error);
            else
                Retorno = true;

            return Retorno;
        }

        private void Carrega()
        {

            txtHost.Text = ConfigurationSettings.AppSettings["Endpoint_WebApi"].ToString();

            var jsonString = JSONHelper.GetJSONString(txtHost.Text + @"/api/CompraGado/GetListaCompraGado");

            _LstPesquisarCompraGado = JsonConvert.DeserializeObject<List<PesquisarCompraGado>>(jsonString);
            _LstPesquisarCompraGadoFiltro = AtualizarContador(_LstPesquisarCompraGado);

            grdConsultaCompraGado.ItemsSource = _LstPesquisarCompraGadoFiltro.Where(T => T.Count <= Paginacao).ToList();
            grdConsultaCompraGado.DataContext = _LstPesquisarCompraGadoFiltro.Where(T => T.Count <= Paginacao).ToList();


            jsonString = JSONHelper.GetJSONString(txtHost.Text + @"/api/CompraGado/GetListaPecuaristas");

            _LstPecuarista = JsonConvert.DeserializeObject<List<Pecuarista>>(jsonString);

            cboPecuarista.ItemsSource = _LstPecuarista;

            Imprimiu = new List<long>();

        }

        private void BtnPesquisa_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCamposPesquisa())
            {
                Paginacao = 10;
                _LstPesquisarCompraGadoFiltro = AtualizarContador(_LstPesquisarCompraGado.Where(T =>
                                                                                T.ID == (string.IsNullOrWhiteSpace(txtID.Text) ? T.ID : Int32.Parse(txtID.Text)) &&
                                                                                T.PecuaristaID == (string.IsNullOrWhiteSpace(cboPecuarista.Text) ? T.PecuaristaID : Int32.Parse(cboPecuarista.SelectedValue.ToString())) &&
                                                                                T.DataEntrega >= (string.IsNullOrWhiteSpace(txtDataEntrega.Text) ? T.DataEntrega : DateTime.Parse(txtDataEntrega.Text)) &&
                                                                                T.DataEntrega <= (string.IsNullOrWhiteSpace(txtAte.Text) ? T.DataEntrega : DateTime.Parse(txtAte.Text))
                                                                              ).ToList());

                grdConsultaCompraGado.ItemsSource = _LstPesquisarCompraGadoFiltro.Where(T => T.Count <= Paginacao).ToList();
                grdConsultaCompraGado.DataContext = _LstPesquisarCompraGadoFiltro.Where(T => T.Count <= Paginacao).ToList();

                txtID.Text = "";
                cboPecuarista.Text = "";
                txtDataEntrega.Text = "";
                txtAte.Text = "";

                grdConsultaCompraGado.Items.Refresh();
            }

        }

        private bool ValidarCamposPesquisa()
        {
            bool Retorno = true;

            if (string.IsNullOrWhiteSpace(txtID.Text) && string.IsNullOrWhiteSpace(txtDataEntrega.Text) && string.IsNullOrWhiteSpace(txtAte.Text) && string.IsNullOrWhiteSpace(cboPecuarista.Text))
            {
                MessageBox.Show("É obrigatório o preenchimento de pelo menos um dos filtros para consulta.",
                 "Preenchimeto Obrigatorio",
                 MessageBoxButton.OK,
                 MessageBoxImage.Error);
                Retorno = false;
            }
            else
            {

                if (!(string.IsNullOrWhiteSpace(txtID.Text)))
                    if (!(int.TryParse(txtID.Text, out int n1)))
                    {
                        MessageBox.Show("O preenchimento do campo ID deve ser do tipo númerico.",
                         "Preenchimeto Obrigatorio",
                         MessageBoxButton.OK,
                         MessageBoxImage.Error);
                        Retorno = false;
                    }

                if (!(string.IsNullOrWhiteSpace(txtDataEntrega.Text)) && Retorno)
                    if (!(DateTime.TryParseExact(txtDataEntrega.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data)))
                    {
                        MessageBox.Show("O preenchimento do campo Data Entrega deve ser do tipo Data.",
                                         "Tipo",
                                         MessageBoxButton.OK,
                                         MessageBoxImage.Error);
                        Retorno = false;
                    }

                if (!(string.IsNullOrWhiteSpace(txtAte.Text)) && Retorno)
                    if (!(DateTime.TryParseExact(txtAte.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data)))
                    {
                        MessageBox.Show("O preenchimento do campo Até deve ser do tipo Data.",
                                         "Tipo",
                                         MessageBoxButton.OK,
                                         MessageBoxImage.Error);
                        Retorno = false;
                    }
            }

            return Retorno;
        }

        public List<PesquisarCompraGado> AtualizarContador(List<PesquisarCompraGado> PesquisarCompraGadoAlterar)
        {
            long iCount = 1;
            foreach (PesquisarCompraGado _PesquisarCompraGado in PesquisarCompraGadoAlterar)
            {
                _PesquisarCompraGado.Count = iCount;
                iCount++;
            }
            return PesquisarCompraGadoAlterar;
        }

        private void btnPaginacaoDireita_Click(object sender, RoutedEventArgs e)
        {
            if (_LstPesquisarCompraGadoFiltro.Where(T => T.Count > Paginacao && T.Count <= (Paginacao * 2)).Count() > 0)
            {
                Paginacao = Paginacao * 2;
                grdConsultaCompraGado.ItemsSource = _LstPesquisarCompraGadoFiltro.Where(T => T.Count > (Paginacao / 2) && T.Count <= Paginacao).ToList();
                grdConsultaCompraGado.DataContext = _LstPesquisarCompraGadoFiltro.Where(T => T.Count > (Paginacao / 2) && T.Count <= Paginacao).ToList();
                grdConsultaCompraGado.Items.Refresh();
            }
        }

        private void BtnPaginacaoEsquerda_Click(object sender, RoutedEventArgs e)
        {
            if (Paginacao != 10)
            {
                Paginacao = Paginacao / 2;
                grdConsultaCompraGado.ItemsSource = _LstPesquisarCompraGadoFiltro.Where(T => T.Count > (Paginacao == 10 ? 0:(Paginacao/2)) &&  T.Count <= Paginacao).ToList();
                grdConsultaCompraGado.DataContext = _LstPesquisarCompraGadoFiltro.Where(T => T.Count > (Paginacao == 10 ? 0:(Paginacao/2)) &&  T.Count <= Paginacao).ToList();
                grdConsultaCompraGado.Items.Refresh();
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarIDGrid() && ValidarImprimir())
            {
                long _ID = ((PesquisarCompraGado)grdConsultaCompraGado.SelectedItem).ID;

                MessageBoxResult result = MessageBox.Show(String.Format("Deseja exluir o item {0}", _ID.ToString()),
                                          "Confirmação",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var url = txtHost.Text + @"/api/CompraGado/ExcluirItem";
                    var obj = JsonConvert.SerializeObject((new CompraGadoRep { ID = _ID }));

                    Retorno _Retorno = JSONHelper.Post(url, obj);

                    if (_Retorno.Sucesso)
                    {
                        var jsonString = JSONHelper.GetJSONString(txtHost.Text + @"/api/CompraGado/GetListaCompraGado");
                        _LstPesquisarCompraGado = JsonConvert.DeserializeObject<List<PesquisarCompraGado>>(jsonString);
                        _LstPesquisarCompraGadoFiltro = AtualizarContador(_LstPesquisarCompraGado);
                        grdConsultaCompraGado.ItemsSource = _LstPesquisarCompraGadoFiltro.Where(T => T.Count <= 10);
                        grdConsultaCompraGado.DataContext = _LstPesquisarCompraGadoFiltro.Where(T => T.Count <= 10);
                        grdConsultaCompraGado.Items.Refresh();

                        MessageBox.Show("Compra Excluida com sucesso.",
                                     "Sucesso",
                                     MessageBoxButton.OK,
                                     MessageBoxImage.Information);
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
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarIDGrid())
            {
                PesquisarCompraGado _PesquisarCompraGado = (PesquisarCompraGado)grdConsultaCompraGado.SelectedItem;
                Imprimiu.Add(_PesquisarCompraGado.ID);
                Relatorio win2 = new Relatorio(txtHost.Text, _PesquisarCompraGado.ID);
                win2.Show();
            }
        }

        private void UpdateKey_Click(object sender, RoutedEventArgs e)
        {
            string strKey = "Endpoint_WebApi";
            string newValue = txtHost.Text;

            MessageBoxResult result = MessageBox.Show(String.Format("Deseja atualizar o Endepoint para {0}", txtHost.Text),
                          "Confirmação",
                          MessageBoxButton.YesNo,
                          MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config");

                XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

                foreach (XmlNode childNode in appSettingsNode)
                {
                    if (childNode.Attributes["key"].Value == strKey)
                        childNode.Attributes["value"].Value = newValue;
                }
                xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config");
                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                MessageBox.Show("Atualização executada com sucesso.",
                 "Sucesso",
                 MessageBoxButton.OK,
                 MessageBoxImage.Information);

            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Paginacao = 10;

            txtID.Text = "";
            cboPecuarista.Text = "";
            txtDataEntrega.Text = "";
            txtAte.Text = "";

            _LstPesquisarCompraGadoFiltro = AtualizarContador(_LstPesquisarCompraGado.Where(T =>
                                                                            T.ID == (string.IsNullOrWhiteSpace(txtID.Text) ? T.ID : Int32.Parse(txtID.Text)) &&
                                                                            T.PecuaristaID == (string.IsNullOrWhiteSpace(cboPecuarista.Text) ? T.PecuaristaID : Int32.Parse(cboPecuarista.SelectedValue.ToString())) &&
                                                                            T.DataEntrega >= (string.IsNullOrWhiteSpace(txtDataEntrega.Text) ? T.DataEntrega : DateTime.Parse(txtDataEntrega.Text)) &&
                                                                            T.DataEntrega <= (string.IsNullOrWhiteSpace(txtAte.Text) ? T.DataEntrega : DateTime.Parse(txtAte.Text))
                                                                          ).ToList());

            grdConsultaCompraGado.ItemsSource = _LstPesquisarCompraGadoFiltro.Where(T => T.Count <= Paginacao).ToList();
            grdConsultaCompraGado.DataContext = _LstPesquisarCompraGadoFiltro.Where(T => T.Count <= Paginacao).ToList();

            grdConsultaCompraGado.Items.Refresh();
        }
    }
}
