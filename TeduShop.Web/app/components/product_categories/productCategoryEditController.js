(function (app) {
    app.controller('productCategoryEditController', updateController);

    updateController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];

    function updateController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
            Name: 'Danh muc 1',
        }

        function loadProductCategoryDetail() {
            apiService.get('/api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        $scope.GetSeoTitle = function () {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        $scope.updateProductCategory = function () {
            apiService.update('/api/productcategory/update', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' da dc cap nhat.');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('cap nhat khong thanh cong!!');
            });
        }

        $scope.parentCategories = [];

        function loadParentCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent')
            });
        }

        loadParentCategory();
        loadProductCategoryDetail();
    }
})(angular.module('tedushop.product_categories'))