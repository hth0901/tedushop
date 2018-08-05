/// <reference path="D:\learning\TeduShop\TeduShop.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('tedushop.products', ['tedushop.common']).config(config);      //ten module chinh la 'tedushop'

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {          //'home' la` ten cua state
            url: "/products",
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListController",
        }).state('product_add', {
            url: "/product_add",
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddController"
        })
    }
})();