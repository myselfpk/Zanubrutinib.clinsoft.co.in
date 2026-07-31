var param = Sys.WebForms.PageRequestManager.getInstance();
if (param != null) {
    param.add_endRequest(function (sender, e) {
        if (sender._postBackSettings.panelsToUpdate != null) {
            $('.date-only').datetimepicker({
                format: 'DD-MMM-YYYY',
            });

            //Timepicker
            $('.time-only').datetimepicker({
                format: 'HH:mm'
            });
            //-----------Add Class in Asp Radio List-----------------//
            $('table.form-check').each(function () {
                $(this).find('tr').each(function () {
                    $(this).find('input[type=radio]').addClass('form-check-input');
                    $(this).find('label').addClass('form-check-label');
                });
            });
            
        }

    });
};