function LoadPagination(url,page) {
    var snipers = '<div class="d-flex justify-content-center m-5 p-5"><div class="spinner-border" role ="status"><span class="sr-only">Loading...</span></div ></div >';
    var pagesize = 20;
    var urls = 'Admin/Company/GetPaged';
    var terms = $('#terms').val();
    $('#paginatedsection').empty();
    $('#paginatedsection').html(snipers);
    $.ajax({
        url: "/" + urls + "?page=" + page + "&&pagesize=" + pagesize + "&&terms=" + terms + "",
        type: 'GET',
        success: function (result) {
            $('#paginatedsection').empty();
            $('#paginatedsection').html(result);
            $('#terms').val(terms);
        }
    });
}

