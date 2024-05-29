// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $("#filter").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#example-table > tbody > tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    const ths = $("th");
    let sortOrder = 1;

    ths.on("click", function () {
        const rows = sortRows(this);
        rebuildTbody(rows);
        updateClassName(this);
        sortOrder *= -1; //反転
    })

    function sortRows(th) {
        const rows = $.makeArray($('tbody > tr'));
        const col = th.cellIndex;
        const type = th.dataset.type;
        rows.sort(function (a, b) {
            return compare(a, b, col, type) * sortOrder;
        });
        return rows;
    }

    function compare(a, b, col, type) {
        let _a = a.children[col].textContent;
        let _b = b.children[col].textContent;
        if (type === "number") {
            _a *= 1;
            _b *= 1;
        } else if (type === "string") {
            //全て小文字に揃えている。toLowerCase()
            _a = _a.toLowerCase();
            _b = _b.toLowerCase();
        }

        if (_a < _b) {
            return -1;
        }
        if (_a > _b) {
            return 1;
        }
        return 0;
    }

    function rebuildTbody(rows) {
        const tbody = $("tbody");
        while (tbody.firstChild) {
            tbody.remove(tbody.firstChild);
        }

        let j;
        for (j = 0; j < rows.length; j++) {
            tbody.append(rows[j]);
        }
    }

    function updateClassName(th) {
        let k;
        for (k = 0; k < ths.length; k++) {
            ths[k].className = "";
        }
        th.className = sortOrder === 1 ? "asc" : "desc";
    }

});