function LoadProductClientPagination (url, page) {
    var snipers = '<div class="d-flex justify-content-center m-5 p-5"><div class="spinner-border" role ="status"><span class="sr-only">Loading...</span></div ></div >';
    var pagesize = 10;
    var urls = 'Product/GetPaged';
    var categoryids = $('#categoryids').val();
    var languagesids = $('#languagesids').val();
    var linktypeid = $('#linktypeid').val();
    var regionid = $('#regionids').val();
    var tldid = $('#tldid').val();

    var drid = $('#drid').val();
    var urid = $('#urid').val();
    var spamscoreid = $('#spamscoreid').val();

    var domainauthid = $('#domainauthid').val();
    var pageauthval = $('#pageauthval').val();
    var pricerangeval = $('#pricerangeval').val();
    var terms = $('#searchtermskeys').val();
    var discountid = 0;
    var leadtimeid = 0;
    var shortbyid = 0;
    if ($("input[type='checkbox'].priceoffercheckbox").is(':checked')) {
        var disid = $("input[type='checkbox'].priceoffercheckbox:checked").val();
        discountid = disid;
    }
    if ($("input[type='radio'].leadtimecheckbox").is(':checked')) {
        var disid = $("input[type='radio'].leadtimecheckbox:checked").val();
        leadtimeid = disid;
    }
    if ($("input[type='radio'].shortbycheckbox").is(':checked')) {
        var shortedid = $("input[type='radio'].shortbycheckbox:checked").val();
        shortbyid = shortedid;
    }
    $('#paginatedsection').empty();
    $('#paginatedsection').html(snipers);
    $.ajax({
        url: "/" + urls + "?page=" + page + "&&pagesize=" + pagesize + " &&categories=" + categoryids + "&&languages=" + languagesids + "&&linktype=" + linktypeid + " &&tld=" + tldid + "&&da=" + domainauthid + "&&pa=" + pageauthval + "&&pricerange=" + pricerangeval + "&&discount=" + discountid + "&&discount=" + discountid + "&&shortby=" + shortbyid + "&&terms=" + terms + "&&leadtime=" + leadtimeid + "&&regionid=" + regionid + "&&drid=" + drid + "&&urid=" + urid + "&&spamscoreid=" + spamscoreid + "",
        type: 'GET',
        success: function (result) {
            $('#paginatedsection').empty();
            $('#paginatedsection').html(result);
        }
    });
}
function LoadProductClientPaginationFromOtherPage(url, page) {
    var snipers = '<div class="d-flex justify-content-center m-5 p-5"><div class="spinner-border" role ="status"><span class="sr-only">Loading...</span></div ></div >';
    var pagesize = 10;
    page = 1;
    var urls = 'Product/GetPaged';
    var categoryids = "";
    var languagesids = "";
    var linktypeid = 0;
    var tldid = 0;
    var domainauthid = "";
    var pageauthval ="";
    var pricerangeval = "";
    var terms = $('#searchtermskeys').val();
    var discountid = 0;
    var shortbyid = 0;

    $('#paginatedsection').empty();
    $('#paginatedsection').html(snipers);
    $.ajax({
        url: "/" + urls + "?page=" + page + "&&pagesize=" + pagesize + " &&categories=" + categoryids + "&&languages=" + languagesids + "&&linktype=" + linktypeid + " &&tld=" + tldid + "&&da=" + domainauthid + "&&pa=" + pageauthval + "&&pricerange=" + pricerangeval + "&&discount=" + discountid + "&&discount=" + discountid + "&&shortby=" + shortbyid + "&&terms=" + terms + "",
        type: 'GET',
        success: function (result) {
            $('#paginatedsection').empty();
            $('#paginatedsection').html(result);
        }
    });
}