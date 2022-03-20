function LoadProductPagination(url, page) {
    var snipers = '<div class="d-flex justify-content-center m-5 p-5"><div class="spinner-border" role ="status"><span class="sr-only">Loading...</span></div ></div >';
    var pagesize = 20;
    var urls = 'Admin/Product/GetPaged';
    var sellerid = $('#sellerid').val();
    var tldsid = $('#tldsid').val();
    var linktypesid = $('#linktypesid').val();
    var regionsid = $('#regionsid').val();
    var term = $('#term').val();
    $('#paginatedsection').empty();
    $('#paginatedsection').html(snipers);
    $.ajax({
        url: "/" + urls + "?page=" + page + "&&pagesize=" + pagesize + " &&region=" + regionsid + "&&seller=" + sellerid + "&&linktype=" + linktypesid + " &&tld=" + tldsid + "&&term=" + term + "",
        type: 'GET',
        success: function (result) {
            $('#paginatedsection').empty();
            $('#paginatedsection').html(result);
            $('#sellerid').val(sellerid);
            $('#tldsid').val(tldsid);
            $('#linktypesid').val(linktypesid);
            $('#regionsid').val(regionsid);
            $('#term').val(term);

        }
    });
}



function LoadProductEditPagination(url, page) {
    var snipers = '<div class="d-flex justify-content-center m-5 p-5"><div class="spinner-border" role ="status"><span class="sr-only">Loading...</span></div ></div >';
    var pagesize = 20;
    var urls = 'Admin/ProductPricing/GetPaged';
    $('#paginatedsection').empty();
    $('#paginatedsection').html(snipers);
    $.ajax({
        url: "/" + urls + "?page=" + page + "&&pagesize=" + pagesize + " ",
        type: 'GET',
        success: function (result) {
            $('#paginatedsection').empty();
            $('#paginatedsection').html(result);
        }
    });
}