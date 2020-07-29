employeeApp.controller('employeeCtrl', function ($scope, employeeService) {

    loadEmployees();

    function loadEmployees() {
        var listEmployees = employeeService.getAllEmployees();
        listEmployees.then(function (d) {
            $scope.Employees = d.data;
        }, function () {
            alert("An error ocurred while trying to list the employees!")
        });
    }

    $scope.addEmployee = function () {
        var employee = {
            employeeId: $scope.employeeId,
            name: $scope.name,
            email: $scope.email,
            department: $scope.department,
            office: $scope.office
        };

        var addInfos = employeeService.addEmployee(employee);

        addInfos.then(function (d) {
            if (d.data.success === true) {
                loadEmployees();
                alert("Employee added successfully!");

                $scope.clearData();

            } else {
                alert("Some error occurred, employee wasn't added!")
            }
        },
            function () {
                alert("Some error occurred trying to add a new employee!")
            }
        );
    }

    $scope.clearData = function () {
        $scope.employeeId = '';
        $scope.name = '';
        $scope.email = '';
        $scope.department = '';
        $scope.office = '';
    }
});