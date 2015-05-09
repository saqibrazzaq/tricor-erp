// Initializing operations
$(document).ready(function () {

    $(".ItemRowEdit").click(function () {
        ItemRow_onClick($(this));
    });

    $(".ItemRowDelete").click(function () {
        ItemRowDelete_onClick($(this));
    });
    
    $(".confirm").confirm({

        text: "Are you sure you want to delete?",
        title: "Delete",
        confirm: function (button) {
            $(".DeleteInvoice").trigger("click");
        },
        cancel: function (button) {
            // nothing to do
        },
        confirmButton: "Yes",
        cancelButton: "No",
        post: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-default"
    });
});

function ItemRow_onClick(arg) {
    initializeItemModalDialog();

    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".Col_InvoiceID").text();
    var productName = row.find(".ItemCol_InvoiceDate").text();
    var price = row.find(".ItemCol_Price").text().trim();

    $("#InvoiceLabel").text("Update Invoice (" + productName + ")");
    
    $(".txtPrice").val(price);
    $(".txtInvoiceID").val(itemID);
    $(".txtProductName").val(productName);
}

function initializeItemModalDialog() {
    $("#InvoiceLabel").text("Update");
    $(".txtPrice").val("0");
}

function ItemRowDelete_onClick(arg) {
    // Get the Invoice details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".Col_InvoiceID").text();
    $(".txtInvoiceID").val(itemID);
}

