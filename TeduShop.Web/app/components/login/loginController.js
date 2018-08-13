/// <reference path="D:\learning\TeduShop\TeduShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('loginController', loginController);

    loginController.$inject = ['$scope', 'apiService', 'notificationService', '$state'];
    function loginController($scope, apiService, notificationService, $state) {
        $scope.loginSubmit = function () {
            $state.go('home');
        }
    }
})(angular.module('tedushop')); //thuoc module tedoshop