<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="add_penalty.aspx.cs" Inherits="DoAnQLTV.Librarian.add_penalty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Sửa phạt trễ sách:</strong>
                        </div>
                        <div class="card-body">         
                                  <form action="" id="formAddBook" runat="server" method="post" novalidate="novalidate">
                                      <div class="form-group">
                                          <label>Số tiền phạt:</label>
                                          <asp:TextBox ID="penalty" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                      </div>
                                          <asp:Button ID="buttonPen" runat="server" class="btn btn-lg btn-info btn-block" text="Sửa tiền phạt" OnClick="buttonPen_Click"/>
                                      </div>
                                      
                                  </form>
                              </div>
                          
                    </div> <!-- .card -->

                  </div><!--/.col-->

</asp:Content>
