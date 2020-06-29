<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjP2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style4 {
            display: block;
            width: 100%;
            height: calc(1.5em + .75rem + 2px);
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            margin-left: 92px;
            background-color: #fff;
        }
        .auto-style5 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 66.666667%;
            flex: 0 0 66.666667%;
            max-width: 66.666667%;
            left: 5px;
            top: 211px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style6 {
          position: relative;
          width: 100%; 
         -ms-flex: 0 0 16.666667%;  
          flex: 0 0 16.666667%;     
          max-width: 16.666667%;  
         left: 0px;          
         top: 190px;           
        height: 58px;            
       padding-left: 15px;           
       padding-right: 15px;
        }
    </style>
</head>
<body>
    <div style="padding-top:2%"></div>
    <div class="col-sm-8">
    <h2>Loja Presentes</h2>
    </div>
    <div style="padding-top:2%"></div>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMSG" runat="server" Font-Bold="True" ForeColor="Purple"></asp:Label>
            
            <div class="col-sm-2">
                <div class="form-group">
                    <label for="TxtCodigo">Código</label>
                    <asp:TextBox ID="TxtCodigo" CssClass="form-control" runat="server" Width="206px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TxtDescricao">Descrição:</label>
                    <asp:TextBox ID="TxtDescricao" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>            

               

                 <div class="form-group">
                   <label for="DDLMarcas">Marcas:</label>
                    <asp:DropDownList ID="DDLMarcas" CssClass="auto-style4" runat="server"></asp:DropDownList>
                </div>

                 <div class="form-group">
                   <label for="DDLFinalidades">Finalidades:</label>
                    <asp:DropDownList ID="DDLFinalidades" CssClass="auto-style4" runat="server"></asp:DropDownList>
                </div>

                 <div class="form-group">
                   <label for="DDLTipos">Tipos:</label>
                    <asp:DropDownList ID="DDLTipos" CssClass="auto-style4" runat="server"></asp:DropDownList>
                </div>



                <div class="form-group">
                    <label for="TxtCor">Cor</label>
                    <asp:TextBox ID="TxtCor" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="TxtTamanho">Tamanho</label>
                    <asp:TextBox ID="TxtTamanho" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="TxtPreco">Preço:</label>
                    <asp:TextBox ID="TxtPreco" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>

                 <div class="form-group">
                   <label for="DDLFornecedores">Fornecedores:</label>
                    <asp:DropDownList ID="DDLFornecedores" CssClass="auto-style4" runat="server"></asp:DropDownList>
                </div>   
                
                 <div class="auto-style6">
                <div class="form-group">
                    <asp:Button ID="BtnSalvar" runat="server" CssClass="btn btn-primary" OnClick="BtnSalvar_Click" Text="Inserir" />
                </div>     
            </div>               
            
              <div class="auto-style6">                  
                <div class="form-group">
                    <asp:Button ID="BtnCadastrarTipo" runat="server" CssClass="btn btn-primary" OnClick="BtnCadastrarTipo_Click" Text="Cadastrar Tipo" />
                       
                    </div>
                   </div>           
          

              <div class="auto-style6">
                <div class="form-group">
                    <asp:Button ID="BtnCadastrarMarca" runat="server" CssClass="btn btn-primary" OnClick="BtnCadastrarMarca_Click" Text="Cadastrar Marca" />
                       
                    </div>
            </div>
              <div class="auto-style6">
                <div class="form-group">
                    <asp:Button ID="BtnCadastrarFornecedor" runat="server" CssClass="btn btn-primary" OnClick="BtnCadastrarFornecedor_Click" Text="Cadastrar Fornecedor" />
                       
                    </div>
            </div>
              <div class="auto-style6">
                <div class="form-group">
                    <asp:Button ID="BtnCadastrarFinalidade" runat="server" CssClass="btn btn-primary" OnClick="BtnCadastrarFinalidade_Click" Text="Cadastrar Finalidade" />
                       
                    </div>
            </div>

          

             <div class="auto-style5">
                 <h2>Dados</h2>   
            <asp:GridView ID="GVPresente" CssClass="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Código" />
                    <asp:BoundField DataField="Descricao" HeaderText="Descricao" />
                    <asp:BoundField DataField="Descricao" HeaderText="Tipo" />
                    <asp:BoundField DataField="Descricao" HeaderText="Marca" />
                    <asp:BoundField DataField="Descricao" HeaderText="Finalidade" />
                     <asp:BoundField DataField="Cor" HeaderText="Cor" />
             <asp:BoundField DataField="Tamanho" HeaderText="Tamanho" />
             <asp:BoundField DataField="Preco" HeaderText="Preco" />
             <asp:BoundField DataField="Descricao" HeaderText="Fornecedor" />
            

                    
                </Columns>
                <EditRowStyle BackColor="#008000" />
                <FooterStyle BackColor="#9400D3" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#9400D3" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#7B68EE" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#00BFFF" />
                <SortedDescendingHeaderStyle BackColor="#00FFFF" />
            </asp:GridView>
                 </div>
        </div>
    </form>
</body>
</html>
