<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="add_book.aspx.cs" Inherits="DoAnQLTV.Librarian.add_book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
      <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Add new book:</strong>
                        </div>
                        <div class="card-body">
                        
                         
                                  
                                  <form action="" id="formAddBook" runat="server" method="post" novalidate="novalidate">
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Tiêu đề sách:</label>
                                          <asp:TextBox ID="booktitle" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Ảnh của sách:</label>
                                          <asp:FileUpload ID="bookimage" runat="server" class="form-control"></asp:FileUpload>
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Tác giả:</label>
                                          <asp:TextBox ID="authorname" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Số lượng:</label>
                                          <asp:TextBox ID="quantity" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                          <asp:Button ID="buttonAddBook" runat="server" class="btn btn-lg btn-info btn-block" text="Add Book" OnClick="buttonAddBook_Click" />
                                      </div>
                                      <div class="alert alert-success" id="addSuccess" runat="server" style="margin-top:10px; display:none">
                                          <strong> Thêm sách thành công! </strong> 
                                      </div>
                                  </form>
                              </div>
                          
                    </div> <!-- .card -->

                  </div><!--/.col-->
</asp:Content>
