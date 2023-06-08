<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="issue.aspx.cs" Inherits="DoAnQLTV.Librarian.issue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
      <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Issue book:</strong>
                        </div>
                        <div class="card-body">
                                  <form action="" id="formIssueBook" runat="server" method="post" novalidate="novalidate">
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Tên người dùng:</label>
                                          <asp:DropDownList ID="username" runat="server" class="form-control"></asp:DropDownList>
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">ISBN:</label>
                                          <asp:DropDownList ID="isbn" runat="server" class="form-control" OnSelectedIndexChanged="isbn_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                      </div>
                                      <div class="form-group">
                                          <asp:Image id="img" runat="server" height="150" width="80"/><br/>
                                          <asp:Label id="bookname" runat="server"></asp:Label> <br />
                                          <asp:Label id="qty" runat="server"></asp:Label><br />
                                      </div>
                                    
                                          <asp:Button ID="buttonIssueBook" runat="server" class="btn btn-lg btn-info btn-block" text="Mượn sách" OnClick="buttonIssueBook_Click"/>
                                      </div>
                                      
                                  </form>
                              </div>
                          
                    </div> <!-- .card -->

                  </div><!--/.col-->
</asp:Content>
