
$(function () {
    var current = location.pathname;
    $('li.has-treeview').removeClass('menu-open');
    $('li.has-treeview').removeClass('active');
    $('a.nav-link').first().removeClass('active');
    $('#side-nav-menu ul li a').each(function () {
        var $this = $(this);
        // if the current path is like this link, make it active
        //$this.attr('href').indexOf(current) !== -1
        if ($this.attr('href').toLowerCase() === current.toLowerCase()) {
            //debugger;
            $this.addClass('active');
            var parent1 = $this.closest('ul.nav-treeview').length;
            var parent = $this.closest('ul.nav-treeview').closest('li.has-treeview').length;
            if (parent1 > 0 && parent > 0) {
                $this.closest('ul.nav-treeview').closest('li.has-treeview').addClass('menu-open');
                $this.closest('ul.nav-treeview').closest('li.has-treeview').removeClass('active');
                $this.closest('ul.nav-treeview').closest('li.has-treeview').find('a.nav-link').first().addClass('active');
            }
        }
        //else {
        //    $this.removeClass('active');
            
        //}
    });

    //$('#side-nav-menu ul li').each(function () {

    //    var aCount = $(this).find('a.nav-link').length;
    //    var url = $(this).find('a.nav-link').first().attr('href');
    //    var href = window.location.href;
    //    var pathname = window.location.pathname;
    //    var currentUrl = window.location.hostname;
    //    if (pathname.toUpperCase() == url.toUpperCase()) {
    //        debugger;
    //        $(this).find('a.nav-link').addClass('active');
    //        var treeCount = $(this).find('a.nav-link').parent('li').parent('li.has-treeiew').length;
    //        var treeCount_A = $(this).find('a.nav-link').parent('li.has-treeiew').find('a.nav-link').first().length;
    //        $(this).find('a.nav-link').parent('li.has-treeiew').find('a.nav-link').first().addClass('active');
    //    }
    //    else {
    //        $(this).find('a.nav-link').removeClass('active');
    //    }
    //});
    $('table.form-check').each(function () {
        $(this).find('tr').each(function () {
            $(this).find('input[type=radio]').addClass('form-check-input');
            $(this).find('label').addClass('form-check-label');
        });
    });

   //date picker
    $('.date-only').datetimepicker({
        format: 'DD-MMM-YYYY',
    });
   
    //Timepicker
    $('.time-only').datetimepicker({
        format: 'HH:mm'
    });

    
});
function alertToastr(type, msg) {
    debugger;
    if (type === 'danger') {
        toastr.error(msg);
    }
    else if (type === 'success') {
        toastr.success(msg);
    }
    else if (type === 'warning') {
        toastr.warning(msg);
    }
    else if (type === 'info') {
        toastr.info(msg);
    }
}