$(function () {
    var clients = [];
    var inventories = [];
    var items = [];
    var index = 0;
    getInfo();

    function getInfo() {
        $.ajax({
            type: "GET",
            url: "/Store/InfoAjax",
            success: function (response) {
                clients = response.clients;
                inventories = response.inventories;
                items = response.items;

                fillSelc("#client", clients, "id", "name");
                fillSelc("#inventor", inventories, "id", "name");
                fillSelc("#item", items, "id", "name");
            }
        });
    }

    $("#item").change(function () {
        var itemId = $(this).val();
        var item = items.find(x => x.id == itemId);
        if (item == undefined) {
            return;
        }
        index++;
        let html = `  
                <tr>
                    <th>
                        <input class="form-control text-center" index=${index} id="name" value="${item.name}" disabled/>
                    </th>
                    <th>
                        <input class="form-control text-center itemId" index=${index} value="0.00" itemId="${itemId}"/>
                    </th>
                    <th>
                         <input class="form-control text-center qty" index=${index} value="0.00" qty="${itemId}"/>
                    </th>
                    <th>
                         <input class="form-control text-center price"  index=${index} value="0.00" price="${itemId}"/>
                    </th>
                </tr >
                `;

        $("#tBody").append(html);
    });

    function fillSelc(selector, dataInfo, value, name) {
        for (var i = 0; i < dataInfo.length; i++) {
            $(selector).append(' <option value="' + dataInfo[i][value] + '">' + dataInfo[i][name] + '</option>')
        }
    }

    $("#save").click(function () {
        let invoice = {};
        invoice.SaleInvoiceDetails = [];

        invoice.clientId = $("#client").val();
        invoice.inventorId = $("#inventor").val();

        for (var i = 1; i <= index; i++) {
            var invoiceDetail = {};

            invoiceDetail.ItemId = $(`.itemId[index="${index}"]`).attr('itemId');
            invoiceDetail.ItemName = items.find(x => x.id == invoiceDetail.ItemId).name;
            invoiceDetail.Qty = $(`.qty[index="${index}"]`).val();
            invoiceDetail.Price = $(`.price[index="${index}"]`).val();
            invoice.SaleInvoiceDetails.push(invoiceDetail);
        }

        sendToServer(invoice);
    });

    function sendToServer(object) {
        $.ajax({
            type: "POST",
            url: "/Store/Create",
            data: object,
            success: function (invoiceId) {
                alert("تمت الاضافة بنجاح");
                let left = ($(window).width() / 2) - (960 / 2);
                let top = ($(window).height() / 2) - (540 / 2);

                window.open(`/Print/SaleInvoice/${invoiceId}`, '_blank', `width=900, height=900, top= ${top}, left=${left}`);
                return false;
            }
        });
    }
});