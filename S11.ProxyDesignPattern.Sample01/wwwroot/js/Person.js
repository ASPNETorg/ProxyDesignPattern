
<script type="text/javascript">
    var js = jQuery.noConflict(true);
    $(document).ready(function () {
        //loadDataTable();
        loadData();
        });

    function loadDataTable() {
        alert("Start loadDataTable()");
    var c = [];
    $.ajax({
        url: '/Category/LoadDataTable',
    type: 'get',
    dataType: 'json',
    //async: false,
    success: function (data) {
                   //console.log(data);
                    if (data != null) {

        $.each(data, function (key, value) {
            $.each(value, function (key, itemData) {
                //console.log(itemData);
                c.push({ "id": itemData.id, "FirstName": itemData.FirstName, "LastName": itemData.LastName, "action": '' })

            });
        });
                        
                    }
                },
    error() {

        alert('error');
                }
            });





function selectRecord(index) {
    alert(index);

    var Firstname = document.getElementById('firstName');
    var Lastname = document.getElementById('lastName');

    var tBody = document.getElementById('tableBody');
    var tr = tBody.getElementsByTagName('tr')[index];
    var Cells = tr.getElementsByTagName("td");
    firstName.value = Cells[0].innerText;
    lastName.value = Cells[1].innerText;
}
function AddRow(record) {
    const tableBody = document.getElementById('tableBody');
    const newRow = document.createElement('tr');
    for (let i = 0; i <= 2; i++) {
        const cell = document.createElement('td');
        newRow.appendChild(cell);
        console.log(cell);
    }

    newRow.cells[0].innerText = record.Firstname;
    newRow.cells[1].innerText = record.Lastname;
    newRow.cells[2].innerHTML = '<button type = "button" class = "btn btn-info" onclick = "selectRecord()">select</button>';
    tableBody.appendChild(newRow);
}

function Save() {
    let firstName = document.getElementById('firstName').value;
    let lastName = document.getElementById('lastName').value;
    console.log('FirstName: ' + firstName.toString());
    let record =
    {
        'FirstName': firstName,
        'LastName': lastName,
    };
    console.log(record);
    AddRow(record);
}