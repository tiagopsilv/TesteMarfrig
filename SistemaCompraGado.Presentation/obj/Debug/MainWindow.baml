   M S B A M L   `   `   `  ����Y  USistemaCompraGado.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SistemaCompraGado.PresentationSistemaCompraGado.Presentation  5   	   /    )SistemaCompraGado.Presentation.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:SistemaCompraGado.Presentation     5   	     � Title$  
MainWindow��5   	   $��442.07��6   $	��800��6,   .��5	      � .+�5
   
   � $
��Left=�6   $	��409��6/   $	��Top=�6<   $	��782��6T   .+�5      �� $��	LocalHost��6   $��54��6*   $	��221��66   .��5      �� -   5         ��Name$ txtHost��5   5   $
��Left=�6   $��23��6F   $��
10,10,0,-1q�6R    �� TextWrapping$
 Wrap=�6f   $��https://localhost:44361��6z   $	��Top=�6�   $	��192��6�   5      �� 5      -   5        $��	UpdateKey��5   2   $��Atualizar EndPoint��6   $��38��6C   $	��147��6O   6[   � 5      $	��353��6   $	��782��6     � ColumnDefinitions 5      �� 5      $
��579* �6'   �� 5      $
��203* �6'   .+�5      �� -   5        $��btnPesquisa��5   -   $��	Pesquisar��6   $��10,10,470.819,313q�6A   6\   �� 5      -   5        $��btnAdicionar��5   -   $��	Adicionar��6   $��216,10,264.819,313q�6\   �� 5      -   5        $��btnImprimir��5   ,   $��Imprimir��6   $��113,10,367.819,313q�6@   6\   �� 5      -   5         ��Name$ 
btnAlterar��5   +   $��Alterar��6   $��319,10,161.819,313q�6@   6\   �� 5      -   5        $ 
btnExcluir��5   +   $��Excluir��6   $��422,10,58.819,313q�6@   6[   �� 5      $��ID��6   $
��Left=�6%   $��	99,53,0,0q�6@   $	��Top=�6S    J� RenderTransformOrigin$ -4.338,-0.206&�6k   $��26��6�   �� 5      $��Data de entrega de ��6   $
��Left=�66   $��	10,84,0,0q�6Q   $	��Top=�6d   �� 5      -   5        $��txtID��5   5   $
��Left=�6   $��26��6B   $��
130,53,0,0q�6N   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��184��6�   �� 5      -	   5        $��txtDataEntrega��5   5   $
��Left=�6   $��26��6K   $��
130,84,0,0q�6W   $
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��184��6�   �� 5      $��
Pecuarista��6   $
��Left=�6-   $��
342,53,0,0q�6H   $	��Top=�6\   �� 5      $
��Até��6   $
��Left=�6&   $��
377,84,0,0q�6A   $	��Top=�6U   �� 5      -
   5        $��txtAte��5   5   $
��Left=�6   $��26��6C   $��
410,84,0,0q�6O   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��215��6�   $��2��6�   �� 5       -   5        $��cboPecuarista��5    6   $
��Left=�6   $��26��6K   $��
410,53,0,0q�6W   $	��Top=�6k   $	��215��6�    �� DisplayMemberPath$
 Nome��6�    �� SelectedValuePath$ ID��6�   $��2��6�   ��6�   �� *LstPecuarista+6�   &   System.Windows.Controls.DataGrid  5!      -   5        $��grdConsultaCompraGado��5!   6   $
��Left=�6   $	��180��6S   $��
10,115,0,0q�6`   $	��Top=�6t   $	��762��6�      AutoGenerateColumns .  	   
IsReadOnly	 . $��2��6  ��6�   �� 
 �� Source$"
 LstPesquisarCompraGadoFiltro��   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *ID+  5$      $ 
Pecuarista��6-    6A   �� *NomePecuarista+  5%      $ Data Entrega��6-    6C   �� *DataEntrega+ �� StringFormat$ {0:dd/MM/yyyy}��  5&      $ Valor Total��6-    6B   �� *
ValorTotal+5(      �� 5)      -   5        $��btnPaginacaoEsquerda��5)   @   $��«��6   $
��Left=�6%   $��35��6\   $��297,300,0,0q�6h   $	��Top=�6}   $��52��6�   6�   �� 5*      -   5        $��btnPaginacaoDireita��5*   @   $��»��6   $
��Left=�6%   $��35��6[   $��363,300,0,0q�6g   $	��Top=�6|   $��52��6�   6�   �� 5+      -   5        $��Listar Todos��5+      $
��Left=�60   $��33��6K   $��96.181,7,0,0q�6W   $	��Top=�6m   $��97��6�   $��1��6�   5,      �� 5-      $��Label��6   5.      �� 5/   
   $��Tiago Pereira da Silva��6   $
��Left=�61   $��648,374,0,0q�6L   $	��Top=�6a   50      51      