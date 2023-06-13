function AutoComplete(Id, GetType) {
    $('#' + Id).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Auto/Index",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term, GetType: GetType },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item, value: item };
                    }))
                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    });
}


