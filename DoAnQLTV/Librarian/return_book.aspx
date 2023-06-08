<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="return_book.aspx.cs" Inherits="DoAnQLTV.Librarian.return_book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

     <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Sách đã mượn:</h1>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid" style="min-height:500px; background-color:white">
        <asp:DataList ID="isData" runat="server">
            <HeaderTemplate>
                <table class="table table-bordered">
                    <tr>
                        <th>Tên người dùng:</th>
                        <th>MSSV:</th>
                        <th>ISBN:</th>
                        <th>Ngày mượn:</th>
                        <th>Ngày phải trả</th>
                        <th>Đã trả sách:</th>
                        <th>Ngày trả sách</th>
                        <th>Số ngày trễ hạn:</th>
                        <th>Số tiền phạt:</th>
                        <th>Trả sách:</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("user_muon") %></td>
                    <td><%#Eval("mssv_muon") %></td>
                    <td><%#Eval("isbn_muon") %></td>
                    <td><%#Eval("ngay_muon") %></td>
                    <td><%#Eval("ngay_tra") %></td>
                    <td><%#Eval("sach_da_tra") %></td>
                    <td><%#Eval("ngay_tra_sach") %></td>
                    <td><%#Eval("so_ngay_tre") %></td>
                    <td><%#Eval("penalty") %></td>
                    <td><a href="return.aspx?id=<%#Eval("Id") %>">Trả</a></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>
    </div>

</asp:Content>
