(function (app) {
    app.controller('productEditController', updateController);

    updateController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];

    function updateController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        $scope.productInfo = {
            CreatedDate: new Date(),
            Status: true,
            Name: 'Danh muc 1',
        }

        $scope.productCategories = [];

        function loadProductDetail() {
            apiService.get('/api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productInfo = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        $scope.GetSeoTitle = function () {
            $scope.productInfo.Alias = commonService.getSeoTitle($scope.productInfo.Name);
        }

        $scope.updateProduct = function () {
            apiService.update('/api/product/update', $scope.productInfo, function (result) {
                notificationService.displaySuccess(result.data.Name + ' da dc cap nhat.');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('cap nhat khong thanh cong!!');
            });
        }

        function getListProductCategories() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function (error) {
                console.log('get product category failed');
            });
        }

        getListProductCategories();

        //$scope.parentCategories = [];

        //function loadParentCategory() {
        //    apiService.get('/api/productcategory/getallparents', null, function (result) {
        //        $scope.parentCategories = result.data;
        //    }, function () {
        //        console.log('Cannot get list parent')
        //    });
        //}

        //loadParentCategory();
        loadProductDetail();
    }
})(angular.module('tedushop.products'));