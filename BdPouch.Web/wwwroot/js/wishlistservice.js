
function AddProductToWishList(id, isfromproductlist) {
    var url = 'WishList/AddToWishList';

    $.ajax({
        url: "/" + url + "?productid=" + id + "",
        type: 'GET',
        success: function (result) {
            $('#WishListsummeryid').empty();
            $('#WishListsummeryid').html(result);
            toastr.success('Added to your WishList!');
            if (isfromproductlist) {
                $('#WishListbuttondiv_' + id + '').empty();
                $('#WishListbuttondiv_' + id + '').html('<button class="btn btn-success btn-sm disabled">Added to WishList</button>');
            }
        }
    });
}
function AddProductToWishListFromDetailsPage(id) {
    var url = 'WishList/AddToWishList';

    $.ajax({
        url: "/" + url + "?productid=" + id + "",
        type: 'GET',
        success: function (result) {
            $('#WishListsummeryid').empty();
            $('#WishListsummeryid').html(result);
            toastr.success('Added to your WishList!');

            $('#detailspageWishList').empty();
            $('#detailspageWishList').html('<div class="text-center"><span class= "text-danger"> Added to your WishList</span ></div><button class="btn btn-block  btn-success btn-flat" style="width:100%">Proceed to checkout</button>');

        }
    });
}