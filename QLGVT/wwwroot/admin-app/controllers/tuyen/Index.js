var TuyenController = function () {
    var cachedObj = {
        DSBenxe: []
    }
    this.initialize = function () {
        $.when(
                loadDSBenxe())
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
            lang: 'en',
            rules: {
                txtKhoangcachM: {
                    required: true,
                    number : true
                }
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
            url: '/admin/tuyen/GetAllPaging',
            dataType: 'json',
            success: function (response) {
                console.log(response);
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Xuatphat: getBenxe(item.XuatphatId),
                        Diemden: getBenxe(item.DiemdenId),
                        Khoangcach: item.Khoangcach,
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


    function loadDSBenxe() {
        return $.ajax({
            type: "GET",
            url: "/admin/tuyen/GetDSBenxe",
            dataType: "json",
            success: function (response) {
                cachedObj.DSBenxe = response;
                console.log(response);
                var render = "";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.Value + "'>" + item.Text + "</option>";
                });
                $('#ddlXuatphat').html(render);
                $('#ddlDiemden').html(render);
            }
        });

     
    }

    function getBenxe(status) {
        var status = $.grep(cachedObj.DSBenxe, function (element, index) {
            return element.Value == status;
        });
        if (status.length > 0)
            return status[0].Text;
        else return '';
    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);

        $('#txtKhoangcachM').val('');

        $('#ckStatusM').prop('checked', true);

        $('#frmMaintainance').validate().resetForm();
    }

    function saveVM() {
        if ($('#frmMaintainance').valid()) {

            var id = $('#hidIdM').val();

            var xuatphatId = $('#ddlXuatphat').val();

            var diemdenId = $('#ddlDiemden').val();

            var khoangcach = $('#txtKhoangcachM').val();

            var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;


            $.ajax({
                type: "POST",
                url: "/Admin/tuyen/SaveEntity",
                data: {
                    Id: id,
                    XuatphatId: xuatphatId,
                    DiemdenId: diemdenId,
                    Khoangcach: khoangcach,
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