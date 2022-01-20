var payments = null;
var home = {
    createBalance: function () {
        $.ajax({
            type: "GET",
            url: 'api/Payments/CreateBalance',
            cache: false,
            async: false,
            success: function (data) {
                
            },
            error: function (xhr, status, err) {
                console.log(status + " | " + err);
            }
        });
        this.getBalance();
    },
    createPayments: function () {
        $.ajax({
            type: "GET",
            url: 'api/Payments/CreatePayments',
            cache: false,
            async: false,
            success: function (data) {
                
            },
            error: function (xhr, status, err) {
                console.log(status + " | " + err);
            }
        });
        this.getPayments();
    },
    createTableHeaders: function () {
        $.ajax({
            type: "GET",
            url: 'api/Payments/CreateTableHeaders',
            cache: false,
            async: false,
            success: function (data) {

            },
            error: function (xhr, status, err) {
                console.log(status + " | " + err);
            }
        });
        this.getTableHeaders();
    },
    getBalance: function () {
        $.ajax({
            type: "GET",
            url: 'api/Payments/GetBalance',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            async: false,
            success: function (data) {
                $(".balance__display").html(data[0].accountBalance);
            },
            error: function (xhr, status, err) {
                console.log(status + " | " + err);
            }
        });
    },
    getPayments: function () {
        $.ajax({
            type: "GET",
            url: 'api/Payments/GetPayments',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            async: false,
            success: function (data) {
                payments = data;
            },
            error: function (xhr, status, err) {
                console.log(status + " | " + err);
            }
        });
    },
    getTableHeaders: function () {
        var tableHeaders = null;
        $.ajax({
            type: "GET",
            url: 'api/Payments/GetTableHeaders',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            async: false,
            beforeSend: function () {
                $('.spinner_loader').show();
            },
            success: function (data) {
                tableHeaders = data;
                $('.spinner_loader').hide();
            },
            error: function (xhr, status, err) {
                console.log(status + " | " + err);
            }
        });
        this.setTableData(tableHeaders);
    },

    setTableData: function (tableHeaders) {
        var paymentsDiv = document.querySelector("div.payments");

        while (paymentsDiv.firstChild)
            paymentsDiv.removeChild(paymentsDiv.firstChild)

        // populate table headers
        var paymentsTable = document.createElement('table');
        paymentsTable.className = 'payments__list';

        var paymentsThead = document.createElement('thead');
        paymentsThead.className = 'paymentsTableHead';

        var paymentsTheadRow = document.createElement('tr');
        paymentsTheadRow.className = 'paymentsTableHeadRow';

        for (var prop in tableHeaders[0]) {
            if (prop != 'id') {
                let paymentsHeader = document.createElement('th');

                if (prop == 'closedReason') {
                    if (payments.some(x => x.closedReason != null)) { // will check if there's a Closed reason and display reason column
                        paymentsHeader.innerText = 'REASON';
                        paymentsTheadRow.append(paymentsHeader);
                    }
                } else {
                    paymentsHeader.innerText = prop.toUpperCase();
                    paymentsTheadRow.append(paymentsHeader);
                }
            }
        }
        paymentsThead.append(paymentsTheadRow);
        paymentsTable.append(paymentsThead);
        paymentsDiv.append(paymentsTable);

        // populate table body
        var paymentsTableBody = document.createElement('tbody')
        paymentsTableBody.className = "paymentsTableBody"
        paymentsTable.append(paymentsTableBody)

        for (var prop in payments) {
            var paymentsTr = document.createElement("tr");
            var item = payments[prop];

            for (var prop1 in item) {
                if (prop1 != "id") {
                    var item1 = item[prop1]
                    var paymentsTd = null;

                    if (prop1 == 'closedReason') {
                        if (payments.some(x => x.closedReason != null)) { // will check if there's a Closed reason and display reason column
                            paymentsTd = document.createElement("td");
                            paymentsTd.className = "paymentsTd";
                            paymentsTd.innerText = item1;
                            paymentsTr.appendChild(paymentsTd);
                            paymentsTableBody.appendChild(paymentsTr);
                        }
                    } else {
                        paymentsTd = document.createElement("td");
                        paymentsTd.className = "paymentsTd";
                        paymentsTd.innerText = item1;
                        paymentsTr.appendChild(paymentsTd);
                        paymentsTableBody.appendChild(paymentsTr);
                    }
                }   
            }
        }
    }

};

window.onload = function () {
    setTimeout(function () {
        home.createBalance();
        home.createPayments();
        home.createTableHeaders();
    }, 1000);
}