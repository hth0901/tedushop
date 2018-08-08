/// <reference path="D:\learning\TeduShop\TeduShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService'];

    function apiService($http, notificationService) {
        return {
            get: get,
            post: post
        }

        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is required!!');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
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