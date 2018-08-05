/// <reference path="../plugins/angular/angular.js" />
var kdcApp = angular.module("kdcModule", []);

kdcApp.controller("kdcController", kdcController);
//regiser service
kdcApp.service('Validator', Validator);

//kdcController.$inject['$scope', 'Validator'];

//declaire
function kdcController($scope, Validator) {
    $scope.message = "";
    $scope.checkNum = function (nNum) {
        $scope.message = Validator.checkNumber(nNum);
    }
}

function Validator($window) {
    return {
        checkNumber: checkNumber,
    }
    function checkNumber(input) {
        if (input % 2 == 0) {
            return 'This is even';
        }
        else
            return 'This is odd';
    }
}