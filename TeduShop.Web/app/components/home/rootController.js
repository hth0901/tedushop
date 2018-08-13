/// <reference path="D:\learning\TeduShop\TeduShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['$scope', 'apiService', 'notificationService', '$state'];
    function rootController($scope, apiService, notificationService, $state) {
        $scope.logout = function () {
            $state.go('login');
        }
    };
})(angular.module('tedushop'));     //chỉ ra thuộc module nào