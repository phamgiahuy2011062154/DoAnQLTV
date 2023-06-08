<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="book_display.aspx.cs" Inherits="DoAnQLTV.Librarian.book_display" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
        <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
        <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>


    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Danh sách sách:</strong>
                        </div>
                        <div class="card-body">
                            <asp:Repeater ID="reapeatdisplay" runat="server">
                                <HeaderTemplate>
                                 <table class="table" id="example">
                                    <thead>
                                        <tr>
                                          <th scope="col">Ảnh:</th>
                                          <th scope="col">Tiêu đề:</th>
                                          <th scope="col">Tác giả:</th>
                                          <th scope="col">ISBN:</th>
                                          <th scope="col">Số lượng tồn:</th>
                                          <th scope="col">Sửa sách:</th>
                                          <th scope="col">Xóa sách:</th>          

                                       </tr>
                                    </thead>
                                     <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                      <td><img src = "<%#Eval("book_image") %>" height="150" width="90"></td>
                                      <td><%# Eval("book_name")%></td>
                                      <td><%# Eval("book_author")%></td>
                                      <td><%# Eval("book_isbn")%></td>
                                      <td><%# Eval("available_quantity")%></td>
                                      <td><a href="edit_book.aspx?id=<%#Eval("id") %>">Sửa sách</a></td>
                                      <td><a href="delete_book.aspx?id=<%#Eval("id") %>">Xóa sách</a></td>

                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                     </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "pagingType": "full_numbers"
            });
        });
    </script>
</asp:Content>
