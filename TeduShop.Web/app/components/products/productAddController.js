/// <reference path="D:\learning\TeduShop\TeduShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state'];

    function productAddController($scope, apiService, notificationService, $state) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true,
        }

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px',

        };

        $scope.productCategories = [];

        $scope.AddProduct = function () {
            apiService.post('/api/product/create', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' da dc them moi.');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Them moi khong thanh cong!!');
            });
        };

        function getListProductCategories() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function (error) {
                console.log('get product category failed');
            });
        }

        getListProductCategories();
    };
})(angular.module('tedushop.products'));