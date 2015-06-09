<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gridBasic.aspx.cs" Inherits="gridBasic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="./styles/examples-offline.css" rel="stylesheet">
    <link href="./styles/kendo.common.min.css" rel="stylesheet">
    <link href="./styles/kendo.rtl.min.css" rel="stylesheet">
    <link href="./styles/kendo.default.min.css" rel="stylesheet">
    <link href="./styles/kendo.dataviz.min.css" rel="stylesheet">
    <link href="./styles/kendo.dataviz.default.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div id="grid">
        </div>
    </form>

    <script src="./js/jquery.min.js"></script>
    <script src="./js/kendo.all.min.js"></script>
    <script src="./js/console.js"></script>
    <script>
        $(document).ready(function () {

            var myPageMethods = PageMethods;
            var jsonRequest = "";

            myPageMethods.ToddGrdNeedDataSource(succeededCallback);


            $("#grid").kendoGrid({
                dataSource: {
                    //type: "json",
                    transport: {
                        //read: "http://demos.telerik.com/kendo-ui/service/Northwind.svc/Customers"
                        read: {
                            url: "gridBasic.aspx/ToddGrdNeedDataSource", //specify the URL which data should return the records. This is the Read method of the Products.asmx service.
                            contentType: "application/json; charset=utf-8", // tells the web method to serialize JSON
                            type: "POST" //use HTTP POST request as the default GET is not allowed for web methods
                        },
                        parameterMap: function (data, operation) {
                            if (operation == "read") {
                                //Page methods always need values for their parameters
                                data = $.extend({ sort: null, filter: null }, data);
                                return JSON.stringify(data);
                            }
                        }
                    },
                    schema: {
                        //model: {
                        //    data: "d",
                        //    id: "d.SysID",
                        //    fields: {
                        //        SysID: { type: "number", editable: false },
                        //        MatterNumber: { type: "string" },
                        //        MatterDescription: { type: "string" },
                        //        Notes: { type: "string" },
                        //        DueDate: { type: "string" }
                        //    }
                        //}
                        parse: function (response) {
                            var matters = [];
                            for (var i = 0; i < response.d.length; i++) {
                                var matter = {
                                    id: response.d[i].SysID,
                                    SysID: response.d[i].SysID,
                                    MatterNumber: response.d[i].MatterNumber,
                                    MatterDescription: response.d[i].MatterDescription,
                                    Notes: response.d[i].Notes,
                                    DueDate: response.d[i].DueDate

                                };
                                matters.push(matter);
                            }
                            return matters;
                        }
                    },
                    pageSize: 20
                },
                height: 550,
                groupable: true,
                sortable: true,
                pageable: {
                    refresh: true,
                    pageSizes: true,
                    buttonCount: 5
                },
                columns: [{
                    field: "SysID",
                    title: "SysID",
                    width: 200
                }, {
                    field: "DueDate",
                    title: "Due Date",
                    width: 150
                }, {
                    field: "MatterNumber",
                    title: "Matter Number"
                }, {
                    field: "MatterDescription",
                    title: "Description"
                }, {
                    field: "Notes",
                    title: "Notes",
                }]
            });



        });

        function succeededCallback(response) {
            console.log(response);
        }
    </script>
</body>
</html>
