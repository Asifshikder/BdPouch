
function SaveProduct(id) {
    var url = 'Admin/ProductPricing/SavePrice';
    var isactive = false;
    if ($('#orderid_' + id + '').is(":checked")) {
        isactive = true;
    }
    var format = $("#formatid_" + id + "").val();
    var price = $("#priceid_" + id + "").val();
    var data = {
        id: id,
        actvie: isactive,
        format: format,
        price: price
    }
    if (format == 0) {
        alert('Select format!');
    }
    else {
        $.ajax({
            url: "/" + url + " ",
            type: 'POST',
            data: data,
            success: function (result) {
                if (result) {
                    toastr.success('Updated!');
                }
                else {
                    toastr.warning('Something went wrong!');
                }

            }
        });
    }

}