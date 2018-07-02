var KekhaiController = function () {
    var cachedObj = {
        dongiaStatus: []
    }
    this.initialize = function () {
        $.when(loadDongiaStatus()
        ).done(function () {
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
                //txtTenM: { required: true },
                //txtDiachiM: { required: true },
                //txtGPKinhdoanhM: { required: true }
            }
        });

        $("#ddlShowPage").on('change', function () {
            mcst.configs.pageSize = $(this).val();
            mcst.configs.pageIndex = 1;
            loadData(true);
        });

        //$("#btnCreate").on('click', function () {
        //    resetFormMaintainance();
        //    $('#modalAddEdit').modal('show');
        //});
        //$('#btnSave').on('click', function (e) {
        //    e.preventDefault();
        //    saveVM();
        //});

        //$('body').on('click', '.btnEdit', function (e) {
        //    e.preventDefault();
        //    var that = $(this).data('id');
        //    loadDetails(that);
        //});

        $('body').on('click', '.btnEditDongia', function (e) {
            e.preventDefault();
            resetFormMaintainance();
            var _id = $(this).data('id');
            var _baseid = $(this).data('baseid');
            var _dktuyenid = $(this).data('dktuyenid');
            
            $('#hidDonGiaId').val(_id);
            $('#hidDonGiaBaseId').val(_baseid);
            $('#hidDKTuyenId').val(_dktuyenid);
            loadDetails(_id, _baseid);
            //var kc = $(this).data('kc');
            //$('#hKhoangCach').val(kc);
            //LoadGiaSosanh();

        });

        $('#txtDateAppliedVM').datepicker({
            autoclose: true,
            //defaultDate: new Date(),
            format: 'dd/mm/yyyy'

        });
        $('#modalEditDongia').on('click', '#btnSave', function (e) {
            e.preventDefault();
            saveVM();
        });

        RateCalculartor();
        $('#modalEditDongia').on('change paste keyup', 'input[type="number"]', function () {
            var sum1 = 0;
            sum1 = parseFloat($('#txtCPNLVM').val()) + parseFloat($('#txtCPNCTTVM').val()) + parseFloat($('#txtCPKHTBVM').val()) + parseFloat($('#txtCPSXKDDTVM').val());

            $('#txtTotalCPTT').val(sum1);

            var sum2 = parseFloat($('#txtCPSXCVM').val()) + parseFloat($('#txtCPTCVM').val()) + parseFloat($('#txtCPBHVM').val()) + parseFloat($('#txtCPQLVM').val());
            $('#txtTotalCPC').val(sum2);

            $('#txtTotal').val(sum1 + sum2);
            $('#txtTotalKD').val(sum1 + sum2);

            var sum3 = parseFloat($('#txtGTVVM').val()) + parseFloat($('#txtLoinhuanDukienVM').val());
            $('#txtGVCTVM').val(sum3);
            $('#txtVATVM').val((sum3 * 0.1).toFixed(2));
            var sum4 = parseFloat($('#txtGVCTVM').val()) + parseFloat($('#txtVATVM').val());
            $('#txtGVDKVM').val(sum4);

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
            url: '/admin/kekhaigia/GetAllPaging',
            dataType: 'json',
            success: function (response) {
                console.log(response);
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        BaseId: item.KekhaiGiaBaseId, 
                        DKTuyenId: item.DangkyTuyenId,
                        Ten: item.DangkyTuyen.DonviVantai.Ten,
                        Tuyen: item.DangkyTuyen.Tuyen.Xuatphat.Ten + " - " + item.DangkyTuyen.Tuyen.Diemden.Ten,
                        DateApplied: mcst.dateFormatJson(item.DateApplied),
                        SLTG: item.SLTG,
                        TotalCPTT: item.TotalCPTT,
                        TotalCPC: item.TotalCPC,
                        Total: item.Total,
                        PriceUnit: item.GiaVeDukien,
                        KekhaiGiaStatus: getDongiaStatus(item.KekhaiGiaStatus)
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

    function loadDongiaStatus() {
        return $.ajax({
            type: "GET",
            url: "/admin/kekhaigia/GetDongiaStatus",
            dataType: "json",
            success: function (response) {
                cachedObj.dongiaStatus = response;
                var render = "";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.Value + "'>" + item.Name + "</option>";
                });
                $('#ddlDongiaStatus').html(render);
            }
        });
    }


    function getDongiaStatus(status) {
        var status = $.grep(cachedObj.dongiaStatus, function (element, index) {
            return element.Value == status;
        });
        if (status.length > 0)
            return status[0].Name;
        else return '';
    }

    function resetFormMaintainance() {
        $('#hidDKTuyenId').val('');
        $('#hidDonGiaId').val('');

        $('#hKhoangCach').val('');
        //-----------------------------------
        $('#txtDateAppliedVM').val('');
        $('#txtTotal').val('');
        $('#txtTotalCPTT').val('');
        $('#txtTotalCPC').val('');
        $('#txtTotalKD').val('');
        $('#txtGTVVM').val('');
        $('#txtGVCTVM').val('');
        $('#txtVATVM').val('');
        $('#txtGVDKVM').val('');
        $('#txtNoteVM').val('');

        $('#txtCPNLVM').val('');
        $('#txtCPNCTTVM').val('');
        $('#txtCPKHTBVM').val('');
        $('#txtCPSXKDDTVM').val('');

        $('#txtCPSXCVM').val('');
        $('#txtCPTCVM').val('');
        $('#txtCPBHVM').val('');
        $('#txtCPQLVM').val('');

        $('#txtLoiNhuanDukienVM').val('');
        //-----------------------------------
        $('#txtSLTGRateVM').val('');

        $('#txtCPNLRateVM').val('');
        $('#txtCPNCTTRateVM').val('');
        $('#txtCPKHTBRateVM').val('');
        $('#txtCPSXKDDTRateVM').val('');

        $('#txtCPSXCRateVM').val('');
        $('#txtCPTCRateVM').val('');
        $('#txtCPBHRateVM').val('');
        $('#txtCPQLRateVM').val('');
        //-----------------------------------

        $('#txtDateAppliedBVM').val('');
        $('#txtTotalB').val('');
        $('#txtTotalCPTTB').val('');
        $('#txtTotalCPCB').val('');
        $('#txtTotalKDB').val('');
        $('#txtGTVBVM').val('');
        $('#txtGVCTBVM').val('');
        $('#txtVATBVM').val('');
        $('#txtGVDKBVM').val('');

        $('#txtNoteBVM').val('');
        $('#txtSLTGBVM').val('');

        $('#txtCPNLBVM').val('');
        $('#txtCPNCTTBVM').val('');
        $('#txtCPKHTBBVM').val('');
        $('#txtCPSXKDDTBVM').val('');

        $('#txtCPSXCBVM').val('');
        $('#txtCPTCBVM').val('');
        $('#txtCPBHBVM').val('');
        $('#txtCPQLBVM').val('');

        $('#txtLoiNhuanDukienBVM').val('');
        //-----------------------------------
        $('#txtSLTGRateBVM').val('');

        $('#txtCPNLRateBVM').val('');
        $('#txtCPNCTTRateBVM').val('');
        $('#txtCPKHTBRateBVM').val('');
        $('#txtCPSXKDDTRateBVM').val('');

        $('#txtCPSXCRateBVM').val('');
        $('#txtCPTCRateBVM').val('');
        $('#txtCPBHRateBVM').val('');
        $('#txtCPQLRateBVM').val('');
        //$('#txtLoiNhuanDukienRateVM').val();
    }
    function RateCalculartor() {

        $('#txtCPTCVM').bind('change paste keyup', function () {
            var CP = 'CPTC';
            var a = ((parseFloat($('#txt' + CP + 'VM').val()) - parseFloat($('#txt' + CP + 'BVM').val())) / parseFloat($('#txt' + CP + 'BVM').val()) * 100).toFixed(2);
            $('#txt' + CP + 'RateVM').val(a);
            $('#txt' + CP + 'RateVM').toggleClass('bg-red', a > mcst.configs.Rate);

        });

        $('#txtSLTGVM').bind('change paste keyup', function () {
            var CP = 'SLTG';
            var a = ((parseFloat($('#txt' + CP + 'VM').val()) - parseFloat($('#txt' + CP + 'BVM').val())) / parseFloat($('#txt' + CP + 'BVM').val()) * 100).toFixed(2);
            $('#txt' + CP + 'RateVM').val(a);
            $('#txt' + CP + 'RateVM').toggleClass('bg-red', a > mcst.configs.Rate);
        });


        $('#txtCPNLVM').bind('change paste keyup', function () {
            var CP = 'CPNL';
            var a = ((parseFloat($('#txt' + CP + 'VM').val()) - parseFloat($('#txt' + CP + 'BVM').val())) / parseFloat($('#txt' + CP + 'BVM').val()) * 100).toFixed(2);
            $('#txt' + CP + 'RateVM').val(a);
            $('#txt' + CP + 'RateVM').toggleClass('bg-red', a > mcst.configs.Rate);

        });

        $('#txtCPNCTTVM').bind('change paste keyup', function () {
            var CP = 'CPNCTT';
            var a = ((parseFloat($('#txt' + CP + 'VM').val()) - parseFloat($('#txt' + CP + 'BVM').val())) / parseFloat($('#txt' + CP + 'BVM').val()) * 100).toFixed(2);
            $('#txt' + CP + 'RateVM').val(a);
            $('#txt' + CP + 'RateVM').toggleClass('bg-red', a > mcst.configs.Rate);
        });

        $('#txtCPKHTBVM').bind('change paste keyup', function () {
            var CP = 'CPKHTB';
            var a = ((parseFloat($('#txt' + CP + 'VM').val()) - parseFloat($('#txt' + CP + 'BVM').val())) / parseFloat($('#txt' + CP + 'BVM').val()) * 100).toFixed(2);
            $('#txt' + CP + 'RateVM').val(a);
            $('#txt' + CP + 'RateVM').toggleClass('bg-red', a > mcst.configs.Rate);
        });

        $('#txtCPSXKDDTVM').bind('change paste keyup', function () {
            var CP = 'CPSXKDDT';
            var a = ((parseFloat($('#txt' + CP + 'VM').val()) - parseFloat($('#txt' + CP + 'BVM').val())) / parseFloat($('#txt' + CP + 'BVM').val()) * 100).toFixed(2);
            $('#txt' + CP + 'RateVM').val(a);
            $('#txt' + CP + 'RateVM').toggleClass('bg-red', a > mcst.configs.Rate);
        });

        $('#txtCPSXCVM').bind('change paste keyup', function () {
            var CP = 'CPSXC';
            var a = ((parseFloat($('#txt' + CP + 'VM').val()) - parseFloat($('#txt' + CP + 'BVM').val())) / parseFloat($('#txt' + CP + 'BVM').val()) * 100).toFixed(2);
            $('#txt' + CP + 'RateVM').val(a);
            $('#txt' + CP + 'RateVM').toggleClass('bg-red', a > mcst.configs.Rate);
        });

        $('#txtCPBHVM').bind('change paste keyup', function () {
            var CP = 'CPBH';
            var a = ((parseFloat($('#txt' + CP + 'VM').val()) - parseFloat($('#txt' + CP + 'BVM').val())) / parseFloat($('#txt' + CP + 'BVM').val()) * 100).toFixed(2);
            $('#txt' + CP + 'RateVM').val(a);
            $('#txt' + CP + 'RateVM').toggleClass('bg-red', a > mcst.configs.Rate);
        });

        $('#txtCPQLVM').bind('change paste keyup', function () {
            var CP = 'CPQL';
            var a = ((parseFloat($('#txt' + CP + 'VM').val()) - parseFloat($('#txt' + CP + 'BVM').val())) / parseFloat($('#txt' + CP + 'BVM').val()) * 100).toFixed(2);
            $('#txt' + CP + 'RateVM').val(a);

            $('#txt' + CP + 'RateVM').toggleClass('bg-red', a > mcst.configs.Rate);
        });
    }
    function LoadGiaSosanh() {
        return $.ajax({
            type: "GET",
            url: "/admin/donvivantai/GetGiaBase",
            data: {
                KeKhaiGiabaseId: $('#hidDKTuyenId').val()
            },
            dataType: "json",
            success: function (response) {
                console.log(response)
                $('#txtSLTGVM').val(response.SLTG);

                $('#txtCPNLVM').val(response.CPNL);
                $('#txtCPNCTTVM').val(response.CPNCTT);
                $('#txtCPKHTBVM').val(response.CPKHTB);
                $('#txtCPSXKDDTVM').val(response.CPSXKDDT);

                $('#txtCPSXCVM').val(response.CPSXC);
                $('#txtCPTCVM').val(response.CPTC);
                $('#txtCPBHVM').val(response.CPBH);
                $('#txtCPQLVM').val(response.CPQL);
                $('#txtDateAppliedVM').val(mcst.dateFormatJson(response.DateApplied));

                $('#txtLoinhuanDukienVM').val(response.LoinhuanDukien);

                $('#txtGTVVM').val(response.GiathanhVe);

                $('#txtGVCTVM').val(response.PriceNotVAT);
                $('#txtVATVM').val(response.VAT);
                $('#txtGVDKVM').val(response.GiaVeDukien);

                //-----------------------
                $('#txtTotal').val(response.Total);
                $('#txtTotalCPTT').val(response.TotalCPTT);
                $('#txtTotalCPC').val(response.TotalCPC);

                $('#txtTotalKD').val(response.Total);

            }
        });
    }
    function saveVM() {
        if ($('#frmDongiaMaintainance').valid()) {

            var id = $('#hidDonGiaId').val();
            var dangkytuyenid = $('#hidDKTuyenId').val();
            var kekhaigiabaseid = $('#hidDonGiaBaseId').val();
            var sltg = $('#txtSLTGVM').val();

            var cpnl = $('#txtCPNLVM').val();
            var cpnctt = $('#txtCPNCTTVM').val();
            var cpkhtb = $('#txtCPKHTBVM').val();
            var cpsxkddt = $('#txtCPSXKDDTVM').val();

            var cpsxc = $('#txtCPSXCVM').val();
            var cptc = $('#txtCPTCVM').val();
            var cpbh = $('#txtCPBHVM').val();
            var cpql = $('#txtCPQLVM').val();

            var loinhuandukien = $('#txtLoinhuanDukienVM').val();
            //-----------------------------------
            var sltgrate = 0;

            var cpnlrate = $('#txtCPNLRateVM').val();
            var cpncttrate = $('#txtCPNCTTRateVM').val();
            var cpkhtbrate = $('#txtCPKHTBRateVM').val();
            var cpsxkddtrate = $('#txtCPSXKDDTRateVM').val();

            var cpsxcrate = $('#txtCPSXCRateVM').val();
            var cptcrate = $('#txtCPTCRateVM').val();
            var cpbhrate = $('#txtCPBHRateVM').val();
            var cpqlrate = $('#txtCPQLRateVM').val();
            var kekhaigiastatus = $('#ddlDongiaStatus').val();
            var loinhuandukienrate = 0;//$('#txtLoinhuanDukienRateVM').val();

            var giathanhve = $('#txtGVCTVM').val();

            var note = $('#txtNoteVM').val();

            var dateapplied = $('#txtDateAppliedVM').val();

            $.ajax({
                type: "POST",
                url: "/Admin/kekhaigia/SaveDongia",
                data: {
                    Id: id,
                    SLTG: sltg,

                    CPNL: cpnl,
                    CPNCTT: cpnctt,
                    CPKHTB: cpkhtb,
                    CPSXKDDT: cpsxkddt,

                    CPSXC: cpsxc,
                    CPTC: cptc,
                    CPBH: cpbh,
                    CPQL: cpql,
                    LoinhuanDukien: loinhuandukien,
                    GiathanhVe: giathanhve,
                    Note: note,
                    SLTGRate: sltgrate,

                    CPNLRate: cpnlrate,
                    CPNCTTRate: cpncttrate,
                    CPKHTBRate: cpkhtbrate,
                    CPSXKDDTRate: cpsxkddtrate,

                    CPSXCRate: cpsxcrate,
                    CPTCRate: cptcrate,
                    CPBHRate: cpbhrate,
                    CPQLRate: cpqlrate,

                    DangkyTuyenId: dangkytuyenid,
                    KekhaiGiaBaseId: kekhaigiabaseid,
                    KekhaiGiaStatus: kekhaigiastatus,
                    DateApplied: dateapplied

                },
                dataType: "json",
                beforeSend: function () {
                    mcst.startLoading();
                },
                success: function (response) {
                    mcst.notify('Update product successful', 'success');
                    $('#modalEditDongia').modal('hide');
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

    function loadDetails(id, baseid) {
        $.when(
            $.ajax({
                type: "GET",
                url: "/Admin/kekhaigia/GetById",
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    mcst.startLoading();
                }
            }),

            $.ajax({
                type: "GET",
                url: "/Admin/kekhaigia/GetById",
                data: { id: baseid },
                dataType: "json",

            }),
           
        ).done(function (data1, data2) {
            
            
 
            if (data2[1] === "success") {

                $('#txtSLTGBVM').val(data2[0].SLTG);

                $('#txtCPNLBVM').val(data2[0].CPNL);
                $('#txtCPNCTTBVM').val(data2[0].CPNCTT);
                $('#txtCPKHTBBVM').val(data2[0].CPKHTB);
                $('#txtCPSXKDDTBVM').val(data2[0].CPSXKDDT);

                $('#txtCPSXCBVM').val(data2[0].CPSXC);
                $('#txtCPTCBVM').val(data2[0].CPTC);
                $('#txtCPBHBVM').val(data2[0].CPBH);
                $('#txtCPQLBVM').val(data2[0].CPQL);
                $('#txtDateAppliedBVM').val(mcst.dateFormatJson(data2[0].DateApplied));

                $('#txtLoinhuanDukienBVM').val(data2[0].LoinhuanDukien);

                $('#txtGTVBVM').val(data2[0].GiathanhVe);

                $('#txtGVCTBVM').val(data2[0].PriceNotVAT);
                $('#txtVATBVM').val(data2[0].VAT);
                $('#txtGVDKBVM').val(data2[0].GiaVeDukien);

                //-----------------------
                $('#txtTotalB').val(data2[0].Total);
                $('#txtTotalCPTTB').val(data2[0].TotalCPTT);
                $('#txtTotalCPCB').val(data2[0].TotalCPC);

                $('#txtTotalKDB').val(data2[0].Total);


            }
            //-----------------------
            if (data1[1] === "success") {
                $('#txtSLTGVM').val(data1[0].SLTG);

                $('#txtCPNLVM').val(data1[0].CPNL);
                $('#txtCPNCTTVM').val(data1[0].CPNCTT);
                $('#txtCPKHTBVM').val(data1[0].CPKHTB);
                $('#txtCPSXKDDTVM').val(data1[0].CPSXKDDT);

                $('#txtCPSXCVM').val(data1[0].CPSXC);
                $('#txtCPTCVM').val(data1[0].CPTC);
                $('#txtCPBHVM').val(data1[0].CPBH);
                $('#txtCPQLVM').val(data1[0].CPQL);
                $('#txtDateAppliedVM').val(mcst.dateFormatJson(data1[0].DateApplied));

                $('#txtLoinhuanDukienVM').val(data1[0].LoinhuanDukien);

                $('#txtGTVVM').val(data1[0].GiathanhVe);

                $('#txtGVCTVM').val(data1[0].PriceNotVAT);
                $('#txtVATVM').val(data1[0].VAT);
                $('#txtGVDKVM').val(data1[0].GiaVeDukien);

                //-----------------------
                $('#txtTotal').val(data1[0].Total);
                $('#txtTotalCPTT').val(data1[0].TotalCPTT);
                $('#txtTotalCPC').val(data1[0].TotalCPC);

                $('#txtTotalKD').val(data1[0].Total);


                $('#txtSLTGRateVM').val(parseFloat(data1[0].Total));

                $('#txtCPNLRateVM').val(parseFloat(data1[0].CPNLRate).toFixed(2));
                $('#txtCPNCTTRateVM').val(parseFloat(data1[0].CPNCTTRate).toFixed(2));
                $('#txtCPKHTBRateVM').val(parseFloat(data1[0].CPKHTBRate).toFixed(2));
                $('#txtCPSXKDDTRateVM').val(parseFloat(data1[0].CPSXKDDTRate).toFixed(2));

                $('#txtCPSXCRateVM').val(parseFloat(data1[0].CPSXCRate).toFixed(2));
                $('#txtCPTCRateVM').val(parseFloat(data1[0].CPTCRate).toFixed(2));
                $('#txtCPBHRateVM').val(parseFloat(data1[0].CPBHRate).toFixed(2));
                $('#txtCPQLRateVM').val(parseFloat(data1[0].CPQLRate).toFixed(2));
                $('#txtNoteVM').val(data1[0].Note);
                $('#ddlDongiaStatus').val(data1[0].KekhaiGiaStatus);

                $('#txtLoinhuanDukienRateVM').val();
                $('#modalEditDongia').modal('show');
                mcst.stopLoading();
            }
            else {
                mcst.notify('Has an error in save product progress', 'error');
                mcst.stopLoading();
            }
            
        });

        
    }

    function deleteVM(id) {
        mcst.confirm('Are you sure to delete?', function () {
            $.ajax({
                type: "POST",
                url: "/Admin/kekhaigia/Delete",
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