   M S B A M L   `   `   `  ���� Y  USistemaCompraGado.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SistemaCompraGado.PresentationSistemaCompraGado.Presentation  /    )SistemaCompraGado.Presentation.CompraGado   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     >local,clr-namespace:SistemaCompraGado.Presentation       � Title$  
CompraGado��$	��450��$	��800��.��� $��	0,0,0,-12q�.+��� $��Compra Gado��$
��Left=�$��	10,10,0,0q�$	��Top=��� -   $��txtID��$
��Left=�$��23��$��
107,48,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��120���� $��ID��$
��Left=�$��28��$��	74,46,0,0q�$	��Top=�$��26���� $��Data de Entrega��$
��Left=�$��	10,76,0,0q�$	��Top=��� -   $��txtDtEntrega��$
��Left=�$��23��$��
107,79,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� $��
Pecuarista��$
��Left=�$��
245,76,0,0q�$	��Top=��� -   $��cboPecuarista��$
��Left=�$��
325,79,0,0q�$	��Top=�$	��424�� �� DisplayMemberPath$
 Nome�� �� SelectedValuePath$ ID������ *LstPecuarista+�� $��Animal��$
��Left=�$��
10,116,0,0q�$	��Top=��� -   $��btnAdicionar��$��	Adicionar��$
��Left=�$��
10,147,0,0q�$	��Top=�$��75���� -   $��
btnExcluir��$��Excluir��$
��Left=�$��
99,147,0,0q�$	��Top=�$��75���� -   $��
btnAlterar��$��Alterar��$
��Left=�$��187,147,0,0q�$	��Top=�$��75��&   System.Windows.Controls.DataGrid  -   $��grdItens��$
��Left=�$	��117��$��
10,187,0,0q�$	��Top=�$	��772��   AutoGenerateColumns .     
IsReadOnly . ����  �� Source$ LstAnimalGrid��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Animal��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *DescricaoAnimal+  $ 
Quantidade��	 �� *
Quantidade+  $ Preço��	 �� *Preco+  $ Valor Total��	 �� *
ValorTotal+�� -   $��lblModificar��$��	Adicionar��$
��Left=�$��
10,341,0,0q�$	��Top=��� -	   $��	cboAnimal��$
��Left=�$��26��$��
75,368,0,0q�$	��Top=�$	��199��$ 	Descricao��$ ID������ *	LstAnimal+�� -
   $��	lblAnimal��$��Animal��$
��Left=�$��29��$��
10,368,0,0q�$	��Top=�$��60���� -   $��lblQuantidade��$��
Quantidade��$
��Left=�$��26��$��287,368,0,0q�$	��Top=�$��73���� -   $��txtQuantidade��$
��Left=�$��26��$��376,368,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��155���� -   $��	btnSalvar��$��Salvar��$
��Left=�$��29��$��551,368,0,0q�$	��Top=�$	��103���� -   
 ��Name$
 btnCancelar��$��Cancelar��$
��Left=�$��29��$��667,368,0,0q�$	��Top=�$	��103���� -   $��lblTotal��$��Total: ��$
��Left=�$��648,309,0,0q�$	��Top=�$	��134���� -   $
 btnGravarCompra��$��Gravar Compra��$
��Left=�$��29��$��667,367,0,0q�$	��Top=�$	��103��