<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FTipo.aspx.cs" Inherits="ProjP2.FTipo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
.form-group{margin-bottom:1rem}*,::after,::before{text-shadow:none!important;box-shadow:none!important}*,::after,::before{box-sizing:border-box}label{display:inline-block;margin-bottom:.5rem}.form-control{transition:none}.form-control{display:block;width:100%;height:calc(1.5em + .75rem + 2px);padding:.375rem .75rem;font-size:1rem;font-weight:400;line-height:1.5;color:#495057;background-color:#fff;background-clip:padding-box;border:1px solid #ced4da;border-radius:.25rem;transition:border-color .15s ease-in-out,box-shadow .15s ease-in-out}
        .auto-style1 {
            width: 206px;
            font-family: inherit;
            font-size: inherit;
            line-height: inherit;
            overflow: visible;
            margin: 0;
        }
        .auto-style2 {
            width: 322px;
            font-family: inherit;
            font-size: inherit;
            line-height: inherit;
            overflow: visible;
            margin: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
                <div class="form-group">
                    <label for="TxtCodigo">
            <asp:Label ID="lblMSG" runat="server" Font-Bold="True" ForeColor="Purple"></asp:Label>
            
                    <br />
                    <br />
                    Código</label>
                    <asp:TextBox ID="TxtCodigo" CssClass="form-control" runat="server" Width="206px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TxtDescricao">Descrição:</label>
                    <asp:TextBox ID="TxtDescricao" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>
             

                <p>
                    <asp:Button ID="BtnSalvar" runat="server" CssClass="btn btn-primary" OnClick="BtnSalvar_Click" Text="Salvar" />
                </p>
            <asp:GridView ID="GVTipo" CssClass="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Código" />
                    <asp:BoundField DataField="Descricao" HeaderText="Descricao" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" />
                    <asp:BoundField DataField="Finalidade" HeaderText="Finalidade" />
                     <asp:BoundField DataField="Cor" HeaderText="Cor" />
             <asp:BoundField DataField="Tamanho" HeaderText="Tamanho" />
             <asp:BoundField DataField="Preco" HeaderText="Preco" />
             <asp:BoundField DataField="Fornecedor" HeaderText="Fornecedor" />
            

                    
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
    </form>
</body>
</html>
