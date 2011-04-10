$(document).ready(function () {

    /** 
    * Character Counter for inputs and text areas 
    */
    $('.word_count').each(function () {
        var length = 255 - $(this).val().length;
        $(this).parent().find('.counter').html(length + ' characters remaining');
        $(this).keyup(function () {
            var new_length = 255 - $(this).val().length;
            if (new_length < 0) {
                $(this).val($(this).val().toString().substring(0, 255));
                $(this).parent().find('.counter').html('0 characters remaining');
            } else {
                $(this).parent().find('.counter').html(new_length + ' characters remaining');
            }
        });
    });

}); 