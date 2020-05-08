using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using SistemaCompraGado.Presentation.Negocios.Entities;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SistemaCompraGado.Presentation
{
    /// <summary>
    /// Lógica interna para Relatorio.xaml
    /// </summary>
    public partial class Relatorio : Window
    {

        private string _host = @"https://localhost:44361";
        public List<CompraGadoItemPrint> LstCompraGadoItemPrint;
        public List<Pecuarista> LstPecuarista;
        public List<Animal> LstAnimal;

        public Relatorio(string host, long ID)
        {
            InitializeComponent();
            _host = host;
            Carregar(ID);
        }

        private void Carregar( long ID)
        {

            var jsonString = JSONHelper.GetJSONString(_host + @"/api/CompraGado/GetListaPecuaristas");

            LstPecuarista = JsonConvert.DeserializeObject<List<Pecuarista>>(jsonString);

            jsonString = JSONHelper.GetJSONString(_host + @"/api/CompraGado/GetListaAnimal");

                LstAnimal = JsonConvert.DeserializeObject<List<Animal>>(jsonString);

                jsonString = JSONHelper.GetJSONString(_host + @"/api/CompraGado/GetListaCompraGadoByID/" + ID.ToString());

                CompraGadoRep CompraGado = JsonConvert.DeserializeObject<CompraGadoRep>(jsonString);

                LstCompraGadoItemPrint = new List<CompraGadoItemPrint>();

            foreach (CompraGadoItem _CompraGadoItem in CompraGado.CompraDadoItem)
                LstCompraGadoItemPrint.Add(new CompraGadoItemPrint {
                            ID = CompraGado.ID,
                            DataEmtrega = CompraGado.DataEntrega,
                            NomePecuarista = LstPecuarista.Where(T => T.ID == CompraGado.PecuaristaID).First().Nome,
                            DescricaoAnimal = LstAnimal.Where(T => T.ID == _CompraGadoItem.AnimalID).First().Descricao,
                            Preco = decimal.Parse(LstAnimal.Where(T => T.ID == _CompraGadoItem.AnimalID).First().Preco),
                            Quantidade = long.Parse(_CompraGadoItem.Quantidade),
                            ValorTotal = (decimal.Parse(LstAnimal.Where(T => T.ID == _CompraGadoItem.AnimalID).First().Preco.ToString()) * Int32.Parse(_CompraGadoItem.Quantidade)) });

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dsListaAnimal"; //nome do DataSet no .rdlc
                reportDataSource.Value = LstCompraGadoItemPrint; // objeto(lista) de dados
                this._reportViewer.LocalReport.DataSources.Add(reportDataSource);
 
                //carrega o relatorio que deve estar na pasta do executavel. o arquivo rdlc deve estar CopyToLocal
                this._reportViewer.LocalReport.ReportPath = "../../Relatorio.rdlc";
                this._reportViewer.RefreshReport();

        }


    }
}
