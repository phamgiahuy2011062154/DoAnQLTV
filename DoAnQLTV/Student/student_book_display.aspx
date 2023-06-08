<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="student_book_display.aspx.cs" Inherits="DoAnQLTV.Student.student_book_display" %>
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
                                          
                                       </tr>
                                    </thead>
                                     <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                      <td><img src = "../Librarian/<%#Eval("book_image") %>" height="150" width="90"></td>
                                      <td><%# Eval("book_name")%></td>
                                      <td><%# Eval("book_author")%></td>
                                      <td><%# Eval("book_isbn")%></td>
                                      <td><%# Eval("available_quantity")%></td>
                                     
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
