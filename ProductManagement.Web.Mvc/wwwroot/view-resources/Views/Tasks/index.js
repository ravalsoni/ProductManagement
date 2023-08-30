(function ($) {
    $(function () {

        var _$taskStateCombobox = $('#TaskStateCombobox');

        _$taskStateCombobox.change(function () {
            location.href = '/Tasks?state=' + _$taskStateCombobox.val();
        });

    });
    var _taskApp = abp.services.app.task
    l = abp.localization.getSource('ProductManagement'),
        _$modal = $('#TaskCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#TaskTable');

    var _$categoryTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _taskApp.getAll,
            inputFilter: function () {
                return $('#TaskTable').serializeFormToObject(true);
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
                data: 'title',
                sortable: false
            },
            {
                targets: 2,
                data: 'state',
                sortable: false
            },

            {
                targets: 3,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',

                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-category" data-category-id="${row.id}" data-toggle="modal" data-targect="#CategoryEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-user" data-user-id="${row.id}" data-user-name="${row.title}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    $(document).on('click', '.delete-user', function () {
        var Id = $(this).attr("data-user-id");
        var title = $(this).attr('data-user-name');

        deleteUser(Id, title);
    });

    function deleteUser(Id, title) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                title),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _taskApp.delete({
                        id: Id
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$taskTable.ajax.reload();
                    });
                }
            }
        );
    }


   
})(jQuery);

