<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Execution.aspx.cs" Inherits="AutomationReport.Execution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12 label-primary">
            <h3 style="color: white">Select a Report then a Sheet to execute</h3>
        </div>
    </div>
    <div class="row form-group">
        <div class="col-sm-5">
            <ej:Grid ID="sfReports" runat='server'>
                <Columns>
                    <ej:Column HeaderText="Report Name"> </ej:Column>
                </Columns>
            </ej:Grid>
        </div>
        <div class="col-sm-5">
            <ej:Grid ID="sfGrids" runat='server'>
                <Columns>
                    <ej:Column HeaderText="Tabs"> </ej:Column>
                </Columns>
            </ej:Grid>
        </div>
        <div class="col-sm-2">
            <div>
                <ej:Button ID="sfButtonExecute" runat="server" Text="Execute Tab" Width="100%"></ej:Button>
            </div>
        </div>
    </div>
     <div class="row">
        <div class="col-sm-12 label-primary">
            <h3 style="color: white">Data Preview</h3>
        </div>
    </div>
    <div class="row form-group">
        <div class="col-sm-10">
            <ej:Grid ID="sfGridGoodData" runat='server' ColumnLayout="Fixed">
                <Columns>
                   
                </Columns>
            </ej:Grid>
        </div>
        <div class="col-sm-2">
            <ej:Button ID="sfButtonSendGoodData" runat="server" Text="Send Good Data" Width="100%"></ej:Button>
        </div>
    </div>
    <div class="row form-group">
        <div class="col-sm-10">
            <ej:Grid ID="sfGridBadData" runat="server" auto="Fixed">
                <Columns>
                   
                </Columns>
            </ej:Grid>
        </div>
        <div class="col-sm-2">
            <ej:Button ID="sfButtonSendBadData" runat="server" Text="Bad Data" Width="100%"></ej:Button>
        </div>
    </div>
</asp:Content>
