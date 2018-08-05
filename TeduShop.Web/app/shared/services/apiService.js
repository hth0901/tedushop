/// <reference path="D:\learning\TeduShop\TeduShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http'];

    function apiService($http) {
        return {
            get: get
        }

        function get(url, params, successed, failure) {
            $http.get(url, params).then(function (result) {
                successed(result);
            }, function (error) {
                failure(error);
            });
        }
    };
})(angular.module('tedushop.common'));     //thuoc module tedushop.common (thuoc namespace tedushop.common)