// Initializing operations
$(document).ready(function () {
    // OnClick method for show Jumbotron button
    $('.btnShowJumbotron').on("click", function () {
        return btnShowJumbotron_onClick();
    });

    // OnClick method for hide Jumbotron button
    $('.btnHideJumbotron').on("click", function () {
        return btnHideJumbotron_onClick();
    });

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
            $(".DeleteSalesOrder").trigger("click");
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

function btnShowJumbotron_onClick() {
    // Remove the hidden class
    $(".jumbotron").removeClass("hidden");
    return false; // because server control submits the form
}

function btnHideJumbotron_onClick() {
    // Hide jumbotron, by adding class hidden
    $(".jumbotron").addClass("hidden");
    return false; // because server control submits the form
}

function ItemRow_onClick(arg) {
    initializeItemModalDialog();

    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".ItemCol_ItemID").text();
    var productName = row.find(".ItemCol_ProductName").text();
    var quantity = row.find(".ItemCol_Quantity").text().trim();
    var price = row.find(".ItemCol_Price").text().trim();

    alert(price);
    
    $("#SalesOrderLabel").text("Update Item (" + productName + ")");
    $(".txtQuantity").val(quantity);
    $(".txtPrice").val(price);
    $(".txtSalesOrderItemID").val(itemID);
}

function initializeItemModalDialog() {
    $("#SalesOrderLabel").text("Update");
    $(".txtQuantity").val("0");
    $(".txtPrice").val("0");
}

function ItemRowDelete_onClick (arg){
    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".ItemCol_ItemID").text();
    
    $(".txtSalesOrderItemID").val(itemID);

    
}

