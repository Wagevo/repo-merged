document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".employee-row").forEach(row => {
        row.addEventListener("click", function () {
            let employeeId = this.getAttribute("data-id");
            window.location.href = `/Company/Employee/${employeeId}`;
        });
    });
});