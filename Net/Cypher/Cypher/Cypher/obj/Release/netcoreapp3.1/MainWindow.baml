   M S B A M L   `   `   `  ���� A  =Cypher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CypherCypher      Cypher.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:Cypher       � Title$  
MainWindow��$	��450��$	��800��$��16(�.��� $��10q� � ColumnDefinitions �� $��* ��� $��* �.+��� $��0�� � 	Resources  �� 
TargetType �� Property �� Value��%2   '��       �� " ��.���  � ��$ 0,0,0,5q�.+��� $��Client��$��Center=�$	��Top=�$
��Wrap=��� $��Input���� -    ��Name$ ClientInput��$�� ��$
��Left=�$	��250���� -    ��Name$ CliAsymmetricMsg��$'��!Send Asymmetric Encrypted Message��$
��Left=�$��5q��� -   $ CliSymmetricMsg��$&�� Send Symmetric Encrypted Message��$
��Left=�$��5q��� -    ��Name$ CliEncryptedTxt��$�� ��$	��0,5q�$
��Wrap=��� -   $ CliDecryptedTxt��$�� ��$
��Wrap=��� $��1�� ��%2   '��       �� " ��.���  � ��$ 0,0,0,5q�.+��� $��Center=�$��Server��$
��Wrap=�$	��Top=��� $��Input���� -   $ ServerInput��$�� ��$
��Left=�$	��250���� -   $ ServSymmetricMsg��$&�� Send Symmetric Encrypted Message��$
��Left=�$��5q��� -   $ SerEncryptedTxt��$�� ��$	��0,5q�$
��Wrap=��� -	   $ SerDecryptedTxt��$�� ��$
��Wrap=�