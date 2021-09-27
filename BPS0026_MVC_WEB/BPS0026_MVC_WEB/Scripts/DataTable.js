$(document).ready(function () {
    $('#OrderListTable').DataTable();

    var customersTable = $('#CustomersListTable').DataTable();

    $("#FilterCustomerName").on("change", function () {
        customersTable
            .search($(this).val())
            .draw();
    });

});