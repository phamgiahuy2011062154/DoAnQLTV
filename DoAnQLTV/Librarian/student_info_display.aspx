<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="student_info_display.aspx.cs" Inherits="DoAnQLTV.Librarian.student_info_display" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
        <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
        <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <asp:Repeater ID="stdDisplay" runat="server">
              <HeaderTemplate>
            <table class="table table-bordered" id="example">
                <thead>
                <tr>
                    <th>Tên người dùng::</th>
                    <th>MSSV:</th>
                    <th>Họ tên: </th>
                    <th>Email:</th>
                    <th>SDT:</th>
                    <th>Đang hoạt động</th>
                    <th>Gửi tin nhắn</th>
                    <th>Bật hoạt động</th>
                    <th>Tắt hoạt động</th>
                </tr>
                    </thead>
                <tbody>
        </HeaderTemplate>          
        <ItemTemplate>
            <tr>
                <td><%#Eval("username") %></td>
                <td><%#Eval("mssv") %></td>
                <td><%#Eval("fullname") %></td>
                <td><%#Eval("email") %></td>
                <td><%#Eval("sdt") %></td>
                <td><%#Eval("approved") %></td>
                <td><a href="communication.aspx?username=<%#Eval("username") %>">Gửi</a></td>
                <td><a href="activate.aspx?Id=<%#Eval("Id") %>">Bật</a></td>
                <td><a href="deactivate.aspx?Id=<%#Eval("Id") %>">Tắt</a></td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
            
    </asp:Repeater>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "pagingType": "full_numbers"
            });
        });
    </script>
</asp:Content>
