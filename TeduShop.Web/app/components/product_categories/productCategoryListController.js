/// <reference path="D:\learning\TeduShop\TeduShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.keyword = '';
        $scope.isAll = false;

        $scope.search = function () {
            getProductCategories();
        }

        $scope.AddProductCategory = function () {

        }

        $scope.selectAll = function () {
            if ($scope.isAll === false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.deleteMultiple = function () {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            })
            var config = {
                params: {
                    checkedItems: JSON.stringify(listId)
                }
            }
            apiService.del('/api/productcategory/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xoa thanh cong' + result.data + ' records');
                getProductCategories();
            }, function () {
                notificationService.displayError('Xoa khong thanh cong!!');
            })
        }

        $scope.$watch("productCategories", function (n, o) {
            var checkeds = $filter("filter")(n, { checked: true });
            if (checkeds.length) {
                $scope.selected = checkeds;
                $('#btnDelete').removeAttr('disabled');
            }
            else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $scope.deleteProductCategory = function (id) {
            $ngBootbox.confirm('Are you sure to delete??').then(function () {
                var config = {
                    params: {
                        id: id,
                    }
                }
                apiService.del('/api/productcategory/delete', config, function () {
                    notificationService.displaySuccess('Xoa thanh cong!!');
                    getProductCategories();
                }, function () {
                    notificationService.displayError('Xoa khong thanh cong!!');
                })
            });
        }

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20,
                }
            }

            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Khong co ban ghi nao dc tim thay');
                }
                else
                    notificationService.displaySuccess("Da tim thay " + result.data.TotalCount + " ban ghi.");
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load productcategory failed!!!');
            });
        };

        $scope.getProductCategories();
    };
})(angular.module('tedushop.product_categories'));