(function ($) {
    var _categoryApp = abp.services.app.category
        l = abp.localization.getSource('ProductManagement'),
            _$modal = $('#CategoryCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#CategoryTable');

    var _$categoryTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _categoryApp.getAllCat,
            inputFilter: function () {
                return $('#categoryTable').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$categoryTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'categoryName',
                sortable: false
            },
            {
                targets: 2,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-category" data-category-id="${row.id}" data-toggle="modal" data-targect="#CategoryEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-user" data-user-id="${row.id}" data-user-name="${row.categoryName}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    $(document).on('click', '.delete-user', function () {
        var Id = $(this).attr("data-user-id");
        var categoryName = $(this).attr('data-user-name');

        deleteUser(Id, categoryName);
    });

    function deleteUser(Id, categoryName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                categoryName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _categoryApp.delete({
                        id: Id
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$categoryTable.ajax.reload();
                    });
                }
            }
        );
    }

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }
        var cate = _$form.serializeFormToObject();
        abp.ui.setBusy(_$modal);
        _categoryApp.create(cate).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$categoryTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });


    $(document).on('click', '.edit-category', function (e) {
        var cateId = $(this).attr("data-category-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Category/EditModal?Id=' + cateId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#CategoryEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    $(document).on('click', 'a[data-target="#CategoryCreateModal"]', (e) => {
        $('.nav-tabs a[href="#category-details"]').tab('show')
    });

    abp.event.on('category.edited', (data) => {
        _$categoryTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });
  
 
    $('.btn-search').on('click', (e) => {
        _$categoryTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$categoryTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
