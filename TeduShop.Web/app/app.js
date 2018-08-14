/// <reference path="/Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('tedushop', ['tedushop.products', 'tedushop.product_categories', 'tedushop.common'])
        .config(config)
        .config(configAuthentication);      //ten module chinh la 'tedushop'

    //config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
        .state('base', {
            url: '',
            templateUrl: '/app/shared/views/baseView.html',
            abstract: true,
        })
        .state('login', {          //'home' la` ten cua state
            url: "/login",
            templateUrl: "/app/components/login/loginView.html",
            controller: "loginController",
        })
        .state('home', {          //'home' la` ten cua state
            url: "/admin",
            parent:'base',
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController",
        });
        $urlRouterProvider.otherwise('/admin');
    }

    //configAuthentication.$inject = ['$q'];

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(['$q', '$location', function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        }]);
    }

    /*function configAuthentication($httpProvider, $q, $location) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }*/
})();