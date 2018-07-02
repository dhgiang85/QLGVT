var Dongia = function () {
    var self = this;
    this.initialize = function () {
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btnAddDongia', function (e) {
            e.preventDefault();
            resetFormMaintainance();
            var that = $(this).data('id');
            $('#hidDKTuyenId').val(that);
            var kc = $(this).data('kc');
            $('#hKhoangCach').val(kc);
            LoadGiaSosanh();
        
        });
        //$('body').on('click', '.btnEditDongia', function (e) {
        //    e.preventDefault();
        //    resetFormMaintainance();
        //    var that = $(this).data('id');
        //    $('#hidDKTuyenId').val(that);
        //    var kc = $(this).data('kc');
        //    $('#hKhoangCach').val(kc);
        //    LoadGiaSosanh();

        //});
        $('#txtDateAppliedVM').datepicker({
            autoclose: true,
            //defaultDate: new Date(),
            format: 'dd/mm/yyyy'
            
        });

        $('#modalAddDongia').on('click', '#btnSave', function (e) {
            e.preventDefault();
            saveVM();
        });
        RateCalculartor();
        $('#modalAddDongia').on('change paste keyup', 'input[type="number"]', function () {
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
    }
    function resetFormMaintainance() {
        $('#hidDKTuyenId').val(0);
        $('#hKhoangCach').val(0);
        $('#hidDonGiaBaseId').val(0);
        //-----------------------------------
        $('#txtSLTGVM').val(0);

        $('#txtCPNLVM').val(0);
        $('#txtCPNCTTVM').val(0);
        $('#txtCPKHTBVM').val(0);
        $('#txtCPSXKDDTVM').val(0);

        $('#txtCPSXCVM').val(0);
        $('#txtCPTCVM').val(0);
        $('#txtCPBHVM').val(0);
        $('#txtCPQLVM').val(0);

        $('#txtLoiNhuanDukienVM').val(0);
        //-----------------------------------
        $('#txtSLTGRateVM').val(0);

        $('#txtCPNLRateVM').val(0);
        $('#txtCPNCTTRateVM').val(0);
        $('#txtCPKHTBRateVM').val(0);
        $('#txtCPSXKDDTRateVM').val(0);

        $('#txtCPSXCRateVM').val(0);
        $('#txtCPTCRateVM').val(0);
        $('#txtCPBHRateVM').val(0);
        $('#txtCPQLRateVM').val(0);

        $('#txtLoiNhuanDukienRateVM').val(0);
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
            url: "/admin/donvivantai/GetGiaSoSanh",
            data: {
                DKTuyenId: $('#hidDKTuyenId').val()      
            },
            dataType: "json",
            success: function (response) {
                console.log(response);
                $('#txtSLTGBVM').val(response.SLTG);

                $('#txtCPNLBVM').val(response.CPNL);
                $('#txtCPNCTTBVM').val(response.CPNCTT);
                $('#txtCPKHTBBVM').val(response.CPKHTB);
                $('#txtCPSXKDDTBVM').val(response.CPSXKDDT);

                $('#txtCPSXCBVM').val(response.CPSXC);
                $('#txtCPTCBVM').val(response.CPTC);
                $('#txtCPBHBVM').val(response.CPBH);
                $('#txtCPQLBVM').val(response.CPQL);
                $('#txtDateAppliedBVM').val(mcst.dateFormatJson(response.DateApplied));
                                
                $('#txtLoinhuanDukienBVM').val(response.LoinhuanDukien);

                $('#txtGTVBVM').val(response.GiathanhVe);

                $('#txtGVCTBVM').val(response.PriceNotVAT);
                $('#txtVATBVM').val(response.VAT);
                $('#txtGVDKBVM').val(response.GiaVeDukien);
                
                //-----------------------
                $('#txtTotalB').val(response.Total);
                $('#txtTotalCPTTB').val(response.TotalCPTT);
                $('#txtTotalCPCB').val(response.TotalCPC);
                
                $('#txtTotalKDB').val(response.Total);
                $('#hidDonGiaBaseId').val(response.Id);
                

            }
        });
    }

    function saveVM() {
        //if ($('#frmDongiaMaintainance').valid()) {

            var id = 0;
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
            var sltgrate =$('#txtSLTGRateVM').val();

            var cpnlrate = $('#txtCPNLRateVM').val();
            var cpncttrate = $('#txtCPNCTTRateVM').val();
            var cpkhtbrate = $('#txtCPKHTBRateVM').val();
            var cpsxkddtrate = $('#txtCPSXKDDTRateVM').val();

            var cpsxcrate = $('#txtCPSXCRateVM').val();
            var cptcrate = $('#txtCPTCRateVM').val();
            var cpbhrate = $('#txtCPBHRateVM').val();
            var cpqlrate = $('#txtCPQLRateVM').val();

            var loinhuandukienrate = $('#txtLoinhuanDukienRateVM').val();

            var giathanhve = $('#txtGVCTVM').val();

            var note = $('#txtNoteVM').val();

            var dateapplied = $('#txtDateAppliedVM').val();

            $.ajax({
                type: "POST",
                url: "/Admin/donvivantai/SaveDongia",
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
                    DateApplied: dateapplied
 
                },
                dataType: "json",
                beforeSend: function () {
                    mcst.startLoading();
                },
                success: function (response) {
                    mcst.notify('Update product successful', 'success');
                    $('#modalAddDongia').modal('hide');
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
        //}
    }

}
