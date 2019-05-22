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
        var urlGet = '/SearchBar/Search?Key=';
        var urlFind = '/SearchBar/Find?Key=';
        $.ajax({
            url: urlGet + val,
            contentType: "application/json",
            type: 'GET',
            dataType: 'json',
            success: function (result) {   
                console.log(result);
                $.each(result, function (key, value) {

                    $('#search-result-container').html("<div><a href=\"" + urlFind + value + "\">" + "Do you mean: " + value + "</a></div><hr/>");
                })
                              
                $.each(result, function (i, item) {
                    $('#search-result-container').append("<div><a href=\"" + urlFind + item + "\">" + item + "</a></div><hr/>");
                })

            }
        })
    }
   
});
