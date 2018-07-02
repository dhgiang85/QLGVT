var TuyenOption = function () {
    var self = this;
    this.initialize = function () {
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btnTuyenOption', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $('#hidVTTuyenId').val(that);
            loadDangkyTuyen();
            $('#modalDKTuyens').modal('show');
        });
       
    }
    function loadDangkyTuyen() {
        $.ajax({
            url: '/admin/donvivantai/GetDKTuyens',
            data: {
                donvivantaiId: $('#hidVTTuyenId').val()
            },
            type: 'get',
            dataType: 'json',
            success: function (response) {
                var render = '';
                var template = $('#templateTableTuyenOption').html();
                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Tuyen: item.Tuyen,
                        Khoangcach: item.Khoangcach
                });
                });
                $('#tableDKTuyenContent').html(render);
                //resetFile();
            }
        });
    }



}