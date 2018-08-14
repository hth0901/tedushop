/// <reference path="D:\learning\TeduShop\TeduShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('loginController', loginController);

    loginController.$inject = ['$scope', 'loginService', '$injector', 'notificationService'];
    function loginController($scope, loginService, $injector, notificationService) {
        $scope.loginData = {
            userName: "",
            password: "",
        };

        $scope.loginSubmit = function () {
            loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                if (response != null && response.error != undefined) {
                    notificationService.displayError("Đăng nhập không đúng.");
                    //notificationService.displayError(response.error);
                }
                else {
                    var stateService = $injector.get('$state');
                    stateService.go('home');
                }
            });
        }
    }
})(angular.module('tedushop')); //thuoc module tedoshop