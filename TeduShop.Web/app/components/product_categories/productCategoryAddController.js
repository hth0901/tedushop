(function (app) {
    app.controller('productCategoryAddController', addController);

    addController.$inject = ['$scope', 'apiService', 'notificationService', '$state'];

    function addController($scope, apiService, notificationService, $state) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
        }

        $scope.parentCategories = [];

        $scope.AddProductCategory = function () {
            apiService.post('/api/productcategory/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' da dc them moi.');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Them moi khong thanh cong!!');
            });
        };

        function loadParentCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent')
            });
        }

        loadParentCategory();
    }
})(angular.module('tedushop.product_categories'))