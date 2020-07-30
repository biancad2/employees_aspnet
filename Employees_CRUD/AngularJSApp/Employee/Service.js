employeeApp.service('employeeService', function ($http) {
    this.getAllEmployees = function () {
        return $http.get("/employee/GetEmployee");
    }

    this.addEmployee = function (employee) {
        var request = $http({
            method: 'post',
            url: '/employee/AddEmployee',
            data: employee
        });

        return request;
    }

    this.updateEmployee = function (employee) {
        var request = $http({
            method: 'post',
            url: '/employee/UpdateEmployee',
            data: employee
        });
        return request;
    }

    this.deleteEmployee = function (UpdatedEmployeeId) {
        return $http.post('/employee/DeleteEmployee/' + UpdatedEmployeeId);
    }
});