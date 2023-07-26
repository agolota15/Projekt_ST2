$(document).ready(function () {
    loadDataTable();
})
function formatDateTime(dateString) {
    let date = new Date(dateString);
    let year = date.getFullYear();
    let month = padZero(date.getMonth() + 1);
    let day = padZero(date.getDate());
    let formattedDate = day + '.' + month + '.' + year;
    return formattedDate;
}

function padZero(value) {
    return value < 10 ? '0' + value : value;
}

function loadDataTable() {
    dataTable = $('#orderTable').DataTable({
        scrollX: 400,
        select: true,
        "language": {
            "sEmptyTable": "Nie ma danych",
            "sInfo": "Wyświetlono od _START_ do _END_ z _TOTAL_ rekordów",
            "sInfoEmpty": "Wyświetlono 0 rekordów",
            "sInfoFiltered": "(przefiltrowano z _MAX_ rekordów)",
            "sInfoPostFix": "",
            "sInfoThousands": ",",
            "sLengthMenu": "Wyświetlić _MENU_ rekordów",
            "sLoadingRecords": "Ładowanie...",
            "sProcessing": "Obróbka...",
            "sSearch": "Szukaj:",
            "sZeroRecords": "Nie ma rekordów",
            "oPaginate": {
                "sFirst": "Pierwsza",
                "sLast": "Ostatnia",
                "sNext": "Nastepne",
                "sPrevious": "Poprzednie"
            },
        },
        "ajax": {
            url: '/home/getallorders'
        },
        "columns": [
            { data: 'id' },
            { data: 'senderFullName' },
            { data: 'senderFullAddress' },
            { data: 'senderCity' },
            { data: 'recipientFullName' },
            { data: 'recipientFullAddress' },
            { data: 'recipientCity' },
            { data: 'parcelWeight' },
            { data: 'shippingDate', render: function (data) { return formatDateTime(data); } }
        ]
    });
}