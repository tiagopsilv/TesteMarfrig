   M S B A M L   `   `   `  ���� Y  USistemaCompraGado.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SistemaCompraGado.PresentationSistemaCompraGado.Presentation  /    )SistemaCompraGado.Presentation.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     >local,clr-namespace:SistemaCompraGado.Presentation       � Title$  
MainWindow��$��442.07��$	��800��.��� .+�� $
��Left=�$	��409��$	��Top=�$	��782��.+��� $��	LocalHost��$��54��$	��221��.���� -    ��Name$ txtHost��$
��Left=�$��23��$��
10,10,0,-1q� �� TextWrapping$
 Wrap=�$��https://localhost:44361��$	��Top=�$	��192���� -   $��	UpdateKey��$��Atualizar EndPoint��$��38��$	��147��� $	��353��$	��782�� � ColumnDefinitions �� $
��579* ��� $
��203* �.+��� -   $��btnPesquisa��$��	Pesquisar��$��10,10,470.819,313q��� -   $��btnAdicionar��$��	Adicionar��$��216,10,264.819,313q��� -   $��btnImprimir��$��Imprimir��$��113,10,367.819,313q��� -    ��Name$ 
btnAlterar��$��Alterar��$��319,10,161.819,313q��� -   $ 
btnExcluir��$��Excluir��$��422,10,58.819,313q��� $��ID��$
��Left=�$��	99,53,0,0q�$	��Top=� J� RenderTransformOrigin$ -4.338,-0.206&�$��26���� $��Data de entrega de ��$
��Left=�$��	10,84,0,0q�$	��Top=��� -   $��txtID��$
��Left=�$��26��$��
130,53,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��184���� -	   $��txtDataEntrega��$
��Left=�$��26��$��
130,84,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��184���� $��
Pecuarista��$
��Left=�$��
342,53,0,0q�$	��Top=��� $
��Até��$
��Left=�$��
377,84,0,0q�$	��Top=��� -
   $��txtAte��$
��Left=�$��26��$��
410,84,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��215��$��2���� -   $��cboPecuarista��$
��Left=�$��26��$��
410,53,0,0q�$	��Top=�$	��215�� �� DisplayMemberPath$
 Nome�� �� SelectedValuePath$ ID��$��2������ *LstPecuarista+&   System.Windows.Controls.DataGrid  -   $��grdConsultaCompraGado��$
��Left=�$	��180��$��
10,115,0,0q�$	��Top=�$	��762��   AutoGenerateColumns .  	   
IsReadOnly	 . $��2������ 
 �� Source$"
 LstPesquisarCompraGadoFiltro��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ID+  $ 
Pecuarista�� �� *NomePecuarista+  $ Data Entrega�� �� *DataEntrega+ �� StringFormat$ {0:dd/MM/yyyy}��  $ Valor Total�� �� *
ValorTotal+�� -   $��btnPaginacaoEsquerda��$��«��$
��Left=�$��35��$��297,300,0,0q�$	��Top=�$��52���� -   $��btnPaginacaoDireita��$��»��$
��Left=�$��35��$��363,300,0,0q�$	��Top=�$��52���� -   $��Listar Todos��$
��Left=�$��33��$��96.181,7,0,0q�$	��Top=�$��97��$��1���� $��Label���� $��Tiago Pereira da Silva��$
��Left=�$��648,374,0,0q�$	��Top=�