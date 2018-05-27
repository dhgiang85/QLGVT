var DangkyTuyen = function() {
    var self = this;
    var cachedObj = {
        Tuyens: []
    }
    this.initialize = function () {
        loadTuyens();
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btnDSDangky', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $('#hidId').val(that);
            loadDangkyTuyen();
            $('#modalDangkyTuyen').modal('show');
        });
        $('body').on('click', '.btnDeleteQuantity', function (e) {
            e.preventDefault();
            $(this).closest('tr').remove();
        });

        $('#btnAddTuyen').on('click', function () {
            var template = $('#templateTableTuyen').html();
            var render = Mustache.render(template, {
                Id: 0,
                Tuyens: getTuyenOptions(null),
                Status: getStatus(1)
        });
            $('#tableTuyenContent').append(render);
        });
        $("#btnSaveQuantity").on('click', function () {
            var TuyenList = [];
            $.each($('#tableTuyenContent').find('tr'), function (i, item) {
                TuyenList.push({
                    Id: $(item).data('id'),
                    DonvivantaiId: $('#hidId').val(),
                    TuyenId: $(item).find('select.ddlTuyenId').first().val(),
                    Status: $(item).find('input.ckStatusM').prop('checked') == true ? 1 : 0
                   });
            });
            console.log(TuyenList);
            $.ajax({
                url: '/admin/donvivantai/SaveTuyens',
                data: {
                    donvivantaiId: $('#hidId').val(),
                    tuyens: TuyenList
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    $('#modalDangkyTuyen').modal('hide');
                    $('#tableTuyenContent').html('');
                }
            });
        });
    }
    function loadDangkyTuyen() {
        $.ajax({
            url: '/admin/donvivantai/GetTuyens',
            data: {
                donvivantaiId: $('#hidId').val()
            },
            type: 'get',
            dataType: 'json',
            success: function (response) {
                
                var render = '';
                var template = $('#templateTableTuyen').html();
                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Tuyens: getTuyenOptions(item.TuyenId),
                        Status: getStatus(item.Status)
                    });
                });
                $('#tableTuyenContent').html(render);
                //resetFile();
            }
        });
    }
    function loadTuyens() {
        return $.ajax({
            type: "GET",
            url: "/Admin/tuyen/GetTuyens",
            dataType: "json",
            success: function (response) {
               cachedObj.Tuyens = response;
            },
            error: function () {
                mcst.notify('Có lỗi xảy ra', 'error');
            }
        });
    }


    function getTuyenOptions(selectedId) {
        var tuyens = "<select class='form-control ddlTuyenId'>";
        $.each(cachedObj.Tuyens, function (i, tuyen) {
            if (selectedId === parseInt(tuyen.Value))
                tuyens += '<option value="' + tuyen.Value + '" selected="select">' + tuyen.Text + '</option>';
            else
                tuyens += '<option value="' + tuyen.Value + '">' + tuyen.Text + '</option>';
        });
        tuyens += "</select>";
        return tuyens;
    }
    function getStatus(status) {
        if (status === 1)
            return "<div class='checkbox'><label><input type='checkbox' class='ckStatusM' checked='checked'></label></div>";
        else
            return "<div class='checkbox'><label><input type='checkbox' class='ckStatusM'></label></div>";
    }

}