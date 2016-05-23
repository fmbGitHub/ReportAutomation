<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="AutomationReport.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
                <label>Current Report:</label><asp:Label ID="lblCurrentReport" Text="Choose the Current Report" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <%--Defines the Tab--%>
            <ej:Tab ID="sfTab" runat="server" Width="100%">
                <Items>
                    <%-- First Tab of the Report --%>
                    <ej:TabItem Text="Reports" ID="tabitem1">
                        <ContentSection>
                            <%--<asp:SqlDataSource ID="sdsGabrielDB" runat="server" ConnectionString="<%$ ConnectionStrings:SqlConnGabrielDB %>" SelectCommand="SELECT ReportID, ReportName FROM GabrielDB.dbo.ReportAutomationReport " />--%>
                            <div class="row">
                                <div class="col-sm-12 label-primary">
                                    <h3 style="color:white">Pick Report</h3>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <ej:Grid ID="sfGridReports" runat='server' AllowFiltering="true" AllowPaging="true" Selectiontype="Single" AllowSelection="true"
                                        OnServerRowSelected="sfGridReports_ServerRowSelected"  EnableAltRow="true"   DataSourceCachingMode="ViewState">
                                        
                                        <PageSettings PageSize ="5"  />
                                        <FilterSettings FilterType="Excel"></FilterSettings>
                                        <Columns>
                                            <ej:Column HeaderText="Report ID" Field="ReportID"></ej:Column>
                                            <ej:Column HeaderText="Report" Field="ReportName"></ej:Column>
                                        </Columns>
                                    </ej:Grid>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-sm-12">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 label-primary">
                                    <h3 style="color:white">Report Configuration</h3>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-2 text-right">
                                    <label>Report Name</label>
                                </div>
                                <div class="col-sm-4">
                                    <ej:MaskEdit ID="sfTextboxReportName" runat="server" Width="100%" WatermarkText="Enter the Report Name"></ej:MaskEdit>
                                </div>
                                <div class="col-sm-2 text-right">
                                    <label>Active: </label>
                                </div>
                                <div class="col-sm-4 text-left">
                                    <ej:CheckBox ID="sfCheckboxActive" runat="server" Value="Active"></ej:CheckBox>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-2 text-right">
                                    <label>Final QC Person:</label>
                                </div>
                                <div class="col-sm-4">
                                    <ej:MaskEdit ID="sfTextboxGoodQCPerson" runat="server" Width="100%" WatermarkText="Enter the name of the Person"></ej:MaskEdit>
                                </div>
                                <div class="col-sm-2 text-right">
                                    <label>Email:</label>
                                </div>
                                <div class="col-sm-4 text-left">
                                    <ej:MaskEdit ID="sfGoodQCEmail" runat="server" Width="100%" WatermarkText="Enter the email"></ej:MaskEdit>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-2 text-right">
                                    <label>Bad QC Person:</label>
                                </div>
                                <div class="col-sm-4">
                                    <ej:MaskEdit ID="sfBadQCPerson" runat="server" Width="100%" WatermarkText="Enter the name of the Person"></ej:MaskEdit>
                                </div>
                                <div class="col-sm-2 text-right">
                                    <label>Email:</label>
                                </div>
                                <div class="col-sm-4 text-left">
                                    <ej:MaskEdit ID="sfBadQCEmail" runat="server" Width="100%" WatermarkText="Enter the email"></ej:MaskEdit>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-sm-12">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 label-primary">
                                    <h3 style="color:white">Schedule Reports</h3>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-2 text-right">
                                    <label>Execution Interval</label>
                                </div>
                                <div class="col-sm-10 text-left">
                                    <ej:MaskEdit ID="sfTextboxExecutionInteval" runat="server" Width="100%" WatermarkText="Enter the Report Name"></ej:MaskEdit>
                                </div>

                            </div>
                            <div class="row form-group">
                                <div class="col-sm-2 text-right">
                                    <label>Last Execution:</label>
                                </div>
                                <div class="col-sm-4">
                                    <ej:MaskEdit ID="sfTextboxLastExecution" runat="server" Width="100%" WatermarkText="Enter the name of the Person"></ej:MaskEdit>
                                </div>
                                <div class="col-sm-2 text-right">
                                    <label>Last Execution Status:</label>
                                </div>
                                <div class="col-sm-4 text-left">
                                    <ej:MaskEdit ID="sfTextboxLastExecutionStatus" runat="server" Width="100%" WatermarkText="Enter the email"></ej:MaskEdit>
                                </div>
                            </div>
                        </ContentSection>

                    </ej:TabItem>
                    <%-- Second Tab of the Report --%>
                    <ej:TabItem Text="Sheets" ID="tabitem2" >
                        <ContentSection>
                             <div class="row">
                                <div class="col-sm-12 label-primary">
                                    <h3 style="color:white">Pick Tab</h3>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <ej:Grid ID="sfGridTabs" runat='server' DataSourceID="sdsTabs" AllowFiltering="true" AllowPaging="true" AllowReordering="true" AllowResizing="true" AllowSorting="true">
                                        <PageSettings PageSize="5" />
                                        <FilterSettings FilterType="Excel"></FilterSettings>
                                        <Columns>
                                            <ej:Column HeaderText="Report ID" Field="ReportID"></ej:Column>
                                            <ej:Column HeaderText="Report Name" Field="ReportName"></ej:Column>
                                            <ej:Column HeaderText="Sheet ID" Field="TabID"></ej:Column>
                                            <ej:Column HeaderText="Sheet Name" Field="TabName"></ej:Column>
                                        </Columns>
                                    </ej:Grid>
                                    <asp:SqlDataSource runat="server" ID="sdsTabs" ConnectionString="<%$ ConnectionStrings:SqlConnGabrielDB %>" SelectCommandType="Text"  SelectCommand="SELECT ReportAutomationReport.ReportID,ReportName,TabID, TabName FROM GabrielDB.dbo.ReportAutomationTab JOIN dbo.ReportAutomationReport ON ReportAutomationReport.ReportID=dbo.ReportAutomationTab.ReportID" />
                                </div>
                            </div>
                            <%-- Defines the Tab Configuration --%>
                            <div class="row">
                                <div class="col-sm-12 label-primary">
                                    <h3 style="color:white">Tab Configuration</h3>
                                </div>
                            </div>
                           <div class="row form-group">
                                <div class="col-sm-2 text-right">
                                    <label>Server Name:</label>
                                </div>
                                <div class="col-sm-4">
                                    <ej:MaskEdit ID="sfTextboxTabName" runat="server" Width="100%" WatermarkText="Enter the server Name"></ej:MaskEdit>
                                </div>
                                <div class="col-sm-2 text-right">
                                    <label>Active: </label>
                                </div>
                                <div class="col-sm-4 text-left">
                                    <ej:CheckBox ID="sfCheckboxTabActive" runat="server" Value="Active"></ej:CheckBox>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-2 text-right">
                                    <label>Sheet Name:</label>
                                </div>
                                <div class="col-sm-4">
                                    <ej:MaskEdit ID="sfTabName" runat="server" Width="100%" WatermarkText="Enter the Sheet Name"></ej:MaskEdit>
                                </div>
                                <div class="col-sm-2 text-right">
                                    <label>Key Field: </label>
                                </div>
                                <div class="col-sm-4 text-left">
                                    <ej:MaskEdit ID="sfTextboxKeyField" runat="server" Width="100%" WatermarkText="Enter the Key Field"></ej:MaskEdit>
                                </div>
                            </div>
                             <div class="row form-group">
                                <div class="col-sm-2 text-right">
                                    <label>Position Order:</label>
                                </div>
                                <div class="col-sm-1">
                                    <ej:MaskEdit ID="sfTextboxTabPositionOrder" runat="server" Width="100%" WatermarkText="" MaskFormat="9" HidePromptOnLeave="true"></ej:MaskEdit>
                                </div>
                                 <div class="col-sm-9">

                                 </div>
                                
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-2 text-right">
                                    <label>SQL Script:</label>
                                </div>
                                <div class="col-sm-10">
                                    <ej:RTE ID="sfRichTextEditorSQLScript" runat="server" ShowToolBar="false" Width="100%" Height="200px">
                                        
                                    </ej:RTE>
                                </div>
                                 
                            </div>
                             <div class="row form-group">
                                <div class="col-sm-4 text-center">
                                    <ej:Button ID="sfButtonTabSave" runat="server" Text="Save" Width="50%"></ej:Button>
                                </div>
                                <div class="col-sm-4 text-center" >
                                    <ej:Button ID="sfButtonTabUpdate" runat="server" Text="Update" Width="50%"></ej:Button>
                                </div>
                                 <div class="col-sm-4 text-center">
                                    <ej:Button ID="sfButtonTabCancel" runat="server" Text="Cancel" Width="50%"></ej:Button>
                                </div>
                            </div>
                            <%-- Defines Rule Validation --%>
                            <ej:Tab ID="sfTabRuleValidation" runat="server">
                                <Items>
                                    <ej:TabItem ID="RulestabItem1" Text="Rules" >
                                        <ContentSection>
                                             <div class="row">
                                <div class="col-sm-12 label-primary">
                                    <h3 style="color:white">Rule Configuration</h3>
                                </div>
                            </div>
                            <div class="row form-group">
                                    <div class="col-sm-2 text-right">
                                        <label>Current Tab:</label>
                                    </div>
                                    <div class="col-sm-10  text-left">
                                        <asp:Label ID="labelCurrentTab" runat="server" Text="Current Tab"></asp:Label>
                                    </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-12">
                                    <ej:Grid ID="sfGridRules" runat='server'>
                                    <Columns>
                                        <ej:Column HeaderText="Field Name"></ej:Column>
                                        <ej:Column HeaderText="Type"></ej:Column>
                                    </Columns>
                                </ej:Grid>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-2 text-right">
                                    <label>Position Order:</label>
                                </div>
                                <div class="col-sm-1 text-left">
                                    <ej:MaskEdit ID="sfRulePositionOrder" runat="server" Width="100%" WatermarkText="" MaskFormat="9" HidePromptOnLeave="true"></ej:MaskEdit>
                                </div>
                                <div  class="col-sm-3"   ></div>
                                <div class="col-sm-2 text-right">
                                    <label>Active:</label>
                                </div>
                                <div class="col-sm-4">
                                    <ej:CheckBox ID="sfCheckBoxRuleActive" runat="server" Value="Active"></ej:CheckBox>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-6">
                                    <div class="row form-group">
                                        <div class="col-sm-4 text-right">
                                            <label>Field Name:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <ej:MaskEdit ID="sfTextBoxRuleFieldName" runat="server" Width="100%" WatermarkText="Enter the Field Name"></ej:MaskEdit>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-sm-4 text-right">
                                            <label>Type:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <ej:DropDownList ID="sfDropDownRuleType" runat="server" >
                                                <Items>
                                                    <ej:DropDownListItem Text="Required"></ej:DropDownListItem>
                                                    <ej:DropDownListItem Text="Specific Values"></ej:DropDownListItem>
                                                </Items>
                                            </ej:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row form-group">
                                        <div class="col-sm-2">
                                            <label>Rule Text:</label>
                                        </div>
                                        <div class="col-sm-10">
                                            <ej:RTE ID="RTE1" runat="server" ShowToolBar="false" Width="100%" Height="100px" ></ej:RTE>
                                        </div>
                                    </div>
                                </div>
                            </div>
                                        </ContentSection>
                                    </ej:TabItem>
                                    <%-- Defines Tab for Rules Validation --%>
                                    <ej:TabItem ID="RulesTabItem2" Text="Rules Batch">
                                        <ContentSection>
                                             <div class="row">
                                                <div class="col-sm-12 label-primary">
                                                    <h3 style="color: white">Saved Rules</h3>
                                                </div>
                                            </div>
                                            <div  class="row form-group">
                                                <div class="col-sm-10">
                                                    <ej:Grid ID="sfGridRulesBatchPreview" runat='server'>
                                                        <Columns>
                                                            <ej:Column HeaderText="Field Name"></ej:Column>
                                                            <ej:Column HeaderText="Type"></ej:Column>
                                                            <ej:Column HeaderText="Rule Text"></ej:Column>
                                                        </Columns>
                                                    </ej:Grid>
                                                </div>
                                                <div class="col-sm-2">
                                                    <div class="row form-group">
                                                        <div class="col-sm-12">
                                                            <ej:Button ID="sfButtonRulesBatchLoad" runat="server" Text="Load" Width="100%"></ej:Button>
                                                        </div>
                                                    </div>
                                                    <div class="row form-group">
                                                        <div class="col-sm-12"><ej:Button ID="sfButtonRulesBatchSave" runat="server" Text="Save" Width="100%"></ej:Button></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 label-primary">
                                                    <h3 style="color: white">Saved Rules</h3>
                                                </div>
                                            </div>
                                            <div class="row form-group">
                                                <div class="col-sm-12">
                                                    <ej:Grid ID="sfGridBatchRulesSaved" runat='server'>
                                                        <Columns>
                                                            <ej:Column HeaderText="Field Name"></ej:Column>
                                                            <ej:Column HeaderText="Type"></ej:Column>
                                                            <ej:Column HeaderText="Rule Text"></ej:Column>
                                                        </Columns>
                                                    </ej:Grid>
                                                </div>
                                            </div>
                                        </ContentSection>
                                    </ej:TabItem>
                                </Items>
                            </ej:Tab>
                            
                        </ContentSection>
                    </ej:TabItem>
                </Items>
            </ej:Tab>
        </div>
    </div>



</asp:Content>
