$(document).ready(function () {
    $(document).ready(function () {
        $('#search-data').unbind().keyup(function (e) {
            var value = $(this).val();
            if (value.length > 0) {              
                searchData(value);
            }
            else {
                $('#search-result-container').hide();
            }
        }
        );
    }
    );
    function searchData(val) {
        $('#search-result-container').show();   
        
        $.ajax({
            url: '/SearchBar/searchresult?prefixtext=' + val,
            contentType: "application/json",
            type: 'GET',
            dataType: 'json',
            success: function (result) {              
                //$('#search-result-container').html("<div>" + result + "</div><hr/>");
                $.each(result, function (i, item) { $('#search-result-container').append("<div><a asp-controller=\"Search\" asp-action=\"Display\" asp-rout-id=\"THE_ID\">" + result[i] + "</a></div><hr/>"); })
               
            }
        })
    }
});
