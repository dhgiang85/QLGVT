var DonviVantaiController = function () {
    var cachedObj = {
        LHKinhdoanh: []
    }
    this.initialize = function () {
        $.when(
                loadLHKinhdoanh())
                .done(function() {
                    loadData();
                });

        registerEvents();
    }

    function registerEvents() {
        //Init validation
         $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                txtTenM: { required: true },
                txtDiachiM: { required: true },
                txtGPKinhdoanhM: {required: true}
            }
        });

        $("#ddlShowPage").on('change', function () {
            mcst.configs.pageSize = $(this).val();
            mcst.configs.pageIndex = 1;
            loadData(true);
        });

        $("#btnCreate").on('click', function () {
            resetFormMaintainance();
            $('#modalAddEdit').modal('show');
        });
        $('#btnSave').on('click', function (e) {
            e.preventDefault();
            saveVM();
        });

        $('body').on('click', '.btnEdit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            loadDetails(that);
        });

        $('body').on('click', '.btnDelete', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            deleteVM(that);
        });
    }
    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: 'GET',
            data: {
                categoryId: $('#ddlCategorySearch').val(),
                keyword: $('#txtKeyword').val(),
                page: mcst.configs.pageIndex,
                pageSize: mcst.configs.pageSize
            },
            url: '/admin/donvivantai/GetAllPaging',
            dataType: 'json',
            success: function (response) {
                console.log(response);
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Ten: item.Ten,
                        Diachi: item.Diachi,
                        GPKinhdoanh: item.GPKinhdoanh,
                        LHKinhdoanh: getLHKinhdoanhName(item.LHKinhdoanh),
                        Status: mcst.getStatus(item.Status)
                    });

                });
                $('#lblTotalRecords').text(response.RowCount);
                if (render != '') {
                    $('#tbl-content').html(render);
                }
                wrapPaging(response.RowCount, function () {
                    loadData();
                }, isPageChanged);
            },
            error: function (status) {
                console.log(status);
                mcst.notify('Cannot loading data', 'error');
            }
        });
    }
    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / mcst.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                mcst.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }


    function loadLHKinhdoanh() {
        return $.ajax({
            type: "GET",
            url: "/admin/donvivantai/GetLHKinhdoanh",
            dataType: "json",
            success: function (response) {
                cachedObj.LHKinhdoanh = response;
                var render = "";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.Value + "'>" + item.Name + "</option>";
                });
                $('#ddlLHKinhdoanh').html(render);
            }
        });
    }

    function getLHKinhdoanhName(status) {
        var status = $.grep(cachedObj.LHKinhdoanh, function (element, index) {
            return element.Value == status;
        });
        if (status.length > 0)
            return status[0].Name;
        else return '';
    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);

        $('#txtTenM').val('');
        $('#txtDiachiM').val('');
        $('#txtGPKinhdoanhM').val('');
        $('#ddlLHKinhdoanh').val(0);
        $('#ckStatusM').prop('checked', true);

        $('#frmMaintainance').validate().resetForm();
    }

    function saveVM() {
        if ($('#frmMaintainance').valid()) {

            var id = $('#hidIdM').val();

            var ten = $('#txtTenM').val();

            var diachi = $('#txtDiachiM').val();

            var gpkinhdoanh = $('#txtGPKinhdoanhM').val();

            var lhkinhdoanh = $('#ddlLHKinhdoanh').val();

            var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;


            $.ajax({
                type: "POST",
                url: "/Admin/donvivantai/SaveEntity",
                data: {
                    Id: id,
                    Ten: ten,
                    Diachi: diachi,
                    GPKinhdoanh: gpkinhdoanh,
                    LHKinhdoanh: lhkinhdoanh,
                    Status: status
    
                },
                dataType: "json",
                beforeSend: function () {
                    mcst.startLoading();
                },
                success: function (response) {
                    mcst.notify('Update product successful', 'success');
                    $('#modalAddEdit').modal('hide');
                    resetFormMaintainance();

                    mcst.stopLoading();
                    loadData();
                },
                error: function () {
                    mcst.notify('Has an error in save product progress', 'error');
                    mcst.stopLoading();
                }
            });
            return false;
        }
    } 

    function loadDetails(id) {
        $.ajax({
            type: "GET",
            url: "/Admin/donvivantai/GetById",
            data: { id: id },
            dataType: "json",
            beforeSend: function () {
                mcst.startLoading();
            },
            success: function (response) {
                var data = response;
                $('#frmMaintainance').validate().resetForm();
                $('#hidIdM').val(data.Id);
                $('#txtTenM').val(data.Ten);
     

                $('#txtDiachiM').val(data.Diachi);
                $('#txtGPKinhdoanhM').val(data.GPKinhdoanh);
                $('#ddlLHKinhdoanh').val(data.LHKinhdoanh);

                $('#ckStatusM').prop('checked', data.Status == 1);
            
                
                $('#modalAddEdit').modal('show');
                mcst.stopLoading();

            },
            error: function (status) {
                mcst.notify('Có lỗi xảy ra', 'error');
                mcst.stopLoading();
            }
        });
    }

    function deleteVM(id) {
        mcst.confirm('Are you sure to delete?', function () {
            $.ajax({
                type: "POST",
                url: "/Admin/donvivantai/Delete",
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    mcst.startLoading();
                },
                success: function (response) {
                    mcst.notify('Delete successful', 'success');
                    mcst.stopLoading();
                    loadData();
                },
                error: function (status) {
                    mcst.notify('Has an error in delete progress', 'error');
                    mcst.stopLoading();
                }
            });
        });
    }
}