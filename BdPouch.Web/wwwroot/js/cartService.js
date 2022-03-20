
function AddProductToCart(id, isfromproductlist) {
    var url = 'ShoppingCart/AddToCart';

    $.ajax({
        url: "/" + url + "?productid=" + id + "",
        type: 'GET',
        success: function (result) {
            $('#cartsummeryid').empty();
            $('#cartsummeryid').html(result);
            toastr.success('Added to your cart!');
            if (isfromproductlist) {
                $('#cartbuttondiv_' + id + '').empty();
                $('#cartbuttondiv_' + id + '').html('<button class="btn btn-success btn-sm disabled">Added to cart</button>');
            }
        }
    });
}
function AddProductToCartFromDetailsPage(id) {
    var url = 'ShoppingCart/AddToCart';

    $.ajax({
        url: "/" + url + "?productid=" + id + "",
        type: 'GET',
        success: function (result) {
            $('#cartsummeryid').empty();
            $('#cartsummeryid').html(result);
            toastr.success('Added to your cart!');

            $('#detailspageCart').empty();
            $('#detailspageCart').html('<div class="text-center"><span class= "text-danger"> Added to your cart</span ></div><button class="btn btn-block  btn-success btn-flat" style="width:100%">Proceed to checkout</button>');

        }
    });
}