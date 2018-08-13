/// <reference path="/Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('tedushop', ['tedushop.products', 'tedushop.product_categories', 'tedushop.common']).config(config);      //ten module chinh la 'tedushop'

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

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
})();