var AppUtils = {

    MakeAjaxCall: function (url, type, data, SuccessCall, ErrorCall) {
        $.ajax({
            type: type,
            //async: false,
            url: url,
            dataType: "json",
            cache: false,
            //headers: header,
            contentType: 'application/json; charset=utf-8',
            data: data,
            success: SuccessCall,
            error: ErrorCall

        });


    },
    MakeAjaxCallJSONAntifergery: function (url, type, data, header, SuccessCall, ErrorCall) {

        $.ajax({
            type: type,
            //async: false,
            url: url,
            dataType: "json",
            cache: false,
            headers: header,
            contentType: 'application/json; charset=utf-8',
            data: data,
            success: SuccessCall,
            error: ErrorCall
        });
    },
    MakeAjaxCallJSONAntifergeryNotFormCollection: function (url, type, data, header, SuccessCall, ErrorCall) {
        $.ajax({
            type: type,
            //async: false,
            url: url,
            dataType: "json",
            cache: false,
            headers: header,
            contentType: 'application/json; charset=utf-8',
            data: data,
            success: SuccessCall,
            error: ErrorCall
        });
    },
    MakeAjaxCallJSONAntifergery: function (url, type, data, header, SuccessCall, ErrorCall) {//this start when we start pass image using jquery from client create page.

        $.ajax({
            type: type,
            //async: false,
            url: url,
            //dataType: "json",
            cache: false,
            contentType: false,
            processData: false,
            headers: header,
            //contentType: 'application/json; charset=utf-8',
            data: data,
            success: SuccessCall,
            error: ErrorCall

        });


    },
    MakeAjaxCallJSONAntifergeryJSON: function (url, type, data, header, SuccessCall, ErrorCall) {//this start when we start pass image using jquery from client create page.

        $.ajax({


            type: type,
            async: false,
            url: url,
            dataType: "json",
            cache: false,
            headers: header,
            contentType: 'application/json; charset=utf-8',
            data: data,
            success: SuccessCall,
            error: ErrorCall

        });


    },
    MakeAjaxCallsForAntiForgery: function (url, type, data, SuccessCall, ErrorCall) {

        $.ajax({
            async: false,
            type: type,
            //headers:headers,
            url: url,
            dataType: "json",
            //contentType: "'application/x-www-form-urlencoded; charset=utf-8'",
            cache: false,
            data: data,
            success: SuccessCall,
            error: ErrorCall

        });
    },

    GetIdValue: function (id) {
        if (($("#" + id)).value == "") {
            return "";
        }
        else
            return $("#" + id).val();
    },
}