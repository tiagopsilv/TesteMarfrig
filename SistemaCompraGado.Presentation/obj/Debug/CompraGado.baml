   M S B A M L   `   `   `  ����Y  USistemaCompraGado.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SistemaCompraGado.PresentationSistemaCompraGado.Presentation  5   	   /    )SistemaCompraGado.Presentation.CompraGado   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:SistemaCompraGado.Presentation     5   	     � Title$  
CompraGado��5   	   $	��450��6   $	��800��6)   .��5	      � $��	0,0,0,-12q�6   .+�5
   
   �� $��Compra Gado��6   $
��Left=�6&   $��	10,10,0,0q�6A   $	��Top=�6T   �� 5   
   -   5        $��txtID��5   a   $
��Left=�6   $��23��6-   $��
107,48,0,0q�69    �� TextWrapping$
 Wrap=�6M   $�� ��6n   $	��Top=�6v   $	��120��6�   �� 5   
   $��ID��6   $
��Left=�6   $��28��68   $��	74,46,0,0q�6D   $	��Top=�6W   $��26��6o   �� 5   
   $��Data de Entrega��6   $
��Left=�6*   $��	10,76,0,0q�6E   $	��Top=�6X   �� 5   
   -   5        $��txtDtEntrega��5   M   $
��Left=�6   $��23��6-   $��
107,79,0,0q�69   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5   
   $��
Pecuarista��6   $
��Left=�6%   $��
245,76,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $��cboPecuarista��5   f   $
��Left=�6   $��
325,79,0,0q�6.   $	��Top=�6B   $	��424��6Z    �� DisplayMemberPath$
 Nome��6�    �� SelectedValuePath$ ID��6�   ��6{   �� *LstPecuarista+6�   �� 5   
   $��Animal��6   $
��Left=�6!   $��
10,116,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $��btnAdicionar��5   @   $��	Adicionar��6   $
��Left=�6%   $��
10,147,0,0q�6T   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5        $��
btnExcluir��5   >   $��Excluir��6   $
��Left=�6#   $��
99,147,0,0q�6P   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $��
btnAlterar��5   >   $��Alterar��6   $
��Left=�6#   $��187,147,0,0q�6P   $	��Top=�6e   $��75��6}   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��grdItens��5   O   $
��Left=�6   $	��117��6.   $��
10,187,0,0q�6;   $	��Top=�6_   $	��772��6w      AutoGenerateColumns .     
IsReadOnly . ��6�   ��  �� Source$ LstAnimalGrid��   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Animal��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 65   �� *DescricaoAnimal+  5      $ 
Quantidade��6%   	 69   �� *
Quantidade+  5      $ Preço��6%   	 64   �� *Preco+  5      $ Valor Total��6%   	 6:   �� *
ValorTotal+5      �� 5   
   -   5        $��lblModificar��5   $   $��	Adicionar��6   $
��Left=�68   $��
10,341,0,0q�6S   $	��Top=�6g   �� 5   
   -	   5        $��	cboAnimal��5   :   $
��Left=�6   $��26��6.   $��
75,368,0,0q�6K   $	��Top=�6_   $	��199��6w   $ 	Descricao��6�   $ ID��6�   ��6�   �� *	LstAnimal+6�   �� 5   
   -
   5        $��	lblAnimal��5   !   $��Animal��6   $
��Left=�62   $��29��6M   $��
10,368,0,0q�6Y   $	��Top=�6m   $��60��6�   �� 5    
   -   5        $��lblQuantidade��5    %   $��
Quantidade��6   $
��Left=�6:   $��26��6U   $��287,368,0,0q�6a   $	��Top=�6v   $��73��6�   �� 5!   
   -   5        $��txtQuantidade��5!   9   $
��Left=�6   $��26��6-   $��376,368,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��155��6�   �� 5"   
   -   5        $��	btnSalvar��5"   "   $��Salvar��6   $
��Left=�63   $��29��6N   $��551,368,0,0q�6Z   $	��Top=�6o   $	��103��6�   6�   �� 5#   
   -   5        
 ��Name$
 btnCancelar��5#   $   $��Cancelar��6   $
��Left=�69   $��29��6T   $��667,368,0,0q�6`   $	��Top=�6u   $	��103��6�   6�   �� 5$   
   -   5        $��lblTotal��5$   "   $��Total: ��6   $
��Left=�62   $��648,309,0,0q�6M   $	��Top=�6b   $	��134��6z   �� 5%   
   -   5        $
 btnGravarCompra��5%   )   $��Gravar Compra��6   $
��Left=�6B   $��29��6]   $��667,367,0,0q�6i   $	��Top=�6~   $	��103��6�   6�   5'      5(      