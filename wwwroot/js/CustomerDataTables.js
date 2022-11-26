$(Document).ready(function () {
    $('#Customers').dataTable({
        "serverSide": true, "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "api/Customers",
            "type": "post",
            "datatype":"json"
        },
        "columnDefs": [{
            "targets":[0],
            "visible": false,
            "searchable":false
        }],
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "fName", "name": "FName", "autoWidth":true },
            { "data": "lName", "name": "LName", "autoWidth":true },
            { "data": "email", "name": "Email", "autoWidth":true },
            { "data": "contact", "name": "Contact", "autoWidth":true },
            { "data": "birthDtae", "name": "BirthDtae", "autoWidth": true },

            //{
            //    "render": function (data, type, row) { return '<span>' + row.BirthDtae.split('T')[0] + '</span>' },
            //    "name": "BirthDtae"
            //}

            {"render": function (data, type, row) { return '<a href="#" class="btn btn-danger"onclick=DeleteCustomer("' + row.id + '");>Delete</a>'},
                "orderable": false
            },
        ],

    });
});


