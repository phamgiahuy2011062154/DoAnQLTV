<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="edit_book.aspx.cs" Inherits="DoAnQLTV.Librarian.edit_book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Update sách:</strong>
                        </div>
                        <div class="card-body">
                        
                         
                                  
                                  <form action="" id="formAddBook" runat="server" method="post" novalidate="novalidate">
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Tiêu đề sách:</label>
                                          <asp:TextBox ID="booktitle" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Ảnh của sách:</label>
                                          <asp:Label ID="booksimage" runat="server" Text=""></asp:Label>
                                          <asp:FileUpload ID="bookimage" runat="server" class="form-control"></asp:FileUpload>
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Tác giả:</label>
                                          <asp:TextBox ID="authorname" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">ISBN:</label>
                                          <asp:TextBox ID="isbn" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Số lượng:</label>
                                          <asp:TextBox ID="quantity" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                          <asp:Button ID="buttonAddBook" runat="server" class="btn btn-lg btn-info btn-block" text="Update Sách" OnClick="buttonAddBook_Click"/>
                                      </div>
                                      
                                  </form>
                              </div>
                          
                    </div> <!-- .card -->

                  </div><!--/.col-->
</asp:Content>
