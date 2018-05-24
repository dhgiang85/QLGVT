var benxeController = function () {
    this.initialize = function () {
        $.when().done(function () {
                loadData();
            });

        registerEvents();
    }
    function registerEvents() {
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'en',
            rules: {
                txtTenM: { required: true },
                txtOrderM: { number: true }

            }
        });

        $('#btnCreate').off('click').on('click', function () {
            resetFormMaintainance();
            $('#modalAddEdit').modal('show');
        });

        $('#btnSave').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = parseInt($('#hidIdM').val());
                var ten = $('#txtTenM').val();
                var description = $('#txtDescM').val();
                var order = parseInt($('#txtOrderM').val());
                var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
                
                $.ajax({
                    type: "POST",
                    url: "/Admin/benxe/SaveEntity",
                    data: {
                        Id: id,
                        Ten: ten,
                        Description: description,
                        SortOrder: order,
                        Status: status
  
                    },
                    dataType: "json",
                    beforeSend: function () {
                        mcst.startLoading();
                    },
                    success: function (response) {
                        mcst.notify('Update success', 'success');
                        $('#modalAddEdit').modal('hide');

                        resetFormMaintainance();

                        mcst.stopLoading();
                        loadData();
                    },
                    error: function () {
                        mcst.notify('Has an error in update progress', 'error');
                        mcst.stopLoading();
                    }
                });
            }
            return false;
        });

        $('body').on('click', '#btnEdit', function (e) {
            e.preventDefault();
            var that = $('#hidIdM').val();
            loadDetails(that);
        });

        $('body').on('click', '#btnDelete', function (e) {
            e.preventDefault();
            var that = $('#hidIdM').val();
            deleteVM(that);
        });

        
    }
    function resetFormMaintainance() {
        $('#hidIdM').val(0);

        $('#txtTenM').val('');
        $('#txtDescM').val('');
        $('#txtOrderM').val(1);
        $('#ckStatusM').prop('checked', true);

        $('#frmMaintainance').validate().resetForm();
    }
  
    function loadData() {
        $.ajax({
            url: '/Admin/benxe/GetAll',
            dataType: 'json',
            success: function (response) {
                var data = [];
                $.each(response, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Ten,
                        parentId: item.ParentId,
                        sortOrder: item.SortOrder
                    });

                });
                var treeArr = mcst.unflattern(data);
                treeArr.sort(function (a, b) {
                    return a.sortOrder - b.sortOrder;
                });
                //var $tree = $('#treeProductCategory');

                $('#treeBenxe').tree({
                    data: treeArr,
                    dnd: true,
                    onContextMenu: function (e, node) {
                        e.preventDefault();
                        // select the node
                        //$('#tt').tree('select', node.target);
                        $('#hidIdM').val(node.id);
                        // display context menu
                        $('#contextMenu').menu('show', {
                            left: e.pageX,
                            top: e.pageY
                        });
                    },
                    onDrop: function (target, source, point) {
                        console.log(target);
                        console.log(source);
                        console.log(point);
                        var targetNode = $(this).tree('getNode', target);
                        if (point === 'append') {
                            loadData();
                        }
                        else if (point === 'top' || point === 'bottom') {
                            $.ajax({
                                url: '/Admin/benxe/ReOrder',
                                type: 'post',
                                dataType: 'json',
                                data: {
                                    sourceId: source.id,
                                    targetId: targetNode.id
                                },
                                success: function (res) {
                                    loadData();
                                }
                            });
                        }
                    }
                });

            }
        });
    }

    function loadDetails(id) {
        $.ajax({
            type: "GET",
            url: "/Admin/benxe/GetById",
            data: { id: id },
            dataType: "json",
            beforeSend: function () {
                mcst.startLoading();
            },
            success: function (response) {
                var data = response;
                $('#hidIdM').val(data.Id);
                $('#txtTenM').val(data.Ten);
                $('#txtDescM').val(data.Description);
                $('#txtOrderM').val(data.SortOrder);
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
                url: "/Admin/benxe/Delete",
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