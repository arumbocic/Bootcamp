var customers = [
    { 'Id': 1, 'FirstName': 'Dragan', 'LastName': 'Komadina', 'Address': 'Krizevci' },
    { 'Id': 2, 'FirstName': 'Ivan', 'LastName': ' Ivic', 'Address': 'Zupanja' },
    { 'Id': 3, 'FirstName': 'Ivana', 'LastName': 'Kovacic', 'Address': 'Sinj' },
    { 'Id': 4, 'FirstName': 'Luka', 'LastName': 'Lovric', 'Address': 'Osijek' },
    { 'Id': 5, 'FirstName': 'Marko', 'LastName': 'Savic', 'Address': 'Slavonski Brod' },
    { 'Id': 6, 'FirstName': 'Marko', 'LastName': 'Markovic', 'Address': 'Popovaca' },
    { 'Id': 7, 'FirstName': 'Martin', 'LastName': 'Martin', 'Address': 'Orahovica' },
    { 'Id': 8, 'FirstName': 'Mladen', 'LastName': 'Bjelogoric', 'Address': 'Rijeka' },
    { 'Id': 9, 'FirstName': 'Petar', 'LastName': 'Kovacic', 'Address': 'Sinj' },
    { 'Id': 10, 'FirstName': 'Zdravko', 'LastName': 'Dren', 'Address': 'Donji Miholjac' }
] 

// READ //

loadTable(customers);

function loadTable(data) {
    var table = document.getElementById('mytable');

    for ( let i = 0; i < data.length; i++) {
        let row = 
        `
        <tr>
            <td>${data[i].Id}</td>
            <td>${data[i].FirstName}</td>
            <td>${data[i].LastName}</td>
            <td>${data[i].Address}</td>
            <td><button type="button" class="btn btn-outline-secondary" onclick="showUserEditBox('${data[i].Id}')">Edit</button></td>
            <td><button type="button" class="btn btn-outline-danger" onclick="userDelete('${data[i].Id}')">Del</button></td>
        </tr> 
        `
        table.innerHTML += row;
    }
};





