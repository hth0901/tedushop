(function (app) {
    app.controller('productCategoryAddController', addController);

    addController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService'];

    function addController($scope, apiService, notificationService, $state, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
            Name:'',
            Alias:"",
        }

        $scope.GetSeoTitle = GetSeoTitle;

        $scope.parentCategories = [];

        $scope.AddProductCategory = function () {
            apiService.post('/api/productcategory/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' da dc them moi.');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Them moi khong thanh cong!!');
            });
        };

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

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