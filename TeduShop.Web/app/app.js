/// <reference path="/Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('tedushop', ['tedushop.products', 'tedushop.common']).config(config);      //ten module chinh la 'tedushop'

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {          //'home' la` ten cua state
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController",
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();