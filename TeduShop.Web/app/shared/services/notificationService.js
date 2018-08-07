/// <reference path="D:\learning\TeduShop\TeduShop.Web\Assets/admin/libs/toastr/toastr.js" />
(function (app) {
    app.factory('notificationService', notificationService);

    function notificationService() {
        toastr.options = {
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "fadeIn": 300,
            "fadeOut": 1000,
            "timeOut": 3000,
            "extendedTimeOut": 1000,
        };

        function showSuccess(strMess) {
            toastr.success(strMess);
        }

        function showError(strErrors) {
            if (Array.isArray(strErrors)) {
                strErrors.each(function (err) {
                    toastr.error(err);
                });
            }
            else
                toastr.error(strErrors);
        }

        function showWarning(strMess) {
            toastr.warning(strMess);
        }

        function showInfo(strMess) {
            toastr.info(strMess);
        }

        return {
            displaySuccess: showSuccess,
            displayError: showError,
            displayWarning: showWarning,
            displayInfo: showInfo,
        }
    }
})(angular.module('tedushop.common'))