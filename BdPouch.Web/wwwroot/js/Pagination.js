function LoadPagination(url, page) {
    var snipers = '<div class="d-flex justify-content-center m-5 p-5"><div class="spinner-border" role ="status"><span class="sr-only">Loading...</span></div ></div >';
    $('#paginatedsection').empty();
    $('#paginatedsection').html(snipers);
    $.ajax({
        url: "/" + url + "?page=" + page +  "",
        type: 'GET',
        success: function (result) {
            $('#paginatedsection').empty();
            $('#paginatedsection').html(result);
        }
    });
}